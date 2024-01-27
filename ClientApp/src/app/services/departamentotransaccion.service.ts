import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { ResponseApi } from '../interfaces/response-api';

@Injectable({
  providedIn: 'root'
})
export class DepartamentoTransaccionService {
  apiBase: string = '/api/departamentotransaccion/'
  constructor(private http: HttpClient) { }

  getDepartamentoTransaccions(): Observable<ResponseApi> {
    return this.http.get<ResponseApi>(`${this.apiBase}Lista`)
  }
}
