<script lang="ts">
import { defineComponent } from "vue";
import IconAvatar from "../components/icons/IconAvatar.vue";
import IconPending from "../components/icons/IconPending.vue";
import IconPast from "../components/icons/IconPast.vue";
import IconFile from "../components/icons/IconFile.vue";
import { Passage, User } from "@passageidentity/passage-js";
import { UserService } from "../services/UserService";
import { RegisterRequest } from "../models/requests/RegisterRequest";
import { isNull } from "lodash";
export default defineComponent({
  setup() {
    const appid = "Q17Gza9k49k1ieI15r73xaQf";
    return { appid };
  },
  data() {
    return {};
  },
  methods: {
    goProfile() {
      this.$router.push({ path: "/profile" });
    },
    go(p: string) {
      this.$router.push({ path: p });
    },
  },
  components: { IconAvatar, IconPending, IconPast, IconFile },
  mounted() {
    const passage = new Passage(this.appid);
    const user = passage.getCurrentUser();
    user.getMetadata().then((Response) => {
      const userService = new UserService();
      if (!isNull(Response)) {
        //userService.register(new RegisterRequest("sudfhsd"));
        console.log("Should not be here");
      } else {
        user.updateMetadata({
          key: "This is a test",
          userid: "This is also a test",
        });
      }
      console.log(Response);
    });
  },
});
</script>

<template>
  <!-- * Row 1 -->
  <el-row :gutter="2" class="row">
    <el-col :span="12">
      <!-- * Profile page -->
      <el-card class="card" @click="go('profile')">
        <template #header>
          <div>
            <el-avatar :size="100" shape="square"
              ><IconAvatar class="icon"
            /></el-avatar>
          </div>
        </template>
        <h3>Profile</h3>
      </el-card>
    </el-col>

    <!-- * Pending transations -->
    <el-col :span="12">
      <el-card class="card" @click="go('pending')">
        <template #header>
          <div>
            <el-avatar :size="100" shape="square">
              <IconPending class="icon"
            /></el-avatar>
          </div>
        </template>
        <h3>Pending</h3>
      </el-card>
    </el-col>
  </el-row>

  <!-- *Row 2 -->
  <el-row :gutter="2" class="row">
    <!-- *Past transactions -->
    <el-col :span="12">
      <el-card class="card" @click="go('past')">
        <template #header>
          <div>
            <el-avatar :size="100" shape="square">
              <IconPast class="icon"
            /></el-avatar>
          </div>
        </template>
        <h3>Past</h3>
      </el-card>
    </el-col>

    <!-- * Request data -->
    <el-col :span="12">
      <el-card class="card" @click="go('request')">
        <template #header>
          <div>
            <el-avatar :size="100" shape="square">
              <IconFile class="icon"
            /></el-avatar>
          </div>
        </template>
        <h3>Request data</h3>
      </el-card>
    </el-col>
  </el-row>
</template>

<style lang="scss">
.icon {
  background-color: white;
}
.card {
  // width: fit-content;
  text-align: center;
}
.row {
  margin-bottom: 1vw;
}
</style>
