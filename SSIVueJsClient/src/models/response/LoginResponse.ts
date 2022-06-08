import type { UserData } from "../entity/UserData";

export class LoginResponse {
  public constructor(userData: UserData) {
    this.userData = userData;
  }

  public getUserData(): UserData {
    return this.userData;
  }

  private userData: UserData;
}
