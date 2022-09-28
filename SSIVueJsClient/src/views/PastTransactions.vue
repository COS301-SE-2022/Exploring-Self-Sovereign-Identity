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
  components: { BackNav },
});
</script>

<template>
  <div>
    <n-collapse accordion arrow-placement="right">
      <n-card>
        <n-collapse-item
          v-for="t in transactions.past"
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
            <n-input :key="att" :default-value="att" readonly />
          </n-input-group>
        </n-collapse-item>
      </n-card>
    </n-collapse>
  </div>
  <BackNav page="Past Transactions" />
</template>

<style lang="scss"></style>
