import { Component, OnInit } from '@angular/core';
import { ApiService } from '../../services/api.service';
import { Book } from '../../models/book/book.model';
import { SearchBook } from '../../models/book/book.search.model';
import { IAngularMyDpOptions, IMyDateModel } from 'angular-mydatepicker';
import { NgForm } from '@angular/forms'

@Component({
  selector: 'app-booklist',
  templateUrl: './booklist.component.html',
  styleUrls: ['./booklist.component.css']
})
export class BooklistComponent implements OnInit {
  books: any = [Book]
  searchBook: any = SearchBook;
  selectedSortingId: string | null = null;
  myDpOptions: IAngularMyDpOptions = {
    dateRange: false,
    dateFormat: 'dd/mm/yyyy'
  };
  constructor(private apiService: ApiService) {
    this.searchBook.price = '';
  }

  ngOnInit() {
    this.getBooks();
  }

  onSortingChange(event: Event): void {
    const selectElement = event.target as HTMLSelectElement;
    this.selectedSortingId = selectElement.value == '' ? '0' : selectElement.value;
    this.getBooks();
  }

  getBooks() {
    var searchBook = {
      title: this.searchBook.title,
      author: this.searchBook.author,
      price: this.searchBook.price,
      date: this.searchBook.date?.singleDate?.formatted,
      sortingId: this.selectedSortingId
    };

    this.apiService.post<any>('book/getall', searchBook).subscribe((result) => {
      if (result != null) {
        if (result.success && result.data != null) {
          this.books = result.data;
        }
      }
    });
  }
}
