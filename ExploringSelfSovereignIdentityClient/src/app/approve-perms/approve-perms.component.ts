import { Component, OnInit, NgModule } from '@angular/core';
import { ApprovePermsService } from '../services/approve-perms.service';
import { HttpClient } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { catchError, retry } from 'rxjs/operators';
import { Route, Router } from '@angular/router';


@Component({
  selector: 'app-approve-perms',
  templateUrl: './approve-perms.component.html',
  styleUrls: ['./approve-perms.component.scss']
})
export class ApprovePermsComponent implements OnInit {

  perms: ApprovePermsService;
  options: Array<string> = [];



  constructor(perms: ApprovePermsService, private http: HttpClient, private router: Router) {
    this.perms = perms;
    for (let p of this.perms.permsArray) {
      if (!p.item2)
        this.options.push(p.item1);
    }
  }

  ngOnInit(): void {
  }

  send() {
    let temp = this.http.post<any>("http://localhost:5000/api/Session/confirm", JSON.stringify(this.options), { observe: 'response' }).subscribe(resp => { console.log(resp); });

    this.router.navigate(['/certificates']);
  }

  back() {
    this.router.navigate(['']);
  }

  update(event: any) {
    if (!event.target.checked) {
      if (this.options.includes(event.target.value))
        this.options.splice(this.options.indexOf(event.target.value), 1);
    }
    else
      this.options.push(event.target.value);
    console.log(this.options);
  }




}

