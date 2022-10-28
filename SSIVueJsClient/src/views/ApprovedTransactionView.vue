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
    const description = ref("Fetching user data...");
    return { transactions, userData, loading, description };
  },
  components: { BackNav },
  async mounted() {
    await this.userData.getuserdata().then(async() => {
      await this.transactions.sync();
        this.loading = false;

    });
  },
});
</script>

<template>
  <n-spin :show="loading" :description="description">
    <div>
      <n-card
        v-if="
          transactions.approvedTransactions.length == 0 ||
          transactions.approvedTransactions === undefined
        "
      >
        <n-empty
          size="large"
          description="No transactions to be shown..."
        ></n-empty>
      </n-card>

      <n-collapse accordion arrow-placement="right" v-else>
        <n-card>
          <n-collapse-item
            v-for="t in transactions.approved"
            :key="t.stamp.toID"
            :name="t.stamp.toID"
            :title="t.stamp.toID"
          >
            <template #header-extra>{{ t.stamp.date }}</template>
            <n-input-group
              v-for="att in t.attributes"
              :key="att.name"
              data-test-id="attribute"
            >
              <n-input-group-label>{{ att.name }}</n-input-group-label>
              <n-input :key="att" :default-value="att.value" readonly />
            </n-input-group>
          </n-collapse-item>
        </n-card>
      </n-collapse>
    </div>
    <BackNav page="Past Transactions" />
  </n-spin>
</template>

<style lang="scss"></style>
