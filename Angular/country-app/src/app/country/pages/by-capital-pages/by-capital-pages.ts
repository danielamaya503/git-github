import {Component, inject, resource, signal} from '@angular/core';
import {CountrySearchInput} from '../../component/country-search-input/country-search-input';
import {CountryListTable} from '../../component/country-list-table/country-list-table';
import {CountryServices} from '../../services/CountryServices';
import {Country} from '../../interfaces/country.interface';
import {async, firstValueFrom} from 'rxjs';

@Component({
  selector: 'app-by-capital-pages',
  imports: [
    CountrySearchInput,
    CountryListTable
  ],
  templateUrl: './by-capital-pages.html',
})
export class ByCapitalPages {

  countryServices = inject(CountryServices);
  query = signal('');

  countryResource = resource(
    {
      params: () => (
        {
          query: this.query()
        }
      ),
      loader: async( {params} ) =>
      {
        if( !params.query)
          return [];

        return await  firstValueFrom(
          this.countryServices.searchByCapital(params.query)
        );


      }

    })

  /*
  isLoading = signal(false);
  isError = signal<string | null>(null);
  countries = signal<Country[]>([]);

  onSearch(query: string){

    if(this.isLoading())
      return;

    this.isLoading.set(true);
    this.isError.set(null);

    this.countryServices.searchByCapital(query).subscribe(
      {
        next: (countries) =>
        {
          this.isLoading.set(false);
          this.countries.set(countries);
        },
        error: (err) =>
        {
          this.isLoading.set(false);
          this.countries.set([]);
          this.isError.set(err);
        }
    });
  }
  */
}

