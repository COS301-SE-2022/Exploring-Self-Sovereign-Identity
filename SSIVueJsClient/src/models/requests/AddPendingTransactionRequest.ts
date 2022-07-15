import type { Transaction } from "../entity/Transaction";

export class AddPendingTransactionRequest {

    public constructor(transaction: Transaction) {
        this.transaction = transaction;
    }
    
    private transaction : Transaction;
}