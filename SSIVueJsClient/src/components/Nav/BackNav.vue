<script lang="ts">
import { MenuOutline } from "@vicons/ionicons5";
import { ArrowBackOutline } from "@vicons/ionicons5";
import { NIcon } from "naive-ui";
import type { MenuOption } from "naive-ui";
import { defineComponent, h, ref, type Component } from "vue";
import { RouterLink } from "vue-router";
import { Home, UserAvatar, NewTab, Store } from "@vicons/carbon";
import { PendingActionsRound } from "@vicons/material";

export default defineComponent({
  setup() {
    function renderIcon(icon: Component) {
      return () => h(NIcon, null, { default: () => h(icon) });
    }
    const menuOptions = [
      {
        label: () =>
          h(
            RouterLink,
            {
              to: "/home",
              name: "Home",
            },
            { default: () => "Home" }
          ),
        key: "home",
        icon: renderIcon(Home),
      },
      {
        label: () =>
          h(
            RouterLink,
            {
              to: "/profile",
              name: "Profile",
            },
            { default: () => "Profile" }
          ),
        key: "Profile",
        icon: renderIcon(UserAvatar),
      },
      {
        label: () =>
          h(
            RouterLink,
            {
              to: "/pending",
              name: "Pending",
            },
            { default: () => "Pending" }
          ),
        key: "Pending",
        icon: renderIcon(PendingActionsRound),
      },
      {
        label: () =>
          h(
            RouterLink,
            {
              to: "/request",
              name: "Request",
            },
            { default: () => "Request" }
          ),
        key: "Request",
        icon: renderIcon(NewTab),
      },
      {
        label: () =>
          h(
            RouterLink,
            {
              to: "/market",
              name: "Market",
            },
            { default: () => "Market" }
          ),
        key: "Market",
        icon: renderIcon(Store),
      },
    ] as MenuOption[];
    return { renderIcon, menuOptions };
  },
  props: ["page"],
  components: {
    MenuOutline,
    ArrowBackOutline,
  },
  data() {
    return {
      active: ref(false),
    };
  },
  methods: {
    goback() {
      this.$router.back();
    },
    show() {
      this.active = true;
    },
  },
});
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
          <MenuOutline @click="show" />
        </n-icon>
        <n-drawer v-model:show="active" width="50vw" placement="right">
          <n-drawer-content title="Menu">
            <n-menu :options="menuOptions" />
          </n-drawer-content>
        </n-drawer>
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
