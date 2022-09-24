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
    return { attrributes, id, message, transactions };
  },
  methods: {
    request() {
      this.transactions.newTransaction(this.id, this.message, this.attrributes);
      this.$router.go(0);
    },
  },
  components: { BackNav },
});
</script>

<template>
  <n-input-group data-test-id="UserId">
    <n-input-group-label>User ID</n-input-group-label>
    <n-input placeholder="Please enter user ID" v-model="id"></n-input>
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
      v-model="id"
      maxlength="200"
      show-count
      type="textarea"
    ></n-input>
  </n-input-group>

  <BackNav>
    <n-button type="primary" @click="request"> Request </n-button>
  </BackNav>
</template>
