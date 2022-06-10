import { Component, OnInit } from '@angular/core';
import { Subscription } from 'rxjs';
import { CoffeeService } from '../coffee.service';
import { Record } from '../models/record';

@Component({
  selector: 'app-coffee-list',
  templateUrl: './coffee-list.component.html',
  styleUrls: ['./coffee-list.component.css']
})
export class CoffeeListComponent implements OnInit {
  updateListSubscription: Subscription;

  records: Record[] = [];

  deleteId = 0;

  constructor(private coffeeService: CoffeeService) {
    this.updateListSubscription = this.coffeeService.sendUpdateList().subscribe(() => {
      this.getAllRecords();
    });
  }

  ngOnInit(): void {
    this.getAllRecords();
  }

  getAllRecords() {
    this.coffeeService.getRecords().subscribe((data) => {
      this.records = data as Record[];
      console.log(data);
    });
  }

  onDelete(id: number) {
    this.coffeeService.deleteRecord(id).subscribe((data) => {
      console.log(data);
      this.getAllRecords();
    })
  }

  onUpdate(id: number) {
    this.coffeeService.populateForm(id);
  }
}
