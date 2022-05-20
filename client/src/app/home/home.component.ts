import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {
  registerMode = false;
  testCHildToParent = "test";                               // sm sm sm sm 
  // users: any;

  // constructor(private http: HttpClient) { }
  constructor() { }

  ngOnInit(): void {
    // this.getUsers();
  }

  registerToggle() {
    this.registerMode = !this.registerMode;
    // console.log(this.registerMode);                  // SM added
  }

  //  getUsers() {
  //   this.http.get('https://localhost:5001/api/users').subscribe(users => this.users = users);    //??
  // }

  cancelRegisterMode(event: boolean) {
    this.registerMode = event;
  }

  testCToP(event: string) {                    // sm sm sm sm 
    this.testCHildToParent = event;
    console.log(this.testCHildToParent);
  }
}
