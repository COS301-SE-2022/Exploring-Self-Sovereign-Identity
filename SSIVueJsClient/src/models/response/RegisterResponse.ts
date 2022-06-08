export class RegisterResponse {

    public constructor(userID: String, key: String) {
        this.userID = userID;
        this.key = key;
    }

    private userID : String;
    private key : String;
}