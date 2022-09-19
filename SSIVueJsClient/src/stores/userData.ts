import { defineStore } from "pinia";
import axios from "axios";
import { getuserdata } from "@/services/UserDataService";
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
    attributes: { attributes: [] } as Attributes,
  }),
  getters: {
    getId: (state) => {
      return state.user.id;
    },
    getAttributes: (state) => {
      return state.attributes.attributes || [];
    },
    getCredentials: (state) => {
      return state.user.credentials;
    },
  },
  actions: {
    getuserdata(userid: string) {
      //   const axios = require("axios");
      console.log("id", userid);
      const repsonse = this.api
        .post(`/api/UserData/get`, {
          id: userid,
        })
        .then((response) => {
          if (response.data) {
            console.log("response");
            this.user.id = response.data.returnValue1.id;
            this.user.attributes = response.data.returnValue1.attributes;
            this.user.credentials = response.data.returnValue1.credentials;
            this.user.transactionRequests =
              response.data.returnValue1.transactionRequests;
            this.user.approvedTransactions =
              response.data.returnValue1.approvedTransactions;
            console.log("get user data", userid);
            console.log("getuserdata", response.data);
            console.log("getuserdata", this.user);

            this.sync();
          }
        })
        .catch((error) => {
          console.log(error);
        });
      return repsonse;
    },
    setuserdata() {
      // console.log(this.user);
      const response = this.api
        .post(`/api/UserData/update`, {
          attributes: this.attributes.attributes,
        })
        .then((response) => {
          this.user = response.data;
        })
        .catch((error) => {
          console.log(error);
        });
      return response;
    },
    createUser(id: string) {
      console.log("createUser", id);
      const response = this.api
        .post("/api/UserData/create", {
          id: id,
        })
        .then((response) => {
          const suc = "success";
          if ((response.data = suc)) {
            getuserdata(id);
            console.log("User", this.user);
          } else console.log("User not created");
        })
        .catch((error) => {
          console.log(error);
        });
      return response;
    },
    sync() {
      if (!this.user.attributes) return;
      for (let i = 0; i < this.user.attributes.length; i++) {
        this.attributes.attributes[i].attribute = this.user.attributes[i];
        this.attributes.attributes[i].index = i;
      }
    },
    exists() {
      return this.user.id != undefined;
    },
  },
});
export interface User {
  id: string;
  attributes: [
    {
      name: string;
      value: string;
      index: number;
    }
  ];
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
  transactionRequests: [
    {
      attributes: string;
      stamp: {
        fromID: string;
        toID: string;
        date: string;
        message: string;
        status: string;
      };
    }
  ];
  approvedTransactions: [
    {
      attributes: [
        {
          name: string;
          value: string;
        }
      ];
      stamp: {
        fromID: string;
        toID: string;
        date: string;
        message: string;
        status: string;
      };
    }
  ];
}
export interface Attributes {
  attributes: Array<Attribute>;
}

export interface Attribute {
  attribute: {
    name: string;
    value: string;
  };
  index: number;
}
