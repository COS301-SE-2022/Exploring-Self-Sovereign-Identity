import type { Attribute } from "./Attribute";

export class OrganizationCredentials {

    public constructor(id: string, credentials: Attribute[]) {
        this.id = id;
        this.credentials = credentials;
    }

    public getId() : string {
        return this.id;
    }

    public getCredentials() : Attribute[]  {
        return this.credentials
    }

    private id : string;
    private credentials : Attribute[];
}