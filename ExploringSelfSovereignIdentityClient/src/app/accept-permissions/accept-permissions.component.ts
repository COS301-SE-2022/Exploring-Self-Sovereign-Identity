import { Component, OnInit } from '@angular/core';
import { MatCard } from '@angular/material/card';
import { MatDivider } from '@angular/material/divider';


@Component({
  selector: 'app-accept-permissions',
  templateUrl: './accept-permissions.component.html',
  styleUrls: ['./accept-permissions.component.scss']
})
export class AcceptPermissionsComponent implements OnInit {

  constructor() {
    this.cardList.push(new card("Name", "required"));
    this.cardList.push(new card("Surname", "required"));
    this.cardList.push(new card("email", "required"));
    this.cardList.push(new card("age", "optional"));
    this.cardList.push(new card("address", "optional"));
  }

  ngOnInit(): void {
  }
  cardList: Array<card> = [];

}

export class card {
  constructor(t: string, s: string) {
    this.title = t;
    this.sub = s;
  }
  title: string;
  sub: string;
}
