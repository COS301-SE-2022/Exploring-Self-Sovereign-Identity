<script lang="ts">
import { defineComponent, ref } from "vue";
import BackNav from "../components/Nav/BackNav.vue";
import {
  transactionsStore,
  type transactionRequests,
} from "@/stores/transactions";
import { userDataStore } from "@/stores/userData";

export default defineComponent({
  setup() {
    const transactions = transactionsStore();
    const userData = userDataStore();
    const arr = new Map<string, string>();
    const loading = ref(false);
    const description = ref("");
    return { transactions, arr, userData, loading, description };
  },
  methods: {
    exists(att: string) {
      const value = this.transactions.exists(att);
      if (value) {
        return value;
      } else {
        this.arr.set(att, "");
        return "";
      }
    },
    update(value: string, index: string) {
      console.log(index, value);
      this.arr.set(index, value);
    },
    async updateUser() {
      let changed = false;
      if (this.arr.size == 0) return;
      for (let [key, value] of this.arr) {
        if (value != "") {
          console.log("here");
          console.log(key, value);
          await this.userData.attributes.attributes.push({
            attribute: {
              name: key,
              value: value,
            },
            index: -1,
          });
          changed = true;
        } else {
          // * fix empty checks
          console.log("empty");
        }
      }
      console.log("here2");
      if (changed) {
        console.log("changed");
        await this.userData.setuserdata();
      }
      console.log("done");
    },
    async decline(index: transactionRequests) {
      this.description = "Declining transaction...";
      this.loading = true;
      await this.transactions.declineTransaction(this.userData.getId, index);
      this.loading = false;
    },
    async approve(index: transactionRequests) {
      this.description = "Approving transaction...";
      this.loading = true;
      await this.updateUser();
      await this.transactions.approveTransaction(this.userData.getId, index);
      this.loading = false;
    },
  },
  components: { BackNav },
});
</script>

<template>
  <n-spin :show="loading" :description="description">
    <n-collapse accordion arrow-placement="right">
      <n-collapse-item
        v-for="t in transactions.pending"
        :key="t.stamp.fromID"
        :name="t.stamp.fromID"
        :title="t.stamp.fromID"
      >
        <template #header-extra>{{ t.stamp.date }}</template>
        <n-input-group
          v-for="att in t.attributes"
          :key="att"
          data-test-id="attribute"
        >
          <n-input-group-label>{{ att }}</n-input-group-label>
          <n-input
            :key="att"
            :default-value="exists(att)"
            :readonly="transactions.exists(att) != ''"
            @input="update($event, att)"
          ></n-input>
        </n-input-group>
        <n-space>
          <n-button @click="decline(t)"> Decline </n-button>
          <n-button type="primary" @click="approve(t)"> Approve </n-button>
        </n-space>
      </n-collapse-item>
    </n-collapse>
    <BackNav page="Request Data" />
  </n-spin>
</template>

<style lang="scss"></style>
