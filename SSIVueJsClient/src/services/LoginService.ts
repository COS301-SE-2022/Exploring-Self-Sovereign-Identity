import { LoginRequest } from "@/models/requests/LoginRequest";
import { LoginResponse } from "@/models/response/LoginResponse";
import axios from "axios";

export class LoginService {
  public async login(loginRequest: LoginRequest) {
    return await axios.post<LoginResponse>("localhost/", loginRequest);
  }
}
