<script lang="ts">
import { defineComponent, ref } from "vue";
import BackNav from "../components/Nav/BackNav.vue";
import { transactionsStore } from "@/stores/transactions";
import { userDataStore } from "@/stores/userData";

export default defineComponent({
  setup() {
    const transactions = transactionsStore();
    const userData = userDataStore();
    const loading = ref(true);
    const arr = new Map<string, string>();
    return { transactions, arr, userData, loading };
  },
  components: { BackNav },
  async mounted() {
    this.loading = true;
    await this.userData.getuserdata().then(() => {
      this.loading = false;
    })
    .catch(() => {
      // * deal with error
    });
  },
  },
);
</script>

<template>
  <n-skeleton
    v-if="loading"
    :sharp="false"
    size="medium"
    :repeat="5"
    height="6vh"
    width="99vw"
  />
  <div v-else>
    <n-card v-if="transactions.past.length === 0 || !transactions.past">
      <n-empty
        size="large"
        description="No transactions to be shown..."
      ></n-empty>
    </n-card>

    <n-collapse accordion arrow-placement="right" v-else>
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
