import { defineStore } from "pinia";
import { userDataStore } from "@/stores/userData";
import axios from "axios";
import { ref } from "vue";

export const transactionsStore = defineStore("transactions", () => {
  const api = axios.create({
    baseURL: "http://localhost:5000",
    timeout: 20000,
    headers: {
      "Content-Type": "application/json",
    },
  });
  const userData = userDataStore();
  const requests = ref(
    userData.user.transactionRequests as unknown as transactionRequests[]
  );
  const approved = ref(userData.user.approvedTransactions);

  function approveTransaction(id: string) {
    api
      .post("/api/UserData/approveTransaction", {
        id: id,
        index: 0,
      })
      .then((response) => {
        if (response.data == "success") return true;
        else return false;
      })
      .catch((error) => {
        console.log(error);
      });
  }

  function declineTransaction(id: string) {
    api
      .post("/api/UserData/declineTransaction", {
        id: id,
        index: 0,
      })
      .then((response) => {
        if (response.data == "success") return true;
        else return false;
      })
      .catch((error) => {
        console.log(error);
      });
  }

  function newTransaction(toID: string, message: string, attributes: string[]) {
    api
      .post("/api/UserData/newTransaction", {
        attributes: attributes,
        stamp: {
          fromID: userData.getId,
          toID: toID,
          date: "",
          message: message,
          status: "",
        },
      })
      .then((response) => {
        if (response.data == "success") return true;
        else return false;
      })
      .catch((error) => {
        console.log(error);
      });
  }

  function exists(att: string) {
    const value =
      userData.getAttributes.find((x) => x.attribute.name == att) != undefined;
    if (value == undefined) return "";
    else return value;
  }

  return {
    api,
    userData,
    requests,
    approved,
    approveTransaction,
    declineTransaction,
    newTransaction,
    exists,
  };
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
