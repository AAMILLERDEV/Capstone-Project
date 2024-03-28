import { Component } from '@angular/core';
import { FormGroup } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';
import { SupportForm } from 'src/form-models/SupportForm';
import { Email } from 'src/models/Email';
import { EmailService } from 'src/services/email.service';
import { EventLogsService } from 'src/services/eventLogs.service';

@Component({
  selector: 'app-support',
  templateUrl: './support.component.html',
  styleUrls: ['./support.component.scss']
})
export class SupportComponent {

  public supportForm: FormGroup;

  public requestInProgress: boolean = false;

  constructor(private toastr: ToastrService,
    private emailService: EmailService,
    private eventLogService: EventLogsService){
    this.supportForm = SupportForm;
  }

  public async sendEmail() {
    if (this.supportForm.invalid){
      this.toastr.error("Please include both a subject and message ")
    }

    this.requestInProgress = true;

    let email: Email = {
      body: this.supportForm.controls['bodyControl'].value,
      subject: this.supportForm.controls['subjectControl'].value
    };

    let res = await this.emailService.SendEmail(email);

    if (res){
      this.toastr.success("Success, email has been sent to IT")
      await this.eventLogService.insertEmailEventLog(email);
      this.supportForm.reset();
    }

    this.requestInProgress = false;
  }
}
