import { FormControl, FormGroup, Validators } from "@angular/forms";

export const FilterForm = new FormGroup ({
  zoneControl: new FormControl(),
  auditNumberControl: new FormControl(),
  zoneCategoryControl: new FormControl(),
  auditStatusControl: new FormControl()
})


