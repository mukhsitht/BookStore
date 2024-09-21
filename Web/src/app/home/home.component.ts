import { Component, OnInit } from '@angular/core';
import { ApiService } from '../services/api.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {
  bookCount: number = 0;
  constructor(private apiService: ApiService) { }

  ngOnInit() {
    this.getHomePageContent();
  }

  getHomePageContent() {
    this.apiService.getData<any>('book/gethomepagecontent').subscribe((result) => {
      if (result != null) {
        if (result.success && result.data != null) {
          this.bookCount = result.data.totalBooks;
        }
      }
    });
  }
}
