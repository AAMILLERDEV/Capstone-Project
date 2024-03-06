export interface Audits {
    id: number | null;
    dateStarted: Date;
    employee_ID: number;
    dateCompleted: Date | null;
    zone_ID: number;
    overallScore: number;
    auditStatus_ID: number;
    notes: string | null;
    zoneName?: string;
    isDeleted: boolean;
    auditNumber: string;
}