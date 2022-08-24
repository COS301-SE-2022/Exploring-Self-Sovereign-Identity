<!-- eslint-disable vue/multi-word-component-names -->
//eslint-disable-next-line vue/multi-word-component-names
<template>
  <img
    style="width: 40px; height: 40px"
    :src="LogoSvg"
    :style="{ width: `${props.size}rem`, height: `${props.size}rem` }"
    alt="logo"
  />
</template>

<script lang="ts" setup>
import LogoSvg from "@/assets/COD6.png";

const props = withDefaults(defineProps<{ size?: number }>(), {
  size: 6.5,
});
</script>
