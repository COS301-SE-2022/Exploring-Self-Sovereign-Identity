import type { AddPendingTransactionRequest } from "@/models/requests/AddPendingTransactionRequest";
import type { FetchPendingTransactionRequest } from "@/models/requests/FetchPendingTransactionRequest";
import type { PastTransactionsRequest } from "@/models/requests/PastTransactionsRequest";
import type { SaveTransactionRequest } from "@/models/requests/SaveTransactionRequest";
import type { AddPendingTransactionResponse } from "@/models/response/AddPendingTransactionResponse";
import type { FetchPendingTransactionResponse } from "@/models/response/FetchPendingTransactionResponse";
import type { PastTransactionResponse } from "@/models/response/PastTransactionResponse";
import type { SaveTransactionResponse } from "@/models/response/SaveTransactionResponse";
import axios from "axios";

export class TransactionService {

    public async save(saveTransactionRequest: SaveTransactionRequest) : Promise<SaveTransactionResponse> {
        return (await axios.post<SaveTransactionResponse>("https://localhost:5000/transaction/save", saveTransactionRequest)).data;
    }

    public async past(pastTransactionRequest: PastTransactionsRequest) : Promise<PastTransactionResponse> {
        return (await axios.post<PastTransactionResponse>("https://localhost:5000/transaction/save", pastTransactionRequest)).data;
    }

    public async pending(fetchPendingTransactionRequest: FetchPendingTransactionRequest) : Promise<FetchPendingTransactionResponse> {
        return (await axios.post<FetchPendingTransactionResponse>("https://localhost:5000/transaction/save", fetchPendingTransactionRequest)).data;
    }

    public async add(addPendingTransactionRequest: AddPendingTransactionRequest) : Promise<AddPendingTransactionResponse> {
        return (await axios.post<AddPendingTransactionResponse>("https://localhost:5000/transaction/save", addPendingTransactionRequest)).data;
    }
}