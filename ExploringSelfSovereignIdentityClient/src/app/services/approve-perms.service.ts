import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class ApprovePermsService {

  public permsArray: Array<permissions> = [];
  public issuer: string = "";
  public id: string = "";

  constructor() {
    this.add("name", true);
    this.add("email", true);
    this.add("surname", false);
    this.add("address", false);
    this.id = "Login";
    this.issuer = "TUKS";

  }

  public add(s: string, b: boolean): void {
    this.permsArray.push(new permissions(s, b));
  }

  public get(s: string): boolean {
    for (let p of this.permsArray) {
      if (p.item1 === s)
        return p.item2;
    }
    return false;
  }

  public populate(data: any) {
    if (this.permsArray.length > 0) {
      while (this.permsArray.length != 0)
        this.permsArray.pop();
    }
    for (let d of data.attributes) {
      this.permsArray.push(new permissions(d.item1, d.item2));
    }
    this.issuer = data.issuerSignature;
    this.id = data.identityName;
  }


}

class permissions {
  public item1 = '';
  public item2 = true;

  constructor(a: string, b: boolean) {
    this.item1 = a;
    this.item2 = b;
  }
}

