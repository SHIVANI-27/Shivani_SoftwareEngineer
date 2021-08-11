import { Injectable } from "@angular/core";
import{HttpClient} from "@angular/common/http";
import { AppConfig } from "../appconfig";

@Injectable()
export class StudentService{
    constructor(private http: HttpClient){
    }

    GetStudentList(){
        return this.http.get(AppConfig.APIURL + "api/Student/GetStudentList");
    }

    GetStudent(data){
        return this.http.post(AppConfig.APIURL + "api/Student/GetStudentDetail",data);
    }

    Delete(data){
        return this.http.post(AppConfig.APIURL + "api/Student/Delete",data);
    }

    saveUpdateStudentData(data:any){
        return this.http.post(AppConfig.APIURL + "api/Student/AddUpdate",data);
    }
}