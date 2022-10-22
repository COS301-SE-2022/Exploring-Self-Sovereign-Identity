import { PassageUser } from "@passageidentity/passage-elements/passage-user";
import { defineStore } from "pinia";
import axios from "axios";
import { ref } from "vue";
import { Unknown } from "@vicons/carbon";
export const userDataStore = defineStore("userData", {
  state: () => ({
    api: axios.create({
      baseURL: "https://ssi-api.azurewebsites.net",
      timeout: 20000,
      headers: {
        "Content-Type": "application/json",
      },
    }),
    user: {} as User,
    attributes: { attributes: [] } as Attributes,
    loading: ref(false),
    description: ref(""),
    passage: "" as any,
  }),
  getters: {
    getId: (state) => {
      if (!state.user) return undefined;
      return state.user.id;
    },
    getAttributes: (state) => {
      if (!state.attributes) return undefined;
      return state.attributes.attributes || [];
    },
    getCredentials: (state) => {
      if (!state.user) return undefined;
      return state.user.credentials;
    },
  },
  actions: {
    async getuserdata() {
      const userid = this.passage;
      console.log("ID", userid);
      const repsonse = this.api
        .post(`/api/UserData/get`, {
          id: userid,
        })
        .then(async (response) => {
          if (response.data) {
            // this.user = response.data.returnValue1;
            this.$patch({ user: response.data.returnValue1 });
            this.sync();
            if (!this.user) {
              await this.createUser(userid);
              this.getuserdata;
            }
          }
        })
        .catch((error) => {
          console.log("get data", error);
        });
      console.log("Fetching user data", this.$state.loading);
      return repsonse;
    },
    setuserdata() {
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
      console.log("Fetching user data", this.$state.loading);

      return response;
    },
    createUser(id: string | undefined) {
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
            this.getuserdata();
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
      if (!this.user) return;
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
