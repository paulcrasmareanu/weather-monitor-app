import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { SelectFieldsComponent } from 'src/app/modules/weather-forecast/select-fields/select-fields.component';
import { FlexModule } from '@angular/flex-layout';
import { MatCardModule } from '@angular/material/card';
import { MatOptionModule } from '@angular/material/core';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatSelectModule } from '@angular/material/select';
import { MatSlideToggleModule } from '@angular/material/slide-toggle';
import { EnumToArrayPipe } from '../pipes/enum-to-array.pipe';
import { ReactiveFormsModule } from '@angular/forms';



@NgModule({
  declarations: [
    SelectFieldsComponent,
    EnumToArrayPipe
  ],
  imports: [
    CommonModule,
    ReactiveFormsModule,
    FlexModule,
    MatFormFieldModule,
    MatOptionModule,
    MatSelectModule,
    MatCardModule,
    MatSlideToggleModule,
  ],
  exports:[
    FlexModule,
    MatFormFieldModule,
    MatOptionModule,
    MatSelectModule,
    MatCardModule,
    MatSlideToggleModule,
    SelectFieldsComponent,
    EnumToArrayPipe,
  ]
})
export class SharedModule { }
