import { LoginCommand } from "@/commands/LoginCommand";
import { LoginResponse } from "@/models/response/LoginResponse";
import axios from "axios";

export class LoginService {
  public async login(loginCommand: LoginCommand) {
    return await axios.post<LoginResponse>("localhost/", loginCommand);
  }
}
