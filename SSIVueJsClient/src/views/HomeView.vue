<script lang="ts">
import IconHome from "../components/icons/IconHome.vue";
export default {
  data() {
    return {
      user: "Peter",
    };
  },
  components: { IconHome },
};
</script>

<template>
  <el-card class="card">
    <template #header>
      <div>
        <h1>Temp</h1>
      </div>
    </template>
    <div v-for="o in 4" :key="o" class="text item">{{ "List item " + o }}</div>
  </el-card>

  <!-- *Bottom navbar -->
  <div class="nav">
    <el-menu
      default-active="1"
      class="el-menu-vertical-demo"
      @open="handleOpen"
      @close="handleClose"
    >
      <el-row :gutter="9">
        <el-col :span="3">
          <el-menu-item index="1">
            <el-icon><IconHome /></el-icon>
          </el-menu-item>
        </el-col>
      </el-row>
    </el-menu>
  </div>
</template>

<style lang="scss">
.nav {
  width: 100%;
  position: fixed;
  bottom: 0%;
}

.card {
  margin: 8px;
  margin-top: 0;
}
</style>
