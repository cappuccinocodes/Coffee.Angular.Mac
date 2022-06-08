import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Record } from './models/record';

@Injectable({
  providedIn: 'root'
})
export class CoffeeService {
  readonly rootURL = 'https://localhost:7051';

  constructor(private http: HttpClient) { }

  getRecords() {
    return this.http.get(this.rootURL + '/Coffee');
  }

  addRecord(record: Record) {
    return this.http.post(this.rootURL + '/Coffee', record);
  }

}

