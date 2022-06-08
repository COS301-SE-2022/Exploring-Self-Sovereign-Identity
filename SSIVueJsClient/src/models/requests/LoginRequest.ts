export class LoginRequest {
    public constructor(userID: string, key: string) {
        this.userID = userID;
        this.key = key;
    }

    private userID : string;
    private key : string;
}