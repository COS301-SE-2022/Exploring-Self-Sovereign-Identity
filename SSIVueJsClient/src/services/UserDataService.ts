import axios from "axios";
import type { JsonObject } from "type-fest";

export function getuserdata(userid: string): Promise<UserData> {
  //   const axios = require("axios");
  return axios
    .post(`/api/UserData/get`, {
      id: userid,
    })
    .then((response) => {
      response.id = null;
    });
}

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
