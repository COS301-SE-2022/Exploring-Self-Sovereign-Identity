import { Attribute } from "@/models/entity/Attribute";
import { Contract } from "@/models/entity/Contract";
import { Transaction } from "@/models/entity/Transaction";
import type { PropType } from "@vue/runtime-core";
import { defineStore } from "pinia";

export const PendingTransactionsStore = defineStore(
  "pendingTransactionsStore",
  {
    state: () => {
      return {
        //transactions: Array as PropType<Transaction[]>,
        transactions: new Array<Transaction>(
          new Transaction(
            new Contract([new Attribute("Name", "Name", "Jones")]),
            "You",
            "Google"
          )
        ),
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
