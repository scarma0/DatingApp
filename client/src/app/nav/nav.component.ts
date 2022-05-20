import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { User } from '../_models/user';
import { AccountService } from '../_services/account.service';

@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrls: ['./nav.component.css']
})
export class NavComponent implements OnInit {
  model: any = { }
  // loggedIn: boolean;
  // currentUser$: Observable<User>;

  // constructor(private accountService: AccountService) { }
  constructor(public accountService: AccountService) { }        // if private cannot be accessed in the template (.html)

  ngOnInit(): void {
    // this.getCurrentUser();
    // this.currentUser$ = this.accountService.currentUser$;
  }

  login() {
    // console.log(this.model);
    this.accountService.login(this.model).subscribe(response => {
      console.log(response);
      // this.loggedIn = true;
    }, error => {
      console.log(error);
    })
  }

  logout() {
    // this.loggedIn = false;
    this.accountService.logout();     // calling the other logout method
  }

  // getCurrentUser() {
  //   this.accountService.currentUser$.subscribe(user => {
  //     this.loggedIn = !!user;           // !! converts to boolean. if user is null, them returns false.
  //   }, error => {
  //     console.log(error);
  //   })
  // }
}
