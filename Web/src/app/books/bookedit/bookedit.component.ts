import { Component, OnInit } from '@angular/core';
import { ApiService } from '../../services/api.service';
import { Router } from '@angular/router'
import { Book } from '../../models/book/book.model';
import { SearchBook } from '../../models/book/book.search.model';
import { IAngularMyDpOptions, IMyDateModel } from 'angular-mydatepicker';
import { NgForm } from '@angular/forms'
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-bookedit',
  templateUrl: './bookedit.component.html',
  styleUrls: ['./bookedit.component.css']
})
export class BookeditComponent implements OnInit {
  isFormSubmitted: boolean = false;
  messageSuccessDiv: boolean = false;
  messageFailedDiv: boolean = false;
  bookId: string = '';
  book: any = Book;
  myDpOptions: IAngularMyDpOptions = {
    dateRange: false,
    dateFormat: 'dd/mm/yyyy'
  };
  constructor(private apiService: ApiService,
    private router: Router,
    private route: ActivatedRoute) { }

  ngOnInit() {
    this.route.paramMap.subscribe(params => {
      var id = params.get('id');
      if (id != null) {
        this.bookId = id;
        this.getBook();
      }
    });
  }

  onSubmit(form: NgForm) {
    if (form.form.valid) {
      this.editBook();
    }
  }

  delete() {
    this.deleteBook();
  }

  getBook() {
    this.apiService.getData<any>('book/get?id=' + this.bookId).subscribe((result) => {
      if (result != null) {
        if (result.success && result.data != null) {
          this.book.title = result.data.title;
          this.book.author = result.data.author;
          this.book.price = result.data.price;

          if (result.data.formattedPublicationDate != null) {
            var year = parseInt(result.data.formattedPublicationDate.split('/')[2]);
            var month = parseInt(result.data.formattedPublicationDate.split('/')[1]);
            var day = parseInt(result.data.formattedPublicationDate.split('/')[0]);
            this.book.publicationDate = { isRange: false, singleDate: { date: { year: year, month: month, day: day } } };
          }
        }
      }
    });
  }

  deleteBook() {
    this.apiService.delete<any>('book/delete?id=' + this.bookId).subscribe((result) => {
      if (result != null) {
        if (result.success && result.data) {
          if (result.message != null && result.message != '') {
            this.messageSuccessDiv = true;
            var successMessage = document.querySelector('#editSuccessMessage');
            if (successMessage != null) {
              successMessage.innerHTML = result.message;
            }

            setTimeout(() => {
              var resetForm = <HTMLFormElement>document.getElementById('frmEdit');
              resetForm.reset();

              this.router.navigate(['/books']);
            }, 2000);
          }
        }
        else {
          if (result.message != null && result.message != '') {
            this.messageFailedDiv = true;
            var successMessage = document.querySelector('#editFailedMessage');
            if (successMessage != null) {
              successMessage.innerHTML = result.message;
            }
          }
        }
      }
    });
  }

  editBook() {
    var day = this.book.publicationDate?.singleDate?.date.day;
    var month = this.book.publicationDate?.singleDate?.date.month;
    var year = this.book.publicationDate?.singleDate?.date.year;

    var book = {
      id: this.bookId,
      title: this.book.title,
      author: this.book.author,
      price: this.book.price,
      formattedPublicationDate: day + "/" + month + "/" + year
    };

    this.apiService.put<any>('book/update', book).subscribe((result) => {
      if (result != null) {
        if (result.success && result.data) {
          if (result.message != null && result.message != '') {
            this.messageSuccessDiv = true;
            var successMessage = document.querySelector('#editSuccessMessage');
            if (successMessage != null) {
              successMessage.innerHTML = result.message;
            }

            var resetForm = <HTMLFormElement>document.getElementById('frmEdit');
            resetForm.reset();

            setTimeout(() => {
              this.router.navigate(['/books']);
            }, 2000);
          }
        }
        else {
          if (result.message != null && result.message != '') {
            this.messageFailedDiv = true;
            var successMessage = document.querySelector('#editFailedMessage');
            if (successMessage != null) {
              successMessage.innerHTML = result.message;
            }
          }
        }
      }
    });
  }
}
