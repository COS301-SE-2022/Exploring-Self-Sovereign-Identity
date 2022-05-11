import { Component, OnInit, NgModule } from '@angular/core';
import { ApprovePermsService } from '../services/approve-perms.service';

@Component({
  selector: 'app-approve-perms',
  templateUrl: './approve-perms.component.html',
  styleUrls: ['./approve-perms.component.scss']
})
export class ApprovePermsComponent implements OnInit {

  perms: ApprovePermsService;

  constructor(perms: ApprovePermsService) {
    this.perms = perms;
  }

  ngOnInit(): void {
  }




}

