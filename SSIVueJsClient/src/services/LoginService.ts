import type { LoginRequest } from "@/models/requests/LoginRequest";
import type { LoginResponse } from "@/models/response/LoginResponse";
import axios from "axios";

export class LoginService {
  public async login(loginRequest: LoginRequest) : Promise<LoginResponse> {
    return await (await axios.post<LoginResponse>("https://localhost:5000/user/login", loginRequest)).data;
  }
}
