import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrls: ['./nav.component.css'],
})
export class NavComponent implements OnInit {
  totalItemsInCart = 0;
  constructor() {}

  ngOnInit() {
    this.loggedIn();
  }

  loggedIn() {}

  logout() {}
}
