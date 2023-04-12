import { environment } from 'src/environments/environment';
import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, of } from 'rxjs';
import { RequestTipoCambio } from '../models/RequestTipoCambio';


const httpOptions = {
    headers: new HttpHeaders({
        'Content-Type': 'application/json'
    })
};

@Injectable({
    providedIn: 'root'
})
export class TablaConversionService{

    protected readonly apiUrl = environment.BASE_API;
    protected readonly TOKEN = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJuYW1laWQiOiIxIiwibmFtZSI6IlRpcG9DYW1iaW8iLCJyb2xlIjoiQWRtaW5pc3RyYWRvciIsIm5iZiI6MTY4MTI1MTM0MywiZXhwIjoxNjgxMjUyNzgzLCJpYXQiOjE2ODEyNTEzNDN9.HoJsoCASDBJ-x5fo9L-UC1UAuzC5jkDayeKXNr1tKqU";
    constructor(public httpclient: HttpClient) {
    }


      Modificar(request: RequestTipoCambio): Observable<any> {
        const url = `${this.apiUrl}/api/TablaConversion`;
        const headers = new HttpHeaders().set('Authorization', `Bearer ${this.TOKEN}`);
        return this.httpclient.post<RequestTipoCambio>(url, request, { headers });
      }



}
