import type { RegisterRequest } from "@/models/requests/RegisterRequest";
import type { RegisterResponse } from "@/models/response/RegisterResponse";
import type { LoginRequest } from "@/models/requests/LoginRequest";
import type { LoginResponse } from "@/models/response/LoginResponse";
import type { UpdateRequest } from "../models/requests/UpdateRequest";
import type { UpdateResponse } from "../models/response/UpdateResponse";
import axios from "axios";

export class UserService {

    public async register(registerRequest: RegisterRequest) : Promise<RegisterResponse> {
        return (await axios.post<RegisterResponse>("https://localhost:5000/user/register", registerRequest)).data;
    }

    public async login(loginRequest: LoginRequest) : Promise<LoginResponse> {
        return (await axios.post<LoginResponse>("https://localhost:5000/user/login", loginRequest)).data;
    }

    public async update(updateRequest: UpdateRequest) : Promise<UpdateResponse> {
        return (await axios.post<UpdateResponse>("https://localhost:5000/user/update", updateRequest)).data
    }
}