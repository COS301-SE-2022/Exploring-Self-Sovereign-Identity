<script lang="ts">
import IconGoogle from "../icons/IconGoogle.vue";
export default {
  props: {
    image: String,
  },
  components: { IconGoogle },
};
</script>
<template>
  <div class="mdc-card mdc-card--outlined">
    <div class="mdc-card__media-content">
      <IconGoogle class="my-card-content" />
    </div>
    <h1>Google</h1>
  </div>
</template>

<style lang="scss">
// @use "@material/card";
@include card.core-styles;
.my-card-content {
  padding: 16px;
  width: 10%;
  height: auto;
}
</style>
