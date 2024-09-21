import { Component, OnInit } from '@angular/core';
import { ApiService } from '../../services/api.service';
import { Router } from '@angular/router'
import { Book } from '../../models/book/book.model';
import { SearchBook } from '../../models/book/book.search.model';
import { IAngularMyDpOptions, IMyDateModel } from 'angular-mydatepicker';
import { NgForm } from '@angular/forms'

@Component({
  selector: 'app-bookadd',
  templateUrl: './bookadd.component.html',
  styleUrls: ['./bookadd.component.css']
})
export class BookaddComponent {
  isFormSubmitted: boolean = false;
  messageSuccessDiv: boolean = false;
  messageFailedDiv: boolean = false;
  book: any = Book;
  myDpOptions: IAngularMyDpOptions = {
    dateRange: false,
    dateFormat: 'dd/mm/yyyy'
  };
  constructor(private apiService: ApiService,
    private router: Router) {
    this.book.title = '';
    this.book.author = '';
    this.book.price = '';
    this.book.publicationDate = '';
  }

  onSubmit(form: NgForm) {
    if (form.form.valid) {
      this.addBook();
    }
  }

  addBook() {
    var day = this.book.publicationDate?.singleDate?.date.day;
    var month = this.book.publicationDate?.singleDate?.date.month;
    var year = this.book.publicationDate?.singleDate?.date.year;

    var book = {
      title: this.book.title,
      author: this.book.author,
      price: this.book.price,
      formattedPublicationDate: day + "/" + month + "/" + year
    };

    this.apiService.post<any>('book/add', book).subscribe((result) => {
      if (result != null) {
        if (result.success && result.data) {
          if (result.message != null && result.message != '') {
            this.messageSuccessDiv = true;
            var successMessage = document.querySelector('#addSuccessMessage');
            if (successMessage != null) {
              successMessage.innerHTML = result.message;
            }

            setTimeout(() => {
              var resetForm = <HTMLFormElement>document.getElementById('frmAdd');
              resetForm.reset();

              this.router.navigate(['/books']);
            }, 2000);
          }
        }
        else {
          if (result.message != null && result.message != '') {
            this.messageFailedDiv = true;
            var successMessage = document.querySelector('#addFailedMessage');
            if (successMessage != null) {
              successMessage.innerHTML = result.message;
            }
          }
        }
      }
    });
  }
}
