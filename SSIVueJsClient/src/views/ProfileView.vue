<script lang="ts">
import { mapState } from "pinia";
import { UserDataStore } from "@/stores/UserDataStore";
import { UserData } from "@/models/entity/UserData";
import type { Attribute } from "@/models/entity/Attribute";
export default {
  data() {
    return { id: "12gwbd83t823tdqwd" };
  },
  computed: {
    ...mapState(UserDataStore, ["getUserData"]),
    attributes(): Attribute {
      return this.getUserData.arguments.getAttributes;
    },
  },
};
</script>

<template>
  <div class="info">
    <!-- * User ID -->
    <el-input v-model="id" placeholder="ID">
      <template #prepend>ID</template>
    </el-input>

    <el-divider />
    <!-- * Attributes -->
    <el-collapse v-model="activeName" accordion>
      <el-collapse-item
        title="Consistency"
        name="1"
        v-for="att in attributes"
        :key="att.getName"
      >
        <p>temp</p>
      </el-collapse-item>
    </el-collapse>
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
</style>
