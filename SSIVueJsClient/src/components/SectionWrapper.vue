<script lang="ts">
import { defineComponent } from 'vue'
export default defineComponent({
  setup() {
    const props = defineProps<{
      title?: string
    }>()

    return {
      props,
    }
  },
})
</script>

<template>
  <div class="setting-section">
    <div class="section-title">{{ props.title }}</div>
    <div>
      <slot />
    </div>
  </div>
</template>

<style lang="scss" scoped>
.setting-section {
  padding: 1.8rem 1rem;

  .section-title {
    margin-bottom: 1.5rem;
    font-weight: bold;
    line-height: 23px;
  }
}
</style>
