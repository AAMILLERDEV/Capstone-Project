export interface Resources {
    id: number;
    audit_ID: number;
    dateAdded: Date;
    score_ID: number;
    resourceData?: string;
    isDeleted: boolean;
    isAfter: boolean;
    isNew: boolean;
}