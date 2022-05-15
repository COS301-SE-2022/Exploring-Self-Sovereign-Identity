import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { Router } from '@angular/router'; 
import { ApprovePermsService } from '../services/approve-perms.service';


@Component({
  selector: 'app-otp-page',
  templateUrl: './otp-page.component.html',
  styleUrls: ['./otp-page.component.scss']
})
export class OtpPageComponent implements OnInit {

  constructor(private router: Router, private http: HttpClient, private approve: ApprovePermsService) {
    
  }

  _otp: string = "";
  errMsg: string = "";

  onSubmit() {
    this.http.post<any>("http://localhost:5000/api/Session/connect", { "otp": this._otp })
      .subscribe(data => {
        if (data != null) {
          this.router.navigate(["/approve"]);
          this.approve.populate(data);
          //console.log(data);
        }
        else {
          this.errMsg = "invalid session...";
          setTimeout(() => {
            this.errMsg = "";
          }, 2000);
        }
      });
  }

  

  ngOnInit(): void {
    
  }

}
