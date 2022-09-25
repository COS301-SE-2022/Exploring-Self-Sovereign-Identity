<script lang="ts">
import { defineComponent } from "vue";
import BackNav from "../components/Nav/BackNav.vue";
import { transactionsStore } from "@/stores/transactions";
import { userDataStore } from "@/stores/userData";

export default defineComponent({
  setup() {
    const transactions = transactionsStore();
    const userData = userDataStore();
    const arr = new Map<string, string>();
    return { transactions, arr, userData };
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
    update(index: string, value: string) {
      this.arr.set(index, value);
    },
    updateUser() {
      if (this.arr.size == 0) return;
      for (let [key, value] of this.arr) {
        if (value != "") {
          this.userData.attributes.attributes.push({
            attribute: {
              name: key,
              value: value,
            },
            index: -1,
          });
        } else {
          // * fix empty checks
          console.log("empty");
        }
      }
      this.userData.setuserdata();
    },
    decline(index: number) {
      this.transactions.declineTransaction(this.userData.getId, index);
    },
    approve(index: number) {
      this.updateUser();
      this.transactions.approveTransaction(this.userData.getId, index);
    },
  },
  components: { BackNav },
});
</script>

<template>
  <n-collapse accordion arrow-placement="right">
    <n-collapse-item
      v-for="(t, index) in transactions.pending"
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
          :readonly="!transactions.exists(att)"
          @update="update(att, $event)"
        ></n-input>
      </n-input-group>
      <n-space>
        <n-button @click="decline(index)"> Decline </n-button>
        <n-button type="primary" @click="approve(index)"> Approve </n-button>
      </n-space>
    </n-collapse-item>
  </n-collapse>
  <BackNav page="Request Data" />
</template>

<style lang="scss"></style>
