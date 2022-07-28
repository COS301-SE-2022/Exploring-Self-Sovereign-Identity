export class FetchPendingTransactionRequest {
  public constructor(userID: string) {
    this.userID = userID;
  }

  private userID: string;
}
