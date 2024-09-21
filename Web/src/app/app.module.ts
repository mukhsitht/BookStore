import { NgModule } from '@angular/core';
import { AngularMyDatePickerModule } from 'angular-mydatepicker';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule } from '@angular/forms';
import { AppComponent } from './app.component';
import { HeaderComponent } from './layout/header/header.component';
import { FooterComponent } from './layout/footer/footer.component';
import { HomeComponent } from './home/home.component';
import { AppRoutingModule } from './app-routing.module';
import { SidemenuComponent } from './layout/sidemenu/sidemenu.component';
import { BooklistComponent } from './books/booklist/booklist.component';
import { BookaddComponent } from './books/bookadd/bookadd.component';
import { ValidatePriceDirective } from './customvalidators/validate-price.directive';
import { BookeditComponent } from './books/bookedit/bookedit.component';

@NgModule({
  declarations: [
    AppComponent,
    HeaderComponent,
    FooterComponent,
    HomeComponent,
    SidemenuComponent,
    BooklistComponent,
    BookaddComponent,
    ValidatePriceDirective,
    BookeditComponent
  ],
  imports: [
    AngularMyDatePickerModule,
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
