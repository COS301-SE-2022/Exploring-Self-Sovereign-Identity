import type { Attribute } from "../entity/Attribute";

export class UpdateRequest {
  public constructor(userID: String, attributes: Attribute[]) {
    this.userID = userID;
    this.attributes = attributes;
  }

  private userID: String;
  private attributes: Attribute[];
}
