import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ApprovePermsComponent } from './approve-perms/approve-perms.component';
import { OtpPageComponent } from './otp-page/otp-page.component';
import { CertificatesComponent } from './certificates/certificates.component'

const routes: Routes = [
  { path: 'approve', component: ApprovePermsComponent },
  { path: 'otp', component: OtpPageComponent },
  { path: 'certificates', component: CertificatesComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
