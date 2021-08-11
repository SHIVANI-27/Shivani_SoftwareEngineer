import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { DashboardComponent } from './dashboard/dashboard.component';
import { RouterModule, Routes } from '@angular/router';
import { StudentService } from './student.service';
import { HttpClientModule } from '@angular/common/http';
import { StudentDetailsComponent } from './student-details/student-details.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { SearchPipe } from './customePipe';

const routes: Routes = [{
  path: '', component: DashboardComponent,
   
        
},{path: 'addupdate', component: StudentDetailsComponent }
]

@NgModule({
  declarations: [
    DashboardComponent,
    StudentDetailsComponent,
    SearchPipe
  ],
  imports: [
    CommonModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    RouterModule.forChild(routes),
  ],
  providers:[StudentService]
})
export class StudentModule { }
