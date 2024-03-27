import { FormGroup } from "@angular/forms"

export function returnNumArray() : Number[]{
    return [0, 1, 2, 3, 4, 5]
}

export function formatDate(val: string | Date){
    return val.toLocaleString().substring(0, 10)
}

export function clearScoreForm(formGroup: FormGroup){
    formGroup.controls['scoreControl'].setValue(null)
    formGroup.controls['commentsControl'].setValue(null)
}

export function clearAuditForm(formGroup: FormGroup){
    formGroup.controls['employeeNameControl'].setValue(null)
    formGroup.controls['auditNumberControl'].setValue(null)
    formGroup.controls['zoneControl'].setValue(null)
    formGroup.controls['zoneCategoryControl'].setValue(null)
}

export function setFormForNewAudit(formGroup: FormGroup){
    formGroup.controls['auditNumberControl'].disable();
    formGroup.controls['employeeNameControl'].disable();
    formGroup.controls['zoneControl'].disable();
    formGroup.controls['zoneCategoryControl'].enable();
}

export function setFormForEditAudit(formGroup: FormGroup){
    formGroup.controls['auditNumberControl'].disable();
    formGroup.controls['employeeNameControl'].disable();
    formGroup.controls['zoneControl'].disable();
    formGroup.controls['zoneCategoryControl'].disable();
    formGroup.controls['totalScoreControl'].disable();
}
