import { Component, OnInit } from '@angular/core';
import { MatCard } from '@angular/material/card';
import { DomSanitizer } from '@angular/platform-browser';
import { MatIconRegistry } from '@angular/material/icon';

//const PLUS = "";



@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})


export class HomeComponent implements OnInit {
  //constructor(iconRegistry: MatIconRegistry, sanitizer: DomSanitizer) {
  constructor() {
    //iconRegistry.addSvgIconLiteral('plus', sanitizer.bypassSecurityTrustHtml(PLUS));


    this.cardList.push(new card("Google", "21 Jan 2022"));
    this.cardList.push(new card("Facebook", "01 Feb 2022"));
    this.cardList.push(new card("Steam", "16 May 2022"));
    this.cardList.push(new card("Spotify", "12 December 2021"));
    this.cardList.push(new card("Nedbank", "28 April 2022"));
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
