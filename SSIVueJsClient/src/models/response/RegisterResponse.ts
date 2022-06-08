export class RegisterResponse {

    public constructor(userID: String, key: String) {
        this.userID = userID;
        this.key = key;
    }

    public getUserID() : String { return this.userID; }
    public getKey() : String { return this.key; }

    private userID : String;
    private key : String;
}