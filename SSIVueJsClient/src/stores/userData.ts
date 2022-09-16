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
      return this.api
        .post(`/api/UserData/get`, {
          id: userid,
        })
        .then((response) => {
          console.log(response.data);
          if (response.data) {
            this.user = response.data;
            this.sync();
          }
        })
        .catch((error) => {
          console.log(error);
        });
    },
    setuserdata() {
      // console.log(this.user);
      this.api
        .post(`/api/UserData/update`, {
          attributes: this.attributes.attributes,
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
          console.log(this.user.id);
        })
        .catch((error) => {
          console.log(error);
        });
    },
    sync() {
      for (let i = 0; i < this.user.attributes.length; i++) {
        this.attributes.attributes[i].attribute = this.user.attributes[i];
        this.attributes.attributes[i].index = i;
      }
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
