import { Component, OnInit } from '@angular/core';
import { MatAccordion } from '@angular/material/expansion';
import { MatFormField } from '@angular/material/form-field';
import { MatInput } from '@angular/material/input';
import { MatDatepickerInput } from '@angular/material/datepicker';
import { formatDate } from '@angular/common';

@Component({
  selector: 'app-user-profile',
  templateUrl: './user-profile.component.html',
  styleUrls: ['./user-profile.component.scss']
})
export class UserProfileComponent implements OnInit {
  user: userInformation;
  constructor() {
    this.user = new userInformation("Bruno", "Mars", new Date, "America");
  }

  ngOnInit(): void {
  }

}

class userInformation {
  constructor(n: string, s: string, b: Date, nat: string) {
    this.name = n;
    this.surname = s;
    this.birthday = b;
    this.nationality = nat;
    //this.birthdaystring = formatDate(this.birthday, "mediumDate")
    this.birthdaystring = this.birthday.toString() | Date: "mediumDate" 

}

name: string = "";
surname: string = "";
birthday: Date;
nationality: string = "";
birthdaystring: string;

data: any = [];
}
