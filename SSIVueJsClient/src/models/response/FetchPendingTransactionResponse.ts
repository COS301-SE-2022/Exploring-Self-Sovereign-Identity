import type { Transaction } from "../entity/Transaction";

export class FetchPendingTransactionResponse {

    public constructor(transaction: Transaction) {
        this.transaction = transaction;
    }

    private transaction : Transaction;
}