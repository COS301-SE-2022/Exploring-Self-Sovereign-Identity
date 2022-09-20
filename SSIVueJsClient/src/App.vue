<script setup lang="ts">
import { RouterView } from "vue-router";
import { NConfigProvider } from "naive-ui";
import { darkTheme } from "naive-ui";

/**
 * Use this for type hints under js file
 * @type import('naive-ui').GlobalThemeOverrides
 */
const themeOverrides = {
  common: {
    primaryColor: "#C197D2",
    primaryColorHover: "#613659",
    primaryColorPressed: "#613659",
  },
  return: {
    darkTheme,
  },
};
</script>

<template>
  <n-config-provider :theme-overrides="themeOverrides" :theme="darkTheme">
    <n-message-provider>
      <RouterView />
    </n-message-provider>
  </n-config-provider>
</template>
