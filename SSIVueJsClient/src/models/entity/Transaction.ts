import type { Contract } from "./Contract";

export class Transaction {
    
    public constructor(contract: Contract, from: string, to: string) {
        this.contract = contract;
        this.from = from;
        this.to = to;
    }

    public getContract() : Contract {
        return this.contract;
    }

    public getFrom() : string {
        return this.from;
    }

    public getTo() : string {
        return this.to;
    }

    private contract : Contract;
    private from : string;
    private to : string;
}