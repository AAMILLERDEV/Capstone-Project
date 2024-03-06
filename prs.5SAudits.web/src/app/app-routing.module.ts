import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { EditAuditFormComponent } from './audits/edit-audit-form/edit-audit-form.component';
import { NewAuditFormComponent } from './audits/new-audit-form/new-audit-form.component';
import { SupportComponent } from './support/support.component';
import { AdminComponent } from './admin/admin.component';
import { DtViewerComponent } from './admin/dt-viewer/dt-viewer.component';

const routes: Routes = [{path: "", component: HomeComponent},
{path: "home", component: HomeComponent},
{path: "audit/edit/:id", component: EditAuditFormComponent},
{path: "audit/new", component: NewAuditFormComponent},
{path: "support", component: SupportComponent},
{path: "admin", component: AdminComponent},
{path: "admin/data/:view", component: DtViewerComponent}];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})

export class AppRoutingModule { }
