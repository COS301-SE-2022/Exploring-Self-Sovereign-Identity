<script lang="ts">
import BackNav from "../components/Nav/BackNav.vue";
import { defineComponent } from "vue";
import { userDataStore } from "@/stores/userData";
export default defineComponent({
  setup() {
    const userData = userDataStore();

    return { userData };
  },
  data() {
    return {
      // id: ,
    };
  },
  components: { BackNav },
});
</script>

<template>
  <div class="info">
    <!-- * User ID -->
    <el-input
      v-model="userData.getId"
      placeholder="ID"
      disabled
      data-test-id="Profile id"
    >
      <template #prepend>ID</template>
    </el-input>

    <el-divider />

    <!-- * Attributes -->
    <el-collapse accordion>
      <el-collapse-item
        title="Attributes"
        name="1"
        data-test-id="attribute-header"
      >
        <!-- *! Need to make input editable -->
        <el-input
          :placeholder="att.name"
          v-for="att in userData.getAttributes"
          :key="att.name"
          :value="att.value"
          data-test-id="attribute"
        >
          <template #prepend>{{ att.name }}</template>
        </el-input>
      </el-collapse-item>

      <!-- * Credentials -->
      <el-collapse-item title="Credentials" name="2" data-test-id="cred-header">
        <!-- * Inner collapsables -->
        <el-collapse accordion class="innerCollapse">
          <el-collapse-item
            v-for="cred in userData.getCredentials"
            :key="cred.organization"
            :title="cred.organization"
            :name="cred.organization"
            data-test-id="cred-item"
          >
            <el-input
              :placeholder="att.name"
              v-for="att in cred.attributes"
              :key="att.name"
              :value="att.value"
              disabled
            >
              <template #prepend>{{ att.name }}</template>
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
