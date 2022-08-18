<script lang="ts">
import BackNav from "../components/Nav/BackNav.vue";
import { defineComponent } from "vue";
import { userDataStore } from "@/stores/userData";
import { ElMessage, ElMessageBox } from "element-plus";
import { ElLoading } from "element-plus";
import IconAvatar from "../components/icons/IconAvatar.vue";

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
  },
  components: { BackNav, IconAvatar },
});
</script>

<template>
  <div class="info">
    <!-- * User ID -->
    <el-container>
      <el-header>
        <el-input
          v-model="userData.getId"
          placeholder="ID"
          disabled
          data-test-id="Profile id"
        >
          <template #prepend>ID</template>
        </el-input>
      </el-header>

      <el-divider />
      <el-main class="info-main">
        <!-- * Attributes -->
        <el-collapse
          accordion
          class="collapse"
          style="background-color: rgba(0, 0, 0, 0)"
        >
          <el-collapse-item
            title="Attributes"
            name="1"
            data-test-id="attribute-header"
            style="background-color: rgba(0, 0, 0, 0)"
          >
            <el-form ref="formRef" label-width="120px" class="demo-dynamic">
              <!-- <el-form-item
            prop="email"
            label="Email"
            :rules="[
              {
                required: true,
                message: 'Please input email address',
                trigger: 'blur',
              },
              {
                type: 'email',
                message: 'Please input correct email address',
                trigger: ['blur', 'change'],
              },
            ]"
          > -->
              <el-input
                :placeholder="att.name"
                v-for="att in userData.getAttributes"
                :key="att.name"
                :value="att.value"
                v-model="att.value"
                data-test-id="attribute"
              >
                <template #prepend>{{ att.name }}</template>
              </el-input>
              <!-- </el-form-item> -->
              <el-form-item>
                <el-button @click="addAtt" plain>Add</el-button>
                <el-button type="primary" @click="submitForm">Submit</el-button>
              </el-form-item>
            </el-form>
          </el-collapse-item>

          <!-- * Credentials -->
          <el-collapse-item
            title="Credentials"
            name="2"
            data-test-id="cred-header"
            style="padding-top: 0.2vh"
          >
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
      </el-main>
    </el-container>
  </div>

  <!-- *Header -->
  <n-page-header title="Profile" subtitle="A podcast to improve designs">
    <template #avatar>
      <n-avatar>
        <n-icon>
          <IconAvatar style="background-color: rgba(0, 0, 0, 0)" />
        </n-icon>
      </n-avatar>
    </template>
  </n-page-header>
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
