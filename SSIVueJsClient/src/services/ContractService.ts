import type { Attribute } from "@/models/entity/Attribute";
import type { Contract } from "@/models/entity/Contract";
import type { UserData } from "@/models/entity/UserData";

export class ContractService {

    public constructor(contract: Contract, user: UserData) {
        this.contract = contract;
        this.user = user;
    }

    public sign() {
        this.contract.setSignature(this.user.getId());
    }

    public approve(name: string) : boolean {

        var attr : Attribute | undefined;

        if (name.includes(".")) {
            const args : string[] = name.split(".");

            const org = this.user.getCredentials().find(c => c.getId() === args[0]);
            
            if (org === undefined)
                return false;
            else
                attr = org.getCredentials().find(a => a.getName() === args[1]);
        
        }
        else {
            attr = this.user.getAttributes().find(a =>a.getName() === name);
        }

        if (attr != undefined) {
            this.contract.getAttributes().find(a => a.getName() === name)
            ?.setValue(attr.getValue());

            return true;
        }
        else {
            return false;
        }

    }
    
    private contract : Contract;
    private user: UserData;
}