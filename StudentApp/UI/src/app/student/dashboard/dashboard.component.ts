import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AppConfig } from 'src/app/appconfig';
import { IStudent, IStudentDisplay, StudentDisplay } from 'src/app/models/studentGrid';
import { StudentService } from '../student.service';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.css']
})
export class DashboardComponent implements OnInit {
studentList:IStudent[] = []
studentListToShow:StudentDisplay[] = []
search:string=""
isDesc: boolean = false;
  column: string = "";
filteBy = [{
  name: 'FirstName'
},
{
  name: 'LastName'
},
{
  name: 'Class'
},
{
  name: 'Subject'
},
{
  name: 'Marks'
},
];
  constructor(private router: Router,private service: StudentService) { }

  ngOnInit(): void {
    this.getStudentList();
  }
  getStudentList(){
    this.service.GetStudentList().subscribe((res:any)=>{
      debugger
      if(res && res['Success']){
        this.studentList = res['Data'];
        this.setStudentModel(this.studentList);
      }
    })
  }

  sortList(property: any) {
    this.isDesc = !this.isDesc;
    this.column = property;
    let direction = this.isDesc ? 1 : -1;
    this.studentListToShow.sort((a: any, b: any) => {
      debugger
      if (a[property] < b[property]) {
        var dd = -1 * direction;
        return dd;
      }
      else if (a[property] > b[property]) {
        var yy = 1 * direction;
        return yy;
      }
      else {
        return 0;
      }
    });
  }

  edit(data: any){
    AppConfig.studentDetail = data.ParentId
    this.router.navigate(['addupdate'])
  }
  delete(data:any){
    debugger
    var postData:any;
    if(data.FirstName && (data.FirstName != null ||data.FirstName != "")){
      postData= {
        StudentId : data.ParentId
      }
    }else{
      postData= {
        StudentDetailId : data.StudentDetailId
      }
    }
    this.service.Delete(postData).subscribe(res=>{
      this.studentListToShow = []
      this.getStudentList();
    })
  }
  navigate(){
    this.router.navigate(['addupdate'])
  }

  setStudentModel(data:IStudent[]){
    debugger
    if(data.length >0){
      data.forEach(element => {
        let detailList:StudentDisplay[] = []
        let x: StudentDisplay  = new StudentDisplay()
        x.ParentId = element.ID;
        x.ID = element.ID;
        x.FirstName = element.FirstName;
        x.LastName = element.LastName;
        x.Class = element.Class;
        if(element.SubjectDetails.length > 1){
          x.StudentDetailId = element.SubjectDetails[0].Id
          x.Subject = element.SubjectDetails[0].Subject;
          x.Marks = element.SubjectDetails[0].Marks;
          for(var i = 1; i < element.SubjectDetails.length;i++){
            let y: StudentDisplay = new StudentDisplay()
            y.ParentId = element.ID;
            y.StudentDetailId = element.SubjectDetails[i].Id
            y.Subject = element.SubjectDetails[i].Subject;
            y.Marks = element.SubjectDetails[i].Marks;
            detailList.push(y);
          }
        }else if(element.SubjectDetails.length ==1){
          x.StudentDetailId = element.SubjectDetails[0].Id
          x.Subject = element.SubjectDetails[0].Subject;
          x.Marks = element.SubjectDetails[0].Marks;
        }
        this.studentListToShow.push(x);
        if(detailList.length >0){
         this.studentListToShow= this.studentListToShow.concat(detailList);
        }
      });
    }
  }

}
