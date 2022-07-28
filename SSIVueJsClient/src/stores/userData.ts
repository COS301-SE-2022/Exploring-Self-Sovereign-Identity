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
    user: {
      id: "",
      attributes: [{ name: "", value: "", index: 0 }],
      credentials: [
        {
          organization: "",
          attributes: [
            {
              name: "",
              value: "",
            },
            {
              name: "",
              value: "",
            },
          ],
        },
      ],
    },
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
      // console.log(this.user);
      this.api
        .post(`/api/UserData/updateAttribute`, {
          id: this.user.id,
          attributes: this.user.attributes,
          credentials: this.user.credentials,
        })
        .then((response) => {
          this.user = response.data;
        })
        .catch((error) => {
          console.log(error);
        });
    },
  },
});

// post:
// /api/UserData/get

// Request:
// {
//      "id" : "aaa"
// }

// Response:
// {
//   "id": "aaa",
//   "attributes": [
//     {
//       "name": "name",
//       "value": "Johan"
//     },
//     {
//       "name": "surname",
//       "value": "Smit"
//     },
//     {
//       "name": "age",
//       "value": "21"
//     }
//   ],
//   "credentials": [
//     {
//       "organization": "Google",
//       "attributes": [
//         {
//           "name": "email",
//           "value": "JohanSmit@gmail.com"
//         },
//         {
//           "name": "number",
//           "value": "0823255012"
//         }
//       ]
//     }
//   ]
// }
