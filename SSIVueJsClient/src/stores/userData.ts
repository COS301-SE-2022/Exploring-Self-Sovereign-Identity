import { defineStore } from "pinia";
import axios from "axios";
import { ref } from "vue";
export const userDataStore = defineStore("userData", {
  state: () => ({
    api: axios.create({
      baseURL: "https://api-manager-ssi.azure-api.net",
      timeout: 20000,
      headers: {
        "Content-Type": "application/json",
      },
    }),
    user: {} as User,
    attributes: { attributes: [] } as Attributes,
    loading: ref(false),
    description: ref(""),
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
      // this.$patch({ description: "Fetching user data..." });
      // this.$patch({ loading: true });
      console.log("Fetching user data", this.$state.loading);
      const repsonse = this.api
        .post(`/api/UserData/get`, {
          id: userid,
        })
        .then((response) => {
          if (response.data) {
            // this.user = response.data.returnValue1;
            this.$patch({ user: response.data.returnValue1 });
            this.sync();
          }
        })
        .catch((error) => {
          console.log(error);
        });
      // this.$patch({ loading: false });
      // this.$patch({ description: "" });
      console.log("Fetching user data", this.$state.loading);
      return repsonse;
    },
    setuserdata() {
      // this.$patch({ description: "Saving user data..." });
      // this.$patch({ loading: true });
      // console.log("Saving user data", this.$state.loading);
      // console.log(this.attributes.attributes[0].attribute.value);
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
      // this.$patch({ loading: false });
      // this.$patch({ description: "" });
      console.log("Fetching user data", this.$state.loading);

      return response;
    },
    createUser(id: string) {
      // this.$patch({ description: "Creating user..." });
      // this.$patch({ loading: true });
      // console.log("Creating user data", this.$state.loading);

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
      // this.$patch({ loading: false });
      // this.$patch({ description: "" });
      // console.log("Fetching user data", this.$state.loading);
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

    otp(value: string, otp: string) {
      const cred = this.user.credentials.find((c) => c.organization == value);
      const response = this.api
        .post("/api/Session/connect", {
          otp: otp,
          credential: cred,
        })
        .then((response) => {
          console.log("success", response.data);
        })
        .catch((error) => {
          console.log(error);
        });
      return response;
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
  credentials: {
    organization: string;
    attributes: {
      name: string;
      value: string;
    }[];
  }[];
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
