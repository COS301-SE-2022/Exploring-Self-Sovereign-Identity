<script lang="ts">
import { defineComponent, ref } from "vue";
import IconAvatar from "../components/icons/IconAvatar.vue";
import IconPending from "../components/icons/IconPending.vue";
import IconPast from "../components/icons/IconPast.vue";
import IconFile from "../components/icons/IconFile.vue";
import { userDataStore } from "@/stores/userData";
import { PassageUser } from "@passageidentity/passage-elements/passage-user";

export default defineComponent({
  setup() {
    const loading = ref(true);
    const description = ref("Fetching user data...");
    const userData = userDataStore();
    const user = new PassageUser();
    user.userInfo().then(async (info) => {
      await userData.getuserdata(info?.email || "");
      console.log("here", userData.getId);
      if (!userData.exists()) {
        await userData.createUser(info?.email || "");
        console.log("User created");
      } else {
        console.log("User data fetched", userData.$state);
      }
      loading.value = false;
      description.value = "";
    });
    return { userData, loading, description };
  },
  // data() {
  //   return {};
  // },
  methods: {
    goProfile() {
      this.$router.push({ path: "/profile" });
    },
    go(p: string) {
      this.$router.push({ path: p });
    },
  },
  components: { IconAvatar, IconPending, IconPast, IconFile },
  // mounted() {
  //   this.userData.getuserdata("aaa");
  // },
});
</script>

<template>
  <n-spin :show="loading" :description="description">
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
  </n-spin>
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
