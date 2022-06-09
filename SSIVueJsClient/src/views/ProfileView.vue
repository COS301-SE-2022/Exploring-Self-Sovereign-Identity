<script lang="ts">
import { mapState } from "pinia";
import { UserDataStore } from "@/stores/UserDataStore";
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
        <!-- *! Need to make input editable -->
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
      <el-collapse-item title="Credentials" name="2">
        <!-- * Inner collapsables -->
        <el-collapse-item
          v-for="cred in getCredentials()"
          :key="cred.getId()"
          :title="cred.getId()"
          :name="cred.getId()"
        >
          <el-input
            :placeholder="att.getName()"
            v-for="att in cred.getCredentials()"
            :key="att.getName()"
            :value="att.getValue()"
            disabled
          >
            <template #prepend>{{ att.getName() }}</template>
          </el-input>
        </el-collapse-item>
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
