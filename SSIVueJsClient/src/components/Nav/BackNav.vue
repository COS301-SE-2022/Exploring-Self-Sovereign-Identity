<script lang="ts">
export default {
  props: ["page"],
  methods: {
    goback() {
      this.$router.back();
    },
  },
};
</script>

<template>
  <div class="nav" data-testid="NavBack">
    <el-page-header :content="page" @back="goback" />
  </div>
</template>

<style lang="scss">
.nav {
  width: 99vw;
  padding: 4%;
  position: fixed;
  bottom: 0vh;
  backdrop-filter: hue-rotate(30deg);
  border-radius: 5px;
}
</style>
