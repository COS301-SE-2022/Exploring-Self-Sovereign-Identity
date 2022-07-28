<script lang="ts">
import BackNav from "../components/Nav/BackNav.vue";
import { mapState } from "pinia";
import { PendingTransactionsStore } from "@/stores/PendingTransactionStore";
import { defineComponent } from "vue";
import { Contract } from "@/models/entity/Contract";
// import { TransactionService } from "@/services/TransactionService";
import { UserDataStore } from "@/stores/UserDataStore";
export default defineComponent({
  data() {
    return {
      contract: Contract,
      transactions: [],
    };
  },
  created() {
    // var transactionService: TransactionService = new TransactionService();
    // this.transactions = transactionService.mockPastTransactions(
    // this.getUserData.getId()
    // );
    // console.log(
    // transactions.then((result) => {
    // return result;
    //})
    //);
  },
  components: { BackNav },
  computed: {
    ...mapState(PendingTransactionsStore, ["getPendingTransactions"]),
    ...mapState(UserDataStore, ["getUserData"]),
  },
  methods: {
    view(value: number) {
      this.$router.push({
        path: "/transaction?c=" + value,
      });
    },
  },
});
</script>

<template>
  <div>
    <el-card v-for="(t, index) in getPendingTransactions" :key="t.getFrom()">
      <template #header>
        <span class="from"> {{ t.getFrom() }}</span>
      </template>
      <div>
        <el-tag
          @click="view(index)"
          type="info"
          v-for="a in t.getContract().getAttributes()"
          :key="a.getName()"
          >{{ a.getName() }}</el-tag
        >
      </div>
    </el-card>
  </div>

  <BackNav page="Past Transactions" />
</template>

<style lang="scss">
.from {
  font-weight: bold;
}
</style>
