<script lang="ts">
import { defineComponent } from "vue";
import IconAvatar from "../components/icons/IconAvatar.vue";
import IconPending from "../components/icons/IconPending.vue";
import IconPast from "../components/icons/IconPast.vue";
import IconFile from "../components/icons/IconFile.vue";
import { Passage } from "@passageidentity/passage-js";
// import { getuserdata } from "@/services/UserDataService";
import { userDataStore } from "@/stores/userData";

// import { UserService } from "../services/UserService";
// import { RegisterRequest } from "../models/requests/RegisterRequest";
import { isNull } from "lodash";
export default defineComponent({
  setup() {
    const appid = "Q17Gza9k49k1ieI15r73xaQf";
    // getuserdata("orhfaoiuhosdhgosir");
    const userData = userDataStore();
    return { appid, userData };
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
    //Passage store
    const passage = new Passage(this.appid);
    const user = passage.getCurrentUser();
    user.getMetadata().then((Response) => {
      // const userService = new UserService();
      if (!isNull(Response)) {
        //userService.register(new RegisterRequest("sudfhsd"));
        console.log("Should not be here");
      } else {
        user.updateMetadata({
          key: "This is a test",
          userid: "This is also a test",
        });
      }
      // console.log(Response);
    });
  },
});
</script>

<template>
  <!-- *Row 1 -->
  <n-grid
    cols="2"
    responsive="screen"
    x-gap="5"
    y-gap="5"
    :item-responsive="true"
  >
    <n-gi>
      <n-card
        title="Profile"
        @click="go('profile')"
        data-test-id="profile"
        :bordered="false"
      >
        <template #cover>
          <IconAvatar class="icon card" />
        </template>
      </n-card>
    </n-gi>
    <n-gi>
      <n-card
        title="Pending"
        @click="go('pending')"
        data-test-id="pending"
        :bordered="false"
      >
        <template #cover>
          <IconPending class="icon card" />
        </template>
      </n-card>
    </n-gi>
    <!-- </n-grid> -->
    <!-- *Row 2 -->
    <!-- <n-grid cols="2" responsive="screen"> -->
    <n-gi>
      <n-card
        title="Past"
        @click="go('past')"
        data-test-id="past"
        :bordered="false"
      >
        <template #cover>
          <IconPast class="icon card" />
        </template>
      </n-card>
    </n-gi>
    <n-gi>
      <n-card
        title="Request data"
        @click="go('request')"
        data-test-id="request"
        :bordered="false"
      >
        <template #cover>
          <IconFile class="icon card" />
        </template>
      </n-card>
    </n-gi>
  </n-grid>
</template>

<style lang="scss">
.icon {
  background-color: rgba(255, 255, 255, 0);
  height: auto;
  width: auto;
  max-width: 25vw;
}
.n-card {
  // width: fit-content;
  text-align: center;
  background: rgba(255, 255, 255, 0.53);
  border-radius: 16px;
  box-shadow: 0 4px 30px rgba(0, 0, 0, 0.1);
  backdrop-filter: blur(12.7px);
  -webkit-backdrop-filter: blur(12.7px);
}
.n-grid {
  margin-top: 1vh;
}
</style>
