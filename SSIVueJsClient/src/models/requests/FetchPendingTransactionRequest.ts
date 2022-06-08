export class FetchPendingTransactionRequest {

    public constructor(userID: String) {
        this.userID = userID;
    }
    
    private userID : String;
}