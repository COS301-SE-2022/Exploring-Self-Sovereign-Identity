<script lang="ts">
import { mapState } from "pinia";
import { UserDataStore } from "@/stores/UserDataStore";
import BackNav from "../components/Nav/BackNav.vue";
import { defineComponent } from "vue";
export default defineComponent({
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
  components: { BackNav },
});
</script>

<template>
  <div class="info">
    <!-- * User ID -->
    <el-input v-model="id" placeholder="ID" disabled data-test-id="Profile id">
      <template #prepend>ID</template>
    </el-input>

    <el-divider />

    <!-- * Attributes -->
    <el-collapse accordion>
      <el-collapse-item title="Attributes" name="1">
        <!-- *! Need to make input editable -->
        <el-input
          :placeholder="att.getName()"
          v-for="att in getAttributes"
          :key="att.getName()"
          :value="att.getValue()"
        >
          <template #prepend>{{ att.getName() }}</template>
        </el-input>
      </el-collapse-item>

      <!-- * Credentials -->
      <el-collapse-item title="Credentials" name="2">
        <!-- * Inner collapsables -->
        <el-collapse accordion class="innerCollapse">
          <el-collapse-item
            v-for="cred in getCredentials"
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
        </el-collapse>
      </el-collapse-item>
    </el-collapse>
  </div>

  <BackNav page="Profile" />
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
.innerCollapse {
  padding-left: 5vw;
}
</style>
