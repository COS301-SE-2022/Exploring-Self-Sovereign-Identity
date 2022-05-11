import { Component, OnInit, NgModule } from '@angular/core';

@Component({
  selector: 'app-approve-perms',
  templateUrl: './approve-perms.component.html',
  styleUrls: ['./approve-perms.component.scss']
})
export class ApprovePermsComponent implements OnInit {

  public array: Array<permissions> = [];


  constructor() {
    let perm = new permissions("name", true);
    this.array.push(perm);
    perm = new permissions("surname", false);
    this.array.push(perm);
  }

  ngOnInit(): void {
  }

  
  

}

export class permissions {
  public item1= '';
  public item2= true;

  constructor(a :string, b: boolean) {
    this.item1 = a;
    this.item2 = b;
  }
}

