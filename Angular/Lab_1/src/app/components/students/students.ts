import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { TableModule } from 'primeng/table';
import { Student } from '../../models/student';
import { ButtonModule } from 'primeng/button';
import { CommonModule } from '@angular/common';
import { DialogModule } from 'primeng/dialog';
import { InputTextModule } from 'primeng/inputtext';

@Component({
  selector: 'app-students',
  imports: [FormsModule, TableModule, ButtonModule, CommonModule, DialogModule, InputTextModule],
  templateUrl: './students.html',
  styleUrl: './students.css',
})
export class Students {
  studentsList: Student[] = [
    { id: 1, name: 'Harvey Specter', age: 35 },
    { id: 2, name: 'Mike Ross', age: 28 },
    { id: 3, name: 'Chandler Bing', age: 32 },
    { id: 4, name: 'Joey Tribbiani', age: 29 },
    { id: 5, name: 'Mohamed El Shenawy', age: 35 },
    { id: 6, name: 'Erling Haaland', age: 23 }
  ];

  newStudentObj: Student = { id: 0, name: '', age: 0 };

  displayEditDialog: boolean = false;
  studentToEdit: Student = { id: 0, name: '', age: 0 };

  addNew() {
    if (this.newStudentObj.name && this.newStudentObj.age) {
      const newId = this.studentsList.length > 0 ? this.studentsList[this.studentsList.length - 1].id + 1 : 1;
      this.studentsList.push({ id: newId, name: this.newStudentObj.name, age: this.newStudentObj.age });
      this.newStudentObj = { id: 0, name: '', age: 0 };
    }
  }

  deleteStudent(studentId: number) {
    let index = this.studentsList.findIndex(student => student.id === studentId);
    if (index !== -1) {
      this.studentsList.splice(index, 1);
    } else {
      throw new Error(`Student with id ${studentId} not found.`);
    }
  }

  saveEdit() {
    let index = this.studentsList.findIndex(s => s.id === this.studentToEdit.id);
    if (index !== -1) {
      this.studentsList[index] = { ...this.studentToEdit };
    }
    this.displayEditDialog = false;
  }

  openUpdateDialog(student: Student) {
    this.studentToEdit = { ...student };
    this.displayEditDialog = true;
  }

}
