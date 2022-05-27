<script lang="ts">
import { MDCRipple } from "@material/ripple";
import IconBiometric from "../components/icons/IconBiometric.vue";
import IconButton from "../components/Buttons/IconButton.vue";
export default {
  data() {
    return {};
  },
  components: { IconBiometric, IconButton },
};
</script>

<template>
  <div>
    <IconButton><IconBiometric /></IconButton>
  </div>
</template>

<style lang="scss">
@use "@material/button/styles";

div {
  display: block;
  position: absolute;
  margin-left: auto;
  margin-right: auto;
}
</style>
