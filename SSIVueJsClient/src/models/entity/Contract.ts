import type { Attribute } from "./Attribute";
import type { UserData } from "./UserData";

export class Contract {
  public constructor(attributes: Attribute[]) {
    this.attributes = attributes;
  }

  public setSignature(signature: string) {
    this.signature = signature;
  }

  public getAttributes(): Attribute[] {
    return this.attributes;
  }

  public getSignature(): string {
    return this.signature;
  }

  /* Key - Value Pairs */
  private attributes: Attribute[];

  /*
   * Signed - accepted
   * Not Signed - declined
   */
  private signature = "";
}
