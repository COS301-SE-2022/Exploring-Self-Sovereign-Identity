<script lang="ts">
import IconBiometric from "../components/icons/IconBiometric.vue";
import IconHeading from "../components/icons/IconHeading.vue";
import IconButtonNoBG from "../components/buttons/IconButtonNoBG.vue";
export default {
  data() {
    return {};
  },
  components: { IconBiometric, IconHeading, IconButtonNoBG },
  methods: {
    route() {
      this.$router.push({ path: "/home" });
    },
  },
};
</script>

<template>
  <div class="heading"><IconHeading /></div>
  <div class="Biometric">
    <div @click="route">
      <IconButtonNoBG><IconBiometric /></IconButtonNoBG>
    </div>
  </div>
</template>

<style lang="scss">
@import "@material/button/styles";

.heading {
  display: block;
  margin-left: auto;
  margin-right: auto;
  top: 10em;
  width: 100%;
  text-align: center;
  svg {
    width: 80%;
    height: auto;
    backdrop-filter: grayscale(20%);
    padding: 0.2em;
    border-radius: 5em;
    background-size: 1em;
    border: 0.1em solid rgba(0, 0, 0, 0);
  }
}

.Biometric {
  display: block;
  bottom: 4em;
  position: fixed;
  width: 100%;
  div {
    height: auto;
    width: 100%;
    text-align: center;
  }
  button {
    width: 25%;
    height: auto;
  }
}
</style>
