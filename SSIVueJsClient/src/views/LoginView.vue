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
  <div class="heading">
    <h2>Self</h2>
    <h2>Sovereign</h2>
    <h2>Identity</h2>
  </div>
  <div class="Biometric">
    <IconButton><IconBiometric /></IconButton>
  </div>
</template>

<style lang="scss">
@import "@material/button/styles";

.heading {
  display: block;
  margin-left: auto;
  margin-right: auto;
  top: 10em;
  width: 25%;
  h2 {
    margin-left: auto;
    margin-right: auto;
  }
}

.Biometric {
  display: block;
  bottom: 4em;
  position: absolute;
  margin-left: auto;
  margin-right: auto;
  height: auto;
  width: 100%;
  button {
    width: 25%;
    height: auto;
  }
}
</style>
