import { defineStore } from "pinia";
import { userDataStore } from "@/stores/userData";
import axios from "axios";
import { computed, ref } from "vue";

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
  const approved = ref(
    userData.user.approvedTransactions as unknown as approvedTransactions[]
  );

  function approveTransaction(id: string, index: number) {
    api
      .post("/api/UserData/approveTransaction", {
        id: id,
        index: index,
      })
      .then((response) => {
        if (response.data == "success") return true;
        else return false;
      })
      .catch((error) => {
        console.log(error);
      });
  }

  function declineTransaction(id: string, index: number) {
    api
      .post("/api/UserData/declineTransaction", {
        id: id,
        index: index,
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

  const pending = computed(() => {
    return requests.value.filter((x) => x.stamp.status == "pending");
  });

  const past = computed(() => {
    return requests.value.filter(
      (x) => x.stamp.status == "approved" || x.stamp.status == "declined"
    );
  });

  return {
    api,
    userData,
    requests,
    approved,
    approveTransaction,
    declineTransaction,
    newTransaction,
    exists,
    pending,
    past,
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
