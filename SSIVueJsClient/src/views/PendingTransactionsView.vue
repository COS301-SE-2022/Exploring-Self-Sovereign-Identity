<script lang="ts">
import BackNav from "../components/Nav/BackNav.vue";
import { mapState } from "pinia";
import { PendingTransactionsStore } from "@/stores/PendingTransactionStore";
export default {
  components: { BackNav },
  computed: {
    ...mapState(PendingTransactionsStore, ["getPendingTransactions"]),
  },
};
</script>

<template>
  <div>
    <el-card v-for="t in getPendingTransactions" :key="t.getFrom()">
      <template #header>
        {{ t.getFrom() }}
      </template>
      <div>
        <el-tag
          class="ml-2"
          type="info"
          v-for="a in getPendingTransactions.getContract().getAttributes()"
          :key="a.getName()"
          >{{ a.getName() }}</el-tag
        >
      </div>
    </el-card>
  </div>

  <BackNav />
</template>
