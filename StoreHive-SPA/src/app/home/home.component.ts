import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {
  stores: any;
  constructor(private http: HttpClient) { }

  ngOnInit() {
    this.loadStores();
  }

  loadStores() {
    this.http.get('localhost:5000/api/marketplace/getStores').subscribe(response => {
      this.stores = response;
    }, error => {
      console.log(error);
    });
  }

}
