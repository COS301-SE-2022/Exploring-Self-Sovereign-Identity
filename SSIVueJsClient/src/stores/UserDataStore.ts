import { Attribute } from "@/models/entity/Attribute";
import { UserData } from "@/models/entity/UserData";
import { defineStore } from "pinia";

export const UserDataStore = defineStore("userData", {
    state: () => {
        return {
            userData: new UserData("","",0,[],[])
        }
    },
    getters: {
        userData(state) {
            return state.userData;
        }
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
        }
    }
});