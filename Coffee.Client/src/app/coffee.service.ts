import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Record } from './models/record';
import { Subject } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class CoffeeService {
  private populateFormSubject = new Subject<any>();
  private updateListSubject = new Subject<any>();

  readonly rootURL = 'https://localhost:7051';

  constructor(private http: HttpClient) { }

  getRecords() {
    return this.http.get(this.rootURL + '/Coffee');
  }

  getRecord(id: number) {
    return this.http.get(this.rootURL + '/Coffee/' + id);
  }

  addRecord(record: Record) {
    return this.http.post(this.rootURL + '/Coffee', record);
  }

  deleteRecord(id: number) {
    return this.http.delete(this.rootURL + '/Coffee/' + id,);
  }

  updateRecord(record: Record) {
    return this.http.put(this.rootURL + '/Coffee',record);
  }

  populateForm(id: number) {
    this.populateFormSubject.next(id);
  }

  sendPopulateForm() {
    return this.populateFormSubject.asObservable();
  }

  updateList() {
    this.updateListSubject.next(true);
  }

  sendUpdateList() {
    return this.updateListSubject.asObservable();
  }

}

