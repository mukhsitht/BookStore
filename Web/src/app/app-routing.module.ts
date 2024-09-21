import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { BooklistComponent } from './books/booklist/booklist.component'
import { BookaddComponent } from './books/bookadd/bookadd.component'
import { BookeditComponent } from './books/bookedit/bookedit.component'

const routes: Routes = [
  {
    path: '', component: HomeComponent, data: { breadcrumb: 'Test Error' }
  },
  {
    path: 'books', component: BooklistComponent, data: { breadcrumb: 'Test Error' }
  },
  {
    path: 'addbook', component: BookaddComponent, data: { breadcrumb: 'Test Error' }
  },
  {
    path: 'editbook/:id', component: BookeditComponent, data: { breadcrumb: 'Test Error' }
  }
];

@NgModule({
  declarations: [],
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
