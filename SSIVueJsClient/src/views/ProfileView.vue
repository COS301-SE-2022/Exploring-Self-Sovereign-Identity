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
  components: { BackNav },
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
        <el-collapse accordion class="collapse">
          <el-collapse-item
            title="Attributes"
            name="1"
            data-test-id="attribute-header"
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
.info-main {
  width: 100%;
  padding: 0% !important;
}
.collapse {
  width: 100%;
  border-radius: 10px;
}
</style>
