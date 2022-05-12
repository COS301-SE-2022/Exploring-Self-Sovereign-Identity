import { Component, OnInit } from '@angular/core';
import { FormControl } from '@angular/forms'; 


@Component({
  selector: 'app-otp-page',
  templateUrl: './otp-page.component.html',
  styleUrls: ['./otp-page.component.scss']
})
export class OtpPageComponent implements OnInit {

  constructor() { }

  otp = new FormControl(''); 

  ngOnInit(): void {
  }

}
