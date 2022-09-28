import { defineStore } from "pinia";
import { userDataStore } from "@/stores/userData";
import axios from "axios";
import { computed, reactive, ref } from "vue";

export const marketStore = defineStore("market", () => {
  const api = axios.create({
    baseURL: "https://ssi-api.azurewebsites.net",
    timeout: 20000,
    headers: {
      "Content-Type": "application/json",
    },
  });
  const userData = userDataStore();
  let markets = reactive({} as unknown as Market[]);

  async function approve(
    organization: string,
    dataPackID: string,
    attributes: {
      name: string;
      value: string;
    }[]
  ) {
    const response = api
      .post("/api/MarketPlace/buyData", {
        userID: userData.user.id,
        organization: organization,
        dataPackID: dataPackID,
        attributes: attributes,
      })
      .then((response) => {
        if (response.data == "success") {
          return true;
        } else return false;
      })
      .catch((error) => {
        console.log(error);
      });
    return response;
  }

  async function get() {
    const response = api
      .post("/api/MarketPlace/getAllOrganizations", {
        id: userData.user.id,
      })
      .then((response) => {
        markets = response.data.returnValue1;
      })
      .catch((error) => {
        console.log(error);
      });
    return response;
  }
  const getMarkets = computed(() => {
    return markets;
  });

  return { approve, get, markets, getMarkets };
});

export interface Market {
  organization: string;
  id: string;
  pricePerUnit: number;
  attributes: string[];
}
[];
