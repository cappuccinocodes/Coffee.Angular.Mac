import { Component, OnInit } from '@angular/core';
import { CoffeeService } from '../coffee.service';
import { Record } from '../models/record';

@Component({
  selector: 'app-coffee-list',
  templateUrl: './coffee-list.component.html',
  styleUrls: ['./coffee-list.component.css']
})
export class CoffeeListComponent implements OnInit {
  records: Record[] = [];

  constructor(private coffeeService: CoffeeService) { }

  ngOnInit(): void {
    this.getAllRecords();
  }

  getAllRecords() {
    this.coffeeService.getRecords().subscribe((data) => {
      this.records = data as Record[];
      console.log(data);
    });
  }

}
