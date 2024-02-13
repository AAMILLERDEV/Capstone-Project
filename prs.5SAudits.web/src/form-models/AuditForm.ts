import { FormControl, FormGroup, Validators } from "@angular/forms";

export const AuditForm = new FormGroup ({
  auditNumberControl: new FormControl(),
  dateStartedControl: new FormControl(),
  dateCompletedControl: new FormControl(),
  zoneControl: new FormControl(),
  zoneCategoryControl: new FormControl(),
  scoreControl: new FormControl(),
  targetScoreControl: new FormControl(),
  employeeNameControl: new FormControl(),
  commentsControl: new FormControl()
})


