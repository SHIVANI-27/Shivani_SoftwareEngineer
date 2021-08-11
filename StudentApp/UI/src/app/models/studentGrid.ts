export interface IStudent {
    "ID": number,
    "FirstName": string
    "LastName": string,
    "Class": string,
    "SubjectDetails": IStudentDetail[],
}
export interface IStudentDetail {
    "Id": number,
    "StudentID": number
    "Subject": string,
    "Marks": string
}

export interface IStudentDisplay {
    "ParentId" : number,
    "ID": number,
    "FirstName": string
    "LastName": string,
    "Class": string,
    "Subject": string,
    "Marks": string
}
export class StudentDisplay {
    "ParentId" : number;
    "ID": number;
    "FirstName": string;
    "LastName": string;
    "Class": string;
    "StudentDetailId": number;
    "Subject": string;
    "Marks": string
}

export interface IStudentDisplay {
    "ParentId" : number,
    "ID": number,
    "FirstName": string
    "LastName": string,
    "Class": string,
    "Subject": string,
    "Marks": string
}
