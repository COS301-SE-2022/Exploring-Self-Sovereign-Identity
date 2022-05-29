import type { Attribute } from "./Attribute";
import type { OrganizationCredentials } from "./OrganizationCredentials";

export class UserData {

    public constructor(hash: string, version: number, attributes: Attribute[], credentials: OrganizationCredentials[]) {
        this.hash = hash;
        this.version = version;
        this.attributes = attributes;
        this.credentials = credentials;
    }

    public getHash() : string {
        return this.hash;
    }

    public getVersion() : number {
        return this.version;
    }

    public getAttributes() : Attribute[] {
        return this.attributes;
    }

    public getCredentials() : OrganizationCredentials[] {
        return this.credentials;
    }
    
    private hash : string;
    private version : number;

    private attributes : Attribute[];
    private credentials : OrganizationCredentials[];
}