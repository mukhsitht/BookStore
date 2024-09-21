import { Component } from '@angular/core';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css']
})
export class HeaderComponent {
  toggleSideMenu() {
    var sidebar = document.querySelector('#sidebar');
    if (sidebar != null) {
      if (sidebar.classList.contains("hide-sidebar")) {
        sidebar.classList.remove("hide-sidebar");
        sidebar.classList.add("show-sidebar");
      }
      else {
        sidebar.classList.add("hide-sidebar");
        sidebar.classList.remove("show-sidebar");
      }
    }
  }
}
