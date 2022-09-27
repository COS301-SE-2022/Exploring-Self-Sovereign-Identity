import { defineStore } from "pinia";
import { userDataStore } from "@/stores/userData";
import axios from "axios";
import { computed, ref } from "vue";

export const transactionsStore = defineStore("transactions", () => {
  const api = axios.create({
    baseURL: "https://ssi-api.azurewebsites.net",
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

  async function approveTransaction(id: string, request: transactionRequests) {
    const index = requests.value.findIndex(
      (x) => JSON.stringify(x) === JSON.stringify(request)
    );
    console.log(index);
    const response = api
      .post("/api/UserData/approveTransaction", {
        id: id,
        index: index,
      })
      .then((response) => {
        if (response.data == "success") {
          requests.value[index].stamp.status = "approved";
          return true;
        } else return false;
      })
      .catch((error) => {
        console.log(error);
      });
    return response;
  }

  async function declineTransaction(id: string, request: transactionRequests) {
    const index = requests.value.findIndex(
      (x) => JSON.stringify(x) === JSON.stringify(request)
    );
    const response = api
      .post("/api/UserData/declineTransaction", {
        id: id,
        index: index,
      })
      .then((response) => {
        if (response.data == "success") {
          requests.value[index].stamp.status = "declined";
          return true;
        } else return false;
      })
      .catch((error) => {
        console.log(error);
      });
    return response;
  }

  async function newTransaction(
    toID: string,
    message: string,
    attributes: string[]
  ) {
    const response = api
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
    return response;
  }

  function exists(att: string) {
    const val = userData.getAttributes.find((x) => x.attribute.name == att)
      ?.attribute.value;
    if (val == undefined) return "";
    else return val;
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
