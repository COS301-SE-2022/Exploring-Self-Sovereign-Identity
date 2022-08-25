<script lang="ts">
import { defineComponent } from "vue";
export default defineComponent({
  data() {
    return {};
  },
  components: {},
  methods: {
    // route() {
    //   this.$router.push({ path: "/home" });
    // },

    goProfile() {
      this.$router.push({ path: "/profile" });
    },
    go(p: string) {
      this.$router.push({ path: p });
    },
  },
  setup() {
    const appid = "Q17Gza9k49k1ieI15r73xaQf";
    return { appid };
  },
});


</script>

<template><h3>Avatars</h3>;</template>