import type { Attribute } from "./Attribute";
import type { UserData } from "./UserData";

export class Contract {

    public constructor(attributes: Attribute[]) {
        this.attributes = attributes;
    }

    private attributes : Attribute[];
    private signature: string = "";
}