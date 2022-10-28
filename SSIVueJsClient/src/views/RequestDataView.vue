<script lang="ts">
import { transactionsStore } from "@/stores/transactions";
import { defineComponent, ref } from "vue";
import BackNav from "../components/Nav/BackNav.vue";

export default defineComponent({
  setup() {
    const transactions = transactionsStore();
    const attrributes = ref([""]);
    const id = ref("");
    const message = ref("");
    const loading = ref(false);
    const description = ref("Sending request...");
    return { attrributes, id, message, transactions, loading, description };
  },
  methods: {
    async request() {
      console.log("Requesting data", this.id);
      this.loading = true;
      await this.transactions
        .newTransaction(this.id, this.message, this.attrributes)
        .then(() => {
          this.$router.go(0);
          this.loading = false;
        });
    },
  },
  components: { BackNav },
});
</script>

<template>
  <n-spin :show="loading" :description="description">
    <n-card class="centre">
      <n-input-group data-test-id="UserId">
        <n-input-group-label>User ID</n-input-group-label>
        <n-input
          placeholder="Please enter user ID"
          v-model:value="id"
        ></n-input>
      </n-input-group>
      <n-dynamic-input
        v-model:value="attrributes"
        placeholder="Enter attribute name"
        :min="1"
      />
      <n-input-group data-test-id="Message">
        <n-input-group-label>Message</n-input-group-label>
        <n-input
          placeholder="Please enter request message for the user"
          v-model:value="message"
          maxlength="200"
          show-count
          type="textarea"
        ></n-input>
      </n-input-group>
    </n-card>

    <BackNav page="Request Data">
      <n-button type="primary" @click="request"> Request </n-button>
    </BackNav>
  </n-spin>
</template>

<style scoped lang="scss">
.centre {
  display: flex;
  // justify-content: center;
  // align-items: center;
  top: 20vh;
  height: 100%;
  padding-top: 5vh;
  padding-bottom: 5vh;
  * {
    margin-top: 0.5vh;
    margin-bottom: 0.5vh;
  }
}
</style>
