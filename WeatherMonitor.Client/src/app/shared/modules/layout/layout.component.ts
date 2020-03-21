import {Component, HostListener, OnInit, ViewChild} from '@angular/core';
import {MatSidenav} from '@angular/material/sidenav';

@Component({
  selector: 'app-layout',
  templateUrl: './layout.component.html',
  styleUrls: ['./layout.component.scss']
})
export class LayoutComponent implements OnInit {

  @ViewChild('sidebar', {static : false}) sidebar: MatSidenav;
  sidebarOpen = true;


  constructor() {
  }

  ngOnInit(): void {
  }

  toggleSidebar() {
    this.sidebarOpen = !this.sidebarOpen;
  }

  @HostListener('window:resize', ['$event'])
  onResize(event) {
    this.sidebarOpen = event.target.innerWidth >= 800;
    if (event.target.innerWidth < 700) {
      this.sidebar.mode = 'over';
    } else {
      this.sidebar.mode = 'side';
    }
  }
}
