<script lang="ts">
import BackNav from "../components/Nav/BackNav.vue";
import { defineComponent } from "vue";
import { userDataStore } from "@/stores/userData";
import { ElMessage, ElMessageBox } from "element-plus";
import { ElLoading } from "element-plus";

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
  components: {
    BackNav,
  },
  methods: {
    addAtt() {
      ElMessageBox.prompt("Please enter attribute", "Tip", {
        confirmButtonText: "Add",
        cancelButtonText: "Cancel",
      })
        .then(({ value }) => {
          this.userData.user.attributes.push({
            name: value,
            value: "",
            index: -1,
          });
          ElMessage({
            type: "success",
            message: `Attribute added`,
          });
        })
        .catch(() => {
          ElMessage({
            type: "info",
            message: "Input canceled",
          });
        });
    },
    submitForm() {
      const load = ElLoading.service({
        fullscreen: true,
        text: "Submitting...",
      });
      this.userData.setuserdata();
      load.close();
      ElMessage({
        type: "success",
        message: `Profile updated`,
      });
    },
    goBack() {
      this.$router.back();
    },
  },
});
</script>

<template>
  <!-- * Naive tabs -->
  <n-tabs type="bar" size="large" justify-content="space-evenly">
    <n-tab-pane name="Attributes">
      <n-input-group
        v-for="att in userData.getAttributes"
        :key="att.attribute.name"
        data-test-id="attribute"
      >
        <n-input-group-label>{{ att.attribute.name }}</n-input-group-label>
        <n-input
          :value="att.attribute.value"
          v-model="att.attribute.value"
        ></n-input>
      </n-input-group>
    </n-tab-pane>

    <n-tab-pane name="Credentials">
      <n-collapse accordion>
        <n-collapse-item
          v-for="cred in userData.getCredentials"
          :key="cred.organization"
          :title="cred.organization"
        >
          <n-input-group
            v-for="att in cred.attributes"
            :key="att.name"
            data-test-id="attribute"
          >
            <n-input-group-label>{{ att.name }}</n-input-group-label>
            <n-input :value="att.value" v-model="att.value"></n-input>
          </n-input-group>
        </n-collapse-item>
      </n-collapse>
    </n-tab-pane>
  </n-tabs>

  <!-- * -->
  <BackNav page="Profile" />
</template>

<style lang="scss">
.icon {
  background-color: rgba(255, 255, 255, 0);
  height: auto;
  width: auto;
  max-width: 25vw;
}

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
.info-main {
  width: 100%;
  padding: 0% !important;
}
.collapse {
  // background-color: rgba(255, 255, 255, 0.5);
  width: 100%;
  border-radius: 5px;
  border-width: thin;
  div {
    // background-color: rgba(255, 255, 255, 0.5);
    border-radius: 5px;
    border-width: thin;
  }
}
</style>
