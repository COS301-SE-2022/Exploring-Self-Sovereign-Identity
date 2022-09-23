import { defineStore } from "pinia";
import axios from "axios";
export const userDataStore = defineStore("userData", {
  state: () => ({
    api: axios.create({
      baseURL: "http://localhost:5000",
      timeout: 20000,
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
            this.user = response.data.returnValue1;
            this.sync();
          }
        })
        .catch((error) => {
          console.log(error);
        });
      return repsonse;
    },
    setuserdata() {
      console.log(this.attributes.attributes[0].attribute.value);
      const response = this.api
        .post(`/api/UserData/update`, {
          id: this.user.id,
          attributes: this.attributes.attributes,
          credentials: [],
        })
        .then((response) => {
          console.log(response.data);
          this.user = response.data.returnValue1;
        })
        .catch((error) => {
          console.log(error);
          throw error;
        });
      return response;
    },
    createUser(id: string) {
      const response = this.api
        .post("/api/UserData/create", {
          id: id,
        })
        .then((response) => {
          const suc = "success";
          if ((response.data = suc)) {
            this.getuserdata(id);
          } else console.log("User not created");
        })
        .catch((error) => {
          console.log(error);
        });
      return response;
    },
    sync() {
      if (!this.user.attributes) return;
      this.attributes.attributes.splice(0);
      for (let i = 0; i < this.user.attributes.length; i++) {
        this.attributes.attributes.push({
          attribute: {
            name: this.user.attributes[i].name,
            value: this.user.attributes[i].value,
          },
          index: i,
        });
      }
    },
    exists() {
      return this.user.id != "undefined";
    },
    updateAttribute(index: number, value: string) {
      this.attributes.attributes[index].attribute.value = value;
    },
  },
});

export interface User {
  id: string;
  attributes: [
    {
      name: string;
      value: string;
      // index: number;
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
  transactionRequests: {
    attributes: string;
    stamp: {
      fromID: string;
      toID: string;
      date: string;
      message: string;
      status: string;
    };
  }[];
  approvedTransactions: {
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
  }[];
}

export interface Attributes {
  attributes: {
    attribute: {
      name: string;
      value: string;
    };
    index: number;
  }[];
}
// export interface Attributes {
//   attributes: Array<Attribute>;
// }

// export interface Attribute {
//   attribute: {
//     name: string;
//     value: string;
//   };
//   index: number;
// }
