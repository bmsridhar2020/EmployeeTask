import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Employee } from './employee';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class EmployeeService {
  url ='http://localhost:50134/api/EmployeeData/Get';
    constructor(private http : HttpClient) { }
    getAllEmployee() : Observable<Employee[]>{
      return this.http.get<Employee[]>(this.url);
    }
  }
