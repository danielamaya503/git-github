import {inject, Injectable} from '@angular/core';
import {HttpClient} from '@angular/common/http';
import {environment} from '../../../environments/environment';
import {RestCountry} from '../interfaces/rest-countries';
import {map, Observable, catchError, throwError} from 'rxjs';
import {Country} from '../interfaces/country.interface';
import {CountryMapper} from '../Mappers/country.mapper';

@Injectable({
  providedIn: 'root',
})
export class CountryServices {
  httpService = inject(HttpClient);

  searchByCapital(query: string): Observable<Country[]>{
    query = query.toLowerCase();

    return this.httpService
      .get<RestCountry[]>(`${environment.apiUrlCountries}/capital/${query}`)
      //metodo que nos devuelve el array usando rxjs
      .pipe
      (
        map( rest => CountryMapper.mapRestCountryArrayToCountryArray(rest)),
        catchError( error => {
          console.log('Error Catch ',error);

          return throwError(
            () => new Error(`No se pudo encontrar la capital: ${query}`)
          );
        })
      )

  }
  //const url = `${environment.apiUrlCountries}/name/${query}`

  searchByCountry(query: string) : Observable<Country[]>
  {
    query = query.toLowerCase();

    return this.httpService
      .get<RestCountry[]>(`${environment.apiUrlCountries}/name/${query}`)
       .pipe
       (
         map(rest => CountryMapper.mapRestCountryArrayToCountryArray(rest)),
         catchError(error =>
         {
           console.log('Error Catch', error);
           return throwError(
             () => new Error(`No se pudo encontrar el pais: ${query}`)
           );
         })

       )
  }
}
