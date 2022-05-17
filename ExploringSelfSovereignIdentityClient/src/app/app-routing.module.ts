import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { AcceptPermissionsComponent } from './accept-permissions/accept-permissions.component';

const routes: Routes = [
  { path: '', component: HomeComponent },
  { path: 'approve', component: AcceptPermissionsComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
