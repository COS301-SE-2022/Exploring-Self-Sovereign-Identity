<script lang="ts">
import IconHome from "../components/icons/IconHome.vue";
import IconMenu from "../components/icons/IconMenu.vue";
import IconGoogle from "../components/icons/IconGoogle.vue";
export default {
  data() {
    return {
      user: "Peter",
    };
  },
  components: { IconHome, IconMenu, IconGoogle },
};
</script>

<template>
  <el-card class="card">
    <template #header>
      <div>
        <IconGoogle class="icon" />
        <el-divider direction="vertical" />
        <h1>Google</h1>
      </div>
    </template>
  </el-card>

  <!-- *Bottom navbar -->
  <div class="nav">
    <el-menu default-active="1" mode="horizontal" class="menu">
      <!-- <el-row :gutter="24" justify="space-evenly">
        <el-col :span="12"> -->
      <el-menu-item index="1">
        <el-icon><IconHome class="icon" /></el-icon>
      </el-menu-item>
      <!-- </el-col>
        <el-col :span="12"> -->
      <el-menu-item index="3">
        <el-icon><IconMenu class="icon" /></el-icon>
      </el-menu-item>
      <!-- </el-col> -->
      <!-- </el-row>-->
    </el-menu>
  </div>
</template>

<style lang="scss">
.nav {
  width: 100%;
  position: fixed;
  bottom: 0%;
  text-align: center;
}
.menu {
  height: 8vh;
  // padding-top: 2vh;
  // padding-bottom: 2vh;
}

.card {
  margin: 8px;
  margin-top: 0;
}

.icon {
  width: 7vw;
}
//TODO: Need to chnage this so it doesn't apply to all headings
h1 {
  display: inline-block;
}

.card-header {
  padding-top: 0px;
  padding-bottom: 0px;
}

div {
  padding-top: 0%;
  padding-bottom: 0%;
}
</style>
