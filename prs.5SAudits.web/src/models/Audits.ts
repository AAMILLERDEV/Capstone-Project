export interface Audits {
    id: number;
    dateStarted: Date;
    employeeId: number;
    dateCompleted: Date;
    departmentId: number;
    overallScore: number;
    auditStatusId: number;
    notes: string;
}