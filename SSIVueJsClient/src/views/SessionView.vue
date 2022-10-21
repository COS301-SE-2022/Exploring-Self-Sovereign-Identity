<script lang="ts">
import { userDataStore } from "@/stores/userData";
import { defineComponent, ref } from "vue";

export default defineComponent({
  setup() {
    const otp = ref("");
    const loading = ref(false);
    const description = ref("");
    const cred = ref("");

    const userData = userDataStore();
    const options = ref([] as { label: string; value: string }[]);
    for (let x of userData.getCredentials)
      options.value.push({ label: x.organization, value: x.organization });
    return { otp, loading, description, cred, userData, options };
  },
  async mounted() {
    this.loading = true;
    this.description = "Fetching user data...";
    await this.userData
      .getuserdata()
      .then(() => {
        this.loading = false;
      })
      .catch(() => {
        this.loading = false;
      });
  },
  methods: {
    async request() {
      this.userData.otp(this.cred, this.otp);
    },
  },
});
</script>

<template>
  <n-spin :show="loading" :description="description">
    <n-card>
      <n-input-group data-test-id="OTP">
        <n-input-group-label>OTP</n-input-group-label>
        <n-input placeholder="Please enter OTP" v-model:value="otp"></n-input>
      </n-input-group>
      <n-select
        v-model:value="cred"
        filterable
        placeholder="Please select a credential"
        :options="options"
      />
    </n-card>

    <BackNav page="Request Data">
      <n-button type="primary" @click="request"> Connect </n-button>
    </BackNav>
  </n-spin>
</template>

<style lang="scss"></style>
