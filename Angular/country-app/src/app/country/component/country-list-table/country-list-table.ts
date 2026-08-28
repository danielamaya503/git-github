import {Component, Input} from '@angular/core';
import {TableModule} from 'primeng/table';
import {Country} from '../../interfaces/country.interface';
import {DecimalPipe} from '@angular/common';
import {RouterLink} from '@angular/router';

@Component({
  selector: 'country-list-table',
  imports: [
    TableModule,
    DecimalPipe,
    RouterLink
  ],
  templateUrl: './country-list-table.html',
})
export class CountryListTable {

  //Resivir data de search
  @Input({required: true}) countries: Country[] = [];
}
