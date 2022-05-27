import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { BsDropdownModule } from 'ngx-bootstrap/dropdown';
import { ToastrModule } from 'ngx-toastr';
import { TabsModule } from 'ngx-bootstrap/tabs';   // from https://valor-software.com/ngx-bootstrap/#/components/tabs?tab=api
import { NgxGalleryModule } from '@kolkov/ngx-gallery';   // from https://www.npmjs.com/package/@kolkov/ngx-gallery


@NgModule({
  declarations: [],
  imports: [
    CommonModule,

    // MOVED FROM app.module.ts (Video 73)
    BsDropdownModule.forRoot(),  // copied from https://valor-software.com/ngx-bootstrap/#/components/dropdowns?tab=api
    ToastrModule.forRoot({
      positionClass: 'toast-bottom-right'
    }),
    TabsModule.forRoot(),             // from https://valor-software.com/ngx-bootstrap/#/components/tabs?tab=api
    NgxGalleryModule            // from https://www.npmjs.com/package/@kolkov/ngx-gallery

  ],

  exports: [                    // added manually
    BsDropdownModule,           // added manually
    ToastrModule,               // added manually
    TabsModule,                 // from https://valor-software.com/ngx-bootstrap/#/components/tabs?tab=api
    NgxGalleryModule            // from https://www.npmjs.com/package/@kolkov/ngx-gallery

  ]
})
export class SharedModule { }
