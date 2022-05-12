import { Component, OnInit } from '@angular/core';
import { FormControl } from '@angular/forms';
import { Router } from '@angular/router'; 


@Component({
  selector: 'app-otp-page',
  templateUrl: './otp-page.component.html',
  styleUrls: ['./otp-page.component.scss']
})
export class OtpPageComponent implements OnInit {

  constructor(private router: Router, ) {}

  onSubmit() {
    this.router.navigate(['/approve'])
  }

  otp = new FormControl(''); 

  ngOnInit(): void {
  }

}
