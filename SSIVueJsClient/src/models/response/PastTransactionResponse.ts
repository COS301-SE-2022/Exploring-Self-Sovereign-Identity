import type { Transaction } from "../entity/Transaction";

export class PastTransactionResponse {

    public constructor(transactions: Transaction[]) {
        this.transactions = transactions;
    }
    

    public transactions : Transaction[];
}