<script lang="ts">
import { mapState } from "pinia";
import { UserDataStore } from "@/stores/UserDataStore";
import type { Attribute } from "@/models/entity/Attribute";
export default {
  data() {
    return {
      id: "12gwbd83t823tdqwd",
    };
  },
  computed: {
    ...mapState(UserDataStore, ["getUserData"]),
    getAttributes() {
      return this.getUserData.getAttributes();
    },
    getCredentials() {
      return this.getUserData.getCredentials();
    },
  },
  methods: {
    goback() {
      this.$router.push({ path: "/home" });
    },
  },
};
</script>

<template>
  <div class="info">
    <!-- * User ID -->
    <el-input v-model="id" placeholder="ID" disabled>
      <template #prepend>ID</template>
    </el-input>

    <el-divider />

    <!-- * Attributes -->
    <el-collapse accordion>
      <el-collapse-item title="Attributes" name="1">
        <el-input
          v-model="input1"
          :placeholder="att.getName()"
          v-for="att in getAttributes"
          :key="att.getName"
          :value="att.getValue()"
          disabled
        >
          <template #prepend>{{ att.getName() }}</template>
        </el-input>
      </el-collapse-item>

      <!-- * Credentials -->
      <!-- *! Need to add collapse in collapse for all credential attributes -->
      <el-collapse-item title="Credentials" name="2">
        <el-input
          v-model="input1"
          :placeholder="att.getName()"
          v-for="att in getAttributes"
          :key="att.getName"
          :value="att.getValue()"
          disabled
        >
          <template #prepend>{{ att.getName() }}</template>
        </el-input>
      </el-collapse-item>
    </el-collapse>
  </div>

  <div class="nav">
    <el-page-header content="Profile" @back="goback" />
  </div>
</template>

<style lang="scss">
.info {
  width: 98vw;
  margin-left: auto;
  margin-right: auto;
  margin-top: 2vh;
}

.id {
  background-color: black;
  color: white;
}
.nav {
  width: 99vw;
  padding: 4%;
  position: fixed;
  bottom: 0vh;
  backdrop-filter: hue-rotate(30deg);
  border-radius: 5px;
}
</style>
