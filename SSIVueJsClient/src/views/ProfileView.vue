<script lang="ts">
import { mapState } from "pinia";
import { UserDataStore } from "@/stores/UserDataStore";
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
      <el-collapse-item
        title="Attributes"
        name="1"
        data-test-id="attribute-header"
      >
        <!-- *! Need to make input editable -->
        <el-input
          :placeholder="att.getName()"
          v-for="att in getAttributes"
          :key="att.getName()"
          :value="att.getValue()"
          data-test-id="attribute"
        >
          <template #prepend>{{ att.getName() }}</template>
        </el-input>
      </el-collapse-item>

      <!-- * Credentials -->
      <el-collapse-item title="Credentials" name="2" data-test-id="cred-header">
        <!-- * Inner collapsables -->
        <el-collapse accordion class="innerCollapse">
          <el-collapse-item
            v-for="cred in getCredentials"
            :key="cred.getId()"
            :title="cred.getId()"
            :name="cred.getId()"
            data-test-id="cred-item"
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
