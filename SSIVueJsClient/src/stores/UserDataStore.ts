import { Attribute } from "@/models/entity/Attribute";
import { OrganizationCredentials } from "@/models/entity/OrganizationCredentials";
import { UserData } from "@/models/entity/UserData";
import { defineStore } from "pinia";

export const UserDataStore = defineStore("userData", {
  state: () => {
    return {
      userData: new UserData(
        "748fg834egw4",
        "Jones117",
        0,
        [
          new Attribute("Name", "Name", "Jones"),
          new Attribute("Surname", "Surname", "Jones"),
          new Attribute("Number", "Number", "0274839183"),
          new Attribute("Email", "Email", "jones@jones.jojo"),
        ],
        [
          new OrganizationCredentials("Google", [
            new Attribute("Name", "Name", "Jones"),
            new Attribute("Surname", "Surname", "Jones"),
          ]),
          new OrganizationCredentials("Proton", [
            new Attribute("Name", "Name", "Jones"),
            new Attribute("Surname", "Surname", "Jones"),
          ]),
        ]
      ),
    };
  },
  getters: {
    getUserData(state) {
      return state.userData;
    },
  },
  actions: {
    setUserData(userData: UserData) {
      this.userData = new UserData(
        userData.getHash(),
        userData.getId(),
        userData.getVersion(),
        userData.getAttributes(),
        userData.getCredentials()
      );
    },
  },
});
