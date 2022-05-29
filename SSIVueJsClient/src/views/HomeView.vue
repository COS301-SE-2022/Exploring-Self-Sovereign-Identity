<script lang="ts">
export default {
  data() {
    return {
      user: "Peter",
    };
  },
};
</script>

<template>
  <div class="mdc-card">
    <div class="mdc-card__primary-action" tabindex="0">
      <div class="mdc-card__media-content">Google</div>
      <div class="mdc-card__ripple"></div>
    </div>
    <!-- ... content ... -->
  </div>

  <ul>
    <li></li>
  </ul>
</template>

<style lang="scss">
@use "@material/card";
// @include card.core-styles;
</style>
