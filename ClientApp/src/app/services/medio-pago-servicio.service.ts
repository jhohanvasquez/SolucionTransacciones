import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { ResponseApi } from '../interfaces/response-api';


@Injectable({
  providedIn: 'root'
})
export class MedioPagoService {
  apiBase: string = '/api/medioPago/'
  constructor(private http: HttpClient) { }

  getMedioPagos(): Observable<ResponseApi> {
    return this.http.get<ResponseApi>(`${this.apiBase}Lista`)
  }
}
