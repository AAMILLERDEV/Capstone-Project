import { FormControl, FormGroup } from "@angular/forms";

export const AuditForm = new FormGroup ({
  auditNumberControl: new FormControl(),
  dateStartedControl: new FormControl(),
  dateCompletedControl: new FormControl(),
  departmentControl: new FormControl(),
  scoreControl: new FormControl(),
  employeeNameControl: new FormControl(),
  notesControl: new FormControl()
})
