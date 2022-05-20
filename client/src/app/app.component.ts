import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { User } from './_models/user';
import { AccountService } from './_services/account.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit{
  title = 'The Dating app';
  users: any;

  // constructor(private http: HttpClient, private accountService: AccountService) {}  // HttiClient moved to app.home
  constructor(private accountService: AccountService) {}

  ngOnInit(): void {
    // this.getUsers();                   // no more needed
    this.setCurrentUser();
  }

  setCurrentUser() {
    const user: User = JSON.parse(localStorage.getItem('user'));
    this.accountService.setCurrentUser(user);
  }

  // getUsers() {
  //   this.http.get('https://localhost:5001/api/users').subscribe(Response => {     // .Subscribe is deprecated
  //     this.users = Response;
  //   }, error => {
  //     // console.log(error);
  //   })
  // }

  // getUsers() {
  //   this.http.get('https://localhost:5001/api/users').subscribe({           // moved to app.home
  //     next: response => this.users = response,
  //     error: error => console.log(error)
  //   })
  // }
}
