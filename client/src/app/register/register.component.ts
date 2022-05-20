import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { AccountService } from '../_services/account.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {
  // @Input() usersFromHomeComponent: any;
  @Output() cancelRegister = new EventEmitter();
  @Output() testCHildToParent = new EventEmitter();              // sm sm sm sm 

  model: any = {}

  constructor(private accountservice: AccountService) { }

  ngOnInit(): void {
  }

  register() {
    console.log(this.model);
    this.accountservice.register(this.model).subscribe(response => {
      console.log(response);
      this.cancel();
    }, error => {
      console.log(error);
    })
  }

  cancel() {
    console.log('cancelled');
    this.cancelRegister.emit(false);
    this.testCHildToParent.emit("This is a test for passing value to parent from child");
     // sm sm sm sm 
  }
}
