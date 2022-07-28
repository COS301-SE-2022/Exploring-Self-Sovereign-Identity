import axios from "axios";

export function getuserdata(userid: string) {
  //   const axios = require("axios");
  return axios
    .post(`/api/UserData/get`, {
      id: userid,
    })
    .then((response) => {
      console.log(response.data);
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
