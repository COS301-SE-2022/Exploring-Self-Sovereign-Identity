import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-approve-perms',
  templateUrl: './approve-perms.component.html',
  styleUrls: ['./approve-perms.component.scss']
})
export class ApprovePermsComponent implements OnInit {

  constructor() { }

  ngOnInit(): void {
  }

  permissions = ['Test', 'Test 2'];

}
