import { Component, OnInit } from '@angular/core';
import { EmployeeService } from './employee.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  title = 'EmployeeData';
  public employeeData = [];
  constructor(private employeeService: EmployeeService) {
  }
  ngOnInit() {
    // this.getEmployees();
  }

  showEmployees() {
    this.getEmployees();
  }

  getEmployees() {
    this.employeeService.getAllEmployee().subscribe(data=> {
    this.employeeData = data;
    });
  }
}
