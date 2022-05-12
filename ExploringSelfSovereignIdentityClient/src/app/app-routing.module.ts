import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ApprovePermsComponent } from './approve-perms/approve-perms.component';

const routes: Routes = [
  { path: 'approve-perms', component: ApprovePermsComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
