<template>
  <div
    ref="avatarRef"
    class="vue-color-avatar"
    :style="{
      width: `${avatarSize}px`,
      height: `${avatarSize}px`,
    }"
    :class="getWrapperShapeClassName()"
  >
    <Background :color="avatarOption.background.color" />

    <div class="avatar-payload" v-html="svgContent" />
  </div>
</template>

<!-- <script setup lang="ts">
    const propsG = withDefaults(defineProps<{
      option: AvatarOption
      size?: number
    }>(), {
      option: () => getRandomAvatarOption(),
      size: 280,
    })
</script> -->

<script lang="ts">
import { ref, toRefs, watchEffect, type PropType } from 'vue'
import { defineComponent } from 'vue'
import { WidgetType, WrapperShape } from '@/enums'
import type { AvatarOption } from '@/types'
import { getRandomAvatarOption } from '@/utils'
import { AVATAR_LAYER, NONE } from '@/utils/constant'
import { widgetData } from '@/utils/dynamic-data'

//import Background from '@/components/Background.vue'
export interface VueColorAvatarRef {
  avatarRef: HTMLDivElement
}
export default defineComponent({
  props: {
      option : {
      type: Object as PropType<AvatarOption>,
      default: () => ({
        value: () => getRandomAvatarOption()
      })
    },
    size : {
      type: Object as PropType<number>,
      default: 280
    }
  },
  setup(props, { expose }) {
    //const props = propsG;

    // interface VueColorAvatarProps {
    //   option: AvatarOption
    //   size?: number
    // }

    // const props = withDefaults(defineProps<VueColorAvatarProps>(), {
    //   option: () => getRandomAvatarOption(),
    //   size: 280,
    // })

    // const { option: avatarOption, size: avatarSize } = toRefs(props)

    const { option: avatarOption, size: avatarSize } = toRefs(props)

    const avatarRef = ref<VueColorAvatarRef['avatarRef']>()

    //defineExpose({ avatarRef })

    expose({avatarRef})

    function getWrapperShapeClassName() {
      return {
        [WrapperShape.Circle]:
          avatarOption.value.wrapperShape === WrapperShape.Circle,
        [WrapperShape.Square]:
          avatarOption.value.wrapperShape === WrapperShape.Square,
        [WrapperShape.Squircle]:
          avatarOption.value.wrapperShape === WrapperShape.Squircle,
      }
    }

    const svgContent = ref('')

    watchEffect(async () => {
      const sortedList = Object.entries(avatarOption.value.widgets).sort(
        ([prevShape, prev], [nextShape, next]) => {
          const ix = prev.zIndex ?? AVATAR_LAYER[prevShape as keyof typeof AVATAR_LAYER]?.zIndex ?? 0
          const iix = next.zIndex ?? AVATAR_LAYER[nextShape as keyof typeof AVATAR_LAYER]?.zIndex ?? 0
          return ix - iix
        }
      )

      /*const promises: Promise<string>[] = sortedList.map(async ([widgetType, opt]) => {
       return (
        await import(`../assets/widgets/${widgetType}/${opt.shape}.svg?raw`)
        ).default
      })*/

      const promises: Promise<string>[] = sortedList.map(
        async ([widgetType, opt]) => {
          if (opt.shape !== NONE && widgetData?.[widgetType as keyof typeof widgetData]?.[opt.shape]) {
            return (await widgetData[widgetType as keyof typeof widgetData][opt.shape]()).default
          }
          return ''
        }
      )

      const svgRawList = await Promise.all(promises).then((raw) => {
        return raw.map((svgRaw, i) => {
          const widgetFillColor = sortedList[i][1].fillColor

          const content = svgRaw
            .slice(svgRaw.indexOf('>', svgRaw.indexOf('<svg')) + 1)
            .replace('</svg>', '')
          //.replaceAll('$fillColor', widgetFillColor || 'transparent')

          return `
        <g id="vue-color-avatar-${sortedList[i][0]}">
          ${content}
        </g>
      `
        })
      })

      svgContent.value = `
    <svg
      width="${avatarSize.value}"
      height="${avatarSize.value}"
      viewBox="0 0 ${avatarSize.value / 0.7} ${avatarSize.value / 0.7}"
      preserveAspectRatio="xMidYMax meet"
      fill="none"
      xmlns="http://www.w3.org/2000/svg"
    >
      <g transform="translate(100, 65)">
        ${svgRawList.join('')}
      </g>
    </svg>
  `
    })

    return {
      avatarSize,
      getWrapperShapeClassName,
      avatarOption,
      svgContent,
      widgetData,
    }
  },
})
</script>

<style lang="scss" scoped>
.vue-color-avatar {
  position: relative;
  overflow: hidden;

  &.circle {
    border-radius: 50%;
  }

  &.squircle {
    // TODO: Radius should adapt to the avatar size
    border-radius: 25px;
  }

  .avatar-payload {
    position: relative;
    z-index: 2;
    width: 100%;
    height: 100%;
  }
}
</style>
