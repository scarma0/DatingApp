import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { BsDropdownModule } from 'ngx-bootstrap/dropdown';
import { ToastrModule } from 'ngx-toastr';



@NgModule({
  declarations: [],
  imports: [
    CommonModule,

    // MOVED FROM app.module.ts (Video 73)
    BsDropdownModule.forRoot(),  // copied from https://valor-software.com/ngx-bootstrap/#/components/dropdowns?tab=api
    ToastrModule.forRoot({
      positionClass: 'toast-bottom-right'
    })
  ],

  exports: [                    // added manually
    BsDropdownModule,           // added manually
    ToastrModule                // added manually

  ]
})
export class SharedModule { }
