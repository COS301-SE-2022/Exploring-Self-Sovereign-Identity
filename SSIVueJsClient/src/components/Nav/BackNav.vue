<script lang="ts">
import { MenuOutline } from "@vicons/ionicons5";
import { ArrowBackOutline } from "@vicons/ionicons5";

export default {
  props: ["page"],
  components: {
    MenuOutline,
    ArrowBackOutline,
  },
  methods: {
    goback() {
      this.$router.back();
    },
  },
};
</script>

<template>
  <div class="nav-component">
    <div class="slot"><slot /></div>

    <n-page-header
      :title="page"
      @back="goback"
      class="bar"
      data-testid="NavBack"
    >
      <template #back>
        <n-icon size="30">
          <ArrowBackOutline />
        </n-icon>
      </template>
      <template #extra>
        <n-icon size="30" color="white">
          <MenuOutline />
        </n-icon>
      </template>
    </n-page-header>
  </div>
  <!-- <n-drawer>
    <n-drawer-content></n-drawer-content>
  </n-drawer> -->
</template>

<style lang="scss">
.nav-component {
  // css to make nav-bar stay at the bottom of the screen
  position: fixed;
  bottom: 0;
  left: 0;
  width: 100%;
  padding-top: 0.5vh;
  padding-bottom: 0.5vh;
  // height: 100%;
  z-index: 1;
  // display: grid;

  // width: 100vw;
  // position: ;
  // bottom: 0vh;
  // backdrop-filter: hue-rotate(10deg);
  // border-radius: 5px;
}

.bar {
  // width: fit-content;
  text-align: center;
  background: #c197d2;
  opacity: 0.8;
  border-radius: 2px;
  box-shadow: 0 4px 30px rgba(158, 158, 158, 0.1);
  backdrop-filter: blur(12.7px);
  -webkit-backdrop-filter: blur(12.7px);
}
.slot {
  text-align: center;
  margin-bottom: 0.5vh;
}
</style>
