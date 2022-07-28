import type { Transaction } from "../entity/Transaction";

export class SaveTransactionRequest {

    public constructor(transaction: Transaction) {
        this.transaction = transaction;
    }

    private transaction : Transaction;
}