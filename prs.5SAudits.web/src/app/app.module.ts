import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { TooltipModule} from 'ngx-bootstrap/tooltip';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HomeComponent } from './home/home.component';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { NavbarComponent } from './navbar/navbar.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { AuditFormComponent } from './audits/audit-form/audit-form.component';
import { NewAuditFormComponent } from './audits/new-audit-form/new-audit-form.component';
import { EditAuditFormComponent } from './audits/edit-audit-form/edit-audit-form.component';
import { SupportComponent } from './support/support.component';
import { AdminComponent } from './admin/admin.component';
import { ToastrModule } from 'ngx-toastr';
import { WebcamModule } from 'ngx-webcam';
import { CameraComponent } from './audits/camera/camera.component';
import { DtViewerComponent } from './admin/dt-viewer/dt-viewer.component';
import { DatatableComponent } from './admin/datatable/datatable.component';
import { CarouselModule } from 'ngx-owl-carousel-o';

@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    NavbarComponent,
    AuditFormComponent,
    NewAuditFormComponent,
    EditAuditFormComponent,
    AdminComponent,
    SupportComponent,
    CameraComponent,
    DtViewerComponent,
    DatatableComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    ReactiveFormsModule,
    WebcamModule,
    FormsModule,
    BrowserAnimationsModule,
    TooltipModule.forRoot(),
    ToastrModule.forRoot(),
    NgbModule,
    CarouselModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
