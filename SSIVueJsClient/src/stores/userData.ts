import { defineStore } from "pinia";
import axios from "axios";
export const userDataStore = defineStore("userData", {
  state: () => ({
    api: axios.create({
      baseURL: "http://localhost:5000",
      timeout: 10000,
      headers: {
        "Content-Type": "application/json",
      },
    }),
    user: {} as User,
  }),
  getters: {
    getId: (state) => {
      return state.user.id;
    },
    getAttributes: (state) => {
      return state.user.attributes || [];
    },
    getCredentials: (state) => {
      return state.user.credentials;
    },
  },
  actions: {
    getuserdata(userid: string) {
      //   const axios = require("axios");
      return this.api
        .post(`/api/UserData/get`, {
          id: userid,
        })
        .then((response) => {
          this.user = response.data;
        })
        .catch((error) => {
          console.log(error);
        });
    },
    setuserdata() {
      console.log(this.user);
      this.api
        .post(`/api/UserData/updateAttribute`, {
          id: this.user.id,
          attributes: this.user.attributes,
          credentials: this.user.credentials,
        })
        .then((response) => {
          console.log(response.data);
          this.user = response.data;
        })
        .catch((error) => {
          console.log(error);
        });
    },
    createUser() {
      this.api
        .post("api/create", "ahweihowehfowh")
        .then((response) => {
          const suc = "success";
          if ((response.data = suc)) this.user.id = "opxhdhposdhf";
        })
        .catch((error) => {
          console.log(error);
        });
    },
  },
});

export interface User {
  id: string;
  attributes: [{ name: string; value: string; index: number }];
  credentials: [
    {
      organization: string;
      attributes: [
        {
          name: string;
          value: string;
        }
      ];
    }
  ];
}
