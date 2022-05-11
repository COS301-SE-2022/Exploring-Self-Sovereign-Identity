import { Component, OnInit, NgModule } from '@angular/core';
import { ApprovePermsService } from '../services/approve-perms.service';
import { HttpClient } from '@angular/common/http';


@Component({
  selector: 'app-approve-perms',
  templateUrl: './approve-perms.component.html',
  styleUrls: ['./approve-perms.component.scss']
})
export class ApprovePermsComponent implements OnInit {

  perms: ApprovePermsService;


  constructor(perms: ApprovePermsService, private http: HttpClient) {
    this.perms = perms;

  }

  ngOnInit(): void {
  }




}

