<script lang="ts">
import { defineComponent } from "vue";
import "@passageidentity/passage-elements/passage-auth";
import { userDataStore } from "@/stores/userData";
export default defineComponent({
  data() {
    return {};
  },
  components: {},
  methods: {
    success() {
      console.log("Success");
    },
  },
  setup() {
    const appid = import.meta.env.VITE_APP_ID;
    const userData = userDataStore();

    return { appid, userData };
  },
});
</script>

<template>
  <!-- <div class="heading"><IconHeading /></div> -->

  <!-- *Passage component -->
  <div class="authContainer">
    <passage-auth :app-id="appid"></passage-auth>
  </div>
</template>

<style lang="scss">
// @import "@material/button/styles";

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
