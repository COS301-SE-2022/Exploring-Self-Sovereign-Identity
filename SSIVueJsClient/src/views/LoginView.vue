<script lang="ts">
import "@passageidentity/passage-elements/passage-auth";
export default {
  data() {
    return {};
  },
  components: {},
  methods: {
    // route() {
    //   this.$router.push({ path: "/home" });
    // },
  },
  setup() {
    // * l6SXuEd5nIKKfC9Jc1YXVbSC
    const appid = "Q17Gza9k49k1ieI15r73xaQf";
    return { appid };
  },
};
</script>

<template>
  <!-- <div class="heading"><IconHeading /></div> -->

  <!-- *Passage component -->
  <div class="authContainer">
    <passage-auth :app-id="appid"></passage-auth>
  </div>

  <!-- *! will need to replace this biometric with passage once it is setup -->
  <!-- <div class="Biometric">
    <div @click="route">
      <IconButtonNoBG><IconBiometric /></IconButtonNoBG>
    </div>
  </div> -->
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
