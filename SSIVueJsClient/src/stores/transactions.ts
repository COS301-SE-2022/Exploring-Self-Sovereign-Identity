import { defineStore } from "pinia";
import { userDataStore } from "@/stores/userData";
import axios from "axios";

export const transactionsStore = defineStore("transactions", () => {
  const api = axios.create({
    baseURL: "http://localhost:5000",
    timeout: 20000,
    headers: {
      "Content-Type": "application/json",
    },
  });
  const userData = userDataStore();

  return { api, userData };
});

export interface transactionRequests {
  attributes: string[];
  stamp: {
    fromID: string;
    toID: string;
    date: string;
    message: string;
    status: string;
  };
}
[];

export interface approvedTransactions {
  attributes: {
    name: string;
    value: string;
  }[];
  stamp: {
    fromID: string;
    toID: string;
    date: string;
    message: string;
    status: string;
  };
}
[];
