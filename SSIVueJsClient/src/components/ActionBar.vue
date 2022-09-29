<script lang="ts">
import { defineComponent } from "vue";
import { computed } from "vue";

import IconBack from '@/assets/icons/icon-back.svg'
import IconFlip from '@/assets/icons/icon-flip.svg'
import IconNext from '@/assets/icons/icon-next.svg'
import { ActionType } from '@/enums'
import { useStore } from '@/stores'
export default defineComponent({
  //components: { IconBack, IconCode, IconFlip, IconNext },
  emits: ["action"],
  setup(props, { emit }) {
    // const emit = defineEmits<{
    //   (e: 'action', actionType: ActionType): void
    // }>()

    const store = useStore();

    const canUndo = computed(() => store.state.history.past.length > 0);
    const canRedo = computed(() => store.state.history.future.length > 0);

    const actions = computed(() => [
      {
        type: ActionType.Undo,
        icon: IconBack,
        tip: "action.undo",
        disabled: !canUndo.value,
      },
      {
        type: ActionType.Redo,
        icon: IconNext,
        tip: "action.redo",
        disabled: !canRedo.value,
      },

    ])

    return {
      actions,
      emit,
    };
  },
});
</script>

<template>
  <div class="action-menu">
    <div
      v-for="ac in actions"
      :key="ac.type"
      class="menu-item"
      :class="{ disabled: ac.disabled }"
      :title="ac.tip"
      @click="emit('action', ac.type)"
    >
      <img :src="ac.icon" :alt="ac.tip" />
    </div>
  </div>
</template>

<style lang="scss" scoped>
@use "src/styles/var";

.action-menu {
  display: flex;
  align-items: center;
  margin-top: 5rem;
  padding: 0.5rem;
  background-color: var.$color-gray;
  border-radius: 2rem;

  .menu-item {
    display: flex;
    align-items: center;
    justify-content: center;
    width: 2.5rem;
    height: 2.5rem;
    margin: 0 0.5rem;
    background-color: lighten(var.$color-gray, 10);
    border-radius: 50%;
    cursor: pointer;
    transition: opacity 0.2s;

    &.disabled {
      cursor: default;
      opacity: 0.6;
    }
  }
}
</style>
