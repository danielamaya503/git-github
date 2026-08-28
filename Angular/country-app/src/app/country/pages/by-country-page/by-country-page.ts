import {Component, resource, signal} from '@angular/core';
import {CountryListTable} from '../../component/country-list-table/country-list-table';
import {CountrySearchInput} from '../../component/country-search-input/country-search-input';
import {CountryServices} from '../../services/CountryServices';
import {firstValueFrom} from 'rxjs';

@Component({
  selector: 'by-country-page',
  imports: [
    CountrySearchInput,
    CountryListTable,
  ],
  templateUrl: './by-country-page.html',
})
export class ByCountryPage {

  constructor(private countryService: CountryServices) {
  }

  query = signal('');

  countryResource = resource(
    {
      params: () => ({
        query: this.query(),
      }),
      loader: async ({params}) => {
        if (!params.query)
          return [];

        return await firstValueFrom(
          this.countryService.searchByCountry(params.query)
        );
      }
    }
  );

}
