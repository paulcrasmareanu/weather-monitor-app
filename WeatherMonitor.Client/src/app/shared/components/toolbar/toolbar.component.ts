import {Component, EventEmitter, OnInit, Output} from '@angular/core';
@Component({
  selector: 'app-toolbar',
  templateUrl: './toolbar.component.html',
  styleUrls: ['./toolbar.component.scss']
})
export class ToolbarComponent implements OnInit {


  @Output() toggleSidebarEvent = new EventEmitter<any>();
  constructor()
  {}

  ngOnInit(): void {

  }
  toggleSidebar() {
    this.toggleSidebarEvent.emit();
  }

}
