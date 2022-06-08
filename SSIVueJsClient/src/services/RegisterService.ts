import type { RegisterRequest } from "@/models/requests/RegisterRequest";
import type { RegisterResponse } from "@/models/response/RegisterResponse";
import axios from "axios";

export class RegisterService {

    public async register(registerRequest: RegisterRequest) : Promise<RegisterResponse> {
        return await (await axios.post<RegisterResponse>("https://localhost:5000/user/register", registerRequest)).data;
    }
}