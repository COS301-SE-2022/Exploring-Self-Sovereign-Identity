<script setup lang="ts">
import { RouterView } from "vue-router";
import { NConfigProvider } from "naive-ui";

/**
 * Use this for type hints under js file
 * @type import('naive-ui').GlobalThemeOverrides
 */
const themeOverrides = {
  common: {
    primaryColor: "#6FEAE6FF",
    primaryColorHover: "#29CCC7FF",
    primaryColorPressed: "#29CCC7FF",
  },
};
</script>

<template>
  <n-config-provider :theme-overrides="themeOverrides">
    <RouterView />
  </n-config-provider>
</template>
