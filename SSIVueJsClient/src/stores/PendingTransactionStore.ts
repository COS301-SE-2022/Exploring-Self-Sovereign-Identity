import { Transaction } from "@/models/entity/Transaction";
import { PropType } from "@vue/runtime-core";
import { defineStore } from "pinia";

export const PendingTransactionsStore = defineStore(
  "pendingTransactionsStore",
  {
    state: () => {
      return {
        transactions: Array as PropType<Transaction[]>,
      };
    },
    getters: {
      getPendingTransactions(state) {
        return state.transactions;
      },
    },
    actions: {
      setTransactions(transactions: Transaction[]) {
        transactions.forEach((t) => {
          this.transactions.push(t);
        });
      },
    },
  }
);
