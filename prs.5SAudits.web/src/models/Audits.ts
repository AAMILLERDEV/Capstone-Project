export interface Audits {
    id: number | null;
    dateStarted: Date;
    employeeId: number;
    dateCompleted: Date | null;
    department_ID: number;
    overallScore: number;
    auditStatus_ID: number;
    notes: string | null;
}