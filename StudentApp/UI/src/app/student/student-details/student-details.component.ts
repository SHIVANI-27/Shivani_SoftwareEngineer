import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators, FormArray } from '@angular/forms';
import { Router } from '@angular/router';
import { AppConfig } from 'src/app/appconfig';
import { StudentService } from '../student.service';

@Component({
  selector: 'app-student-details',
  templateUrl: './student-details.component.html',
  styleUrls: ['./student-details.component.css']
})
export class StudentDetailsComponent implements OnInit {

  constructor(private fb: FormBuilder,private service: StudentService,private router: Router) { }
  public CreateForm: FormGroup | undefined;
  SubjectDetails: FormArray = this.fb.array([]);
  ngOnInit(): void {
    debugger
    this.createForm1();
    this.getStudentData();
  }

  getStudentData(){
    debugger
    this.service.GetStudent(AppConfig.studentDetail).subscribe((res:any)=>{
      if(res && res['Success']){
        this.setData(res['Data'])
      }
    })
  }

  setData(data:any){
    debugger
    if(data['SubjectDetails'] != null && data['SubjectDetails'].length >1){
      for(var i = 1 ; i < data['SubjectDetails'].length; i++){
        this.SubjectDetails = this.CreateForm.get('SubjectDetails') as FormArray;
      this.SubjectDetails.push(this.createFormDetail());
      }
    }

    this.CreateForm['controls']['ID'].setValue(data.ID);
    this.CreateForm['controls']['FirstName'].setValue(data.FirstName);
    this.CreateForm['controls']['LastName'].setValue(data.LastName);
    this.CreateForm['controls']['Class'].setValue(data.Class);
    
    this.CreateForm['controls']['SubjectDetails'].setValue(data.SubjectDetails);
    
  }

  createForm1 = () => {
    this.CreateForm = this.fb.group({
      ID:[''],
      FirstName: ['', Validators.required],
      LastName: ['', Validators.required],
      Class: ['', Validators.required],
      SubjectDetails: this.fb.array([this.createFormDetail()])
    });

  }

  createFormDetail() {
    return this.fb.group({
      Id:[''],
      StudentID:[''],
     Subject: [''],
     Marks: [''],
    });
  }

  addNewSub(){
    this.SubjectDetails = this.CreateForm.get('SubjectDetails') as FormArray;
    this.SubjectDetails.push(this.createFormDetail());
  }
  save(){
    debugger
    var postData = this.CreateForm.value;
    this.service.saveUpdateStudentData(postData).subscribe((res:any)=>{
      if(res && res['Success']){
        this.router.navigate([''])
      }
    })
  }

}
