import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import {LayoutComponent} from './layout.component';
import {ToolbarComponent} from '../../components/toolbar/toolbar.component';
import {MatToolbarModule} from '@angular/material/toolbar';
import {SideBarComponent} from '../../components/side-bar/side-bar.component';
import {MatSidenavModule} from '@angular/material/sidenav';
import {LayoutRoutingModule} from './layout-routing.module';
import {MatButtonModule} from '@angular/material/button';
import {MatIconModule} from '@angular/material/icon';
import {MatListModule} from '@angular/material/list';



@NgModule({
  declarations: [
    LayoutComponent,
    ToolbarComponent,
    SideBarComponent],
  imports: [
    CommonModule,
    MatToolbarModule,
    MatSidenavModule,
    LayoutRoutingModule,
    MatButtonModule,
    MatIconModule,
    MatListModule
  ]
})
export class LayoutModule { }
