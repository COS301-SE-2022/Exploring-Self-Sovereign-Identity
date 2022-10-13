export class PastTransactionsRequest {
  public constructor(userID: String) {
    this.userID = userID;
  }

  private userID: String;
}
