import { defineStore } from "pinia";
import axios from "axios";

export const transactionsStore = defineStore("transactions", {
  state: () => ({
    api: axios.create({
      baseURL: "http://localhost:5000",
      timeout: 20000,
      headers: {
        "Content-Type": "application/json",
      },
    }),
  }),
});
