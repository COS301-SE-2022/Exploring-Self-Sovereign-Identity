<script lang="ts">
import { MenuOutline } from '@vicons/ionicons5'
import { ArrowBackOutline } from '@vicons/ionicons5'

export default {
  props: ['page'],
  components: {
    MenuOutline,
    ArrowBackOutline,
  },
  methods: {
    goback() {
      //this.$router.back()
    },
  },
}
</script>

<template>
  <n-page-header
    :title="page"
    @back="goback"
    class="nav-component"
    data-testid="NavBack"
  >
    <template #back>
      <n-icon size="30">
        <ArrowBackOutline />
      </n-icon>
    </template>
    <template #extra>
      <n-icon size="30">
        <MenuOutline />
      </n-icon>
    </template>
  </n-page-header>

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
  // height: 100%;
  z-index: 1;
  // display: grid;

  // width: 100vw;
  // position: ;
  // bottom: 0vh;
  // backdrop-filter: hue-rotate(10deg);
  // border-radius: 5px;
}
</style>
