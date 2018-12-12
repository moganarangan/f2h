import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';

// Import MDB Angular Module
import { MDBBootstrapModule } from 'angular-bootstrap-md';

// Import Ng Select Module
import { NgSelectModule } from '@ng-select/ng-select';

// Import Ngx-Components
import { AlertModule } from 'ngx-bootstrap';
import { BsDatepickerModule } from 'ngx-bootstrap/datepicker';
import { AccordionModule } from 'ngx-bootstrap/accordion';

// Import Swiper module
import { SwiperModule } from 'ngx-swiper-wrapper';

// Import Ant Module
import { NgZorroAntdModule } from 'ng-zorro-antd';

// Import Font Awesome Icons
import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';
import { library } from '@fortawesome/fontawesome-svg-core';
import { fab } from '@fortawesome/free-brands-svg-icons';
import { far } from '@fortawesome/free-regular-svg-icons';
import { fas } from '@fortawesome/free-solid-svg-icons';

// Add the fontawesome icons to the fontawesome library so we can use it in any component
library.add(fab, far, fas);

@NgModule({
  declarations: [
    AppComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    NgSelectModule,
    FontAwesomeModule,
    SwiperModule,
    NgZorroAntdModule,
    MDBBootstrapModule.forRoot(),
    AlertModule.forRoot(),
    BsDatepickerModule.forRoot(),
    AccordionModule.forRoot()
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
