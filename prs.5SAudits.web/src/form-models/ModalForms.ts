import { FormControl, FormGroup } from "@angular/forms";

export const ZonesForm = new FormGroup ({
  idControl: new FormControl(),
  zoneCategoryControl: new FormControl(),
  zoneNameControl: new FormControl()
})

export const DeletionForm = new FormGroup ({
    reasonControl: new FormControl()
})

export const ZoneCategoryForm = new FormGroup ({
    targetControl: new FormControl(),
    categoryNameControl: new FormControl()
})

export const ScoringCriteriaForm = new FormGroup ({
    descriptionControl: new FormControl()
})