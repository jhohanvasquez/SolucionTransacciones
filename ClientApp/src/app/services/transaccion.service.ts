import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { ResponseApi } from '../interfaces/response-api';
import { Transaccion } from '../interfaces/transaccion';

@Injectable({
  providedIn: 'root'
})
export class TransaccionService {
  apiBase: string = '/api/transaccion/'
  constructor(private http: HttpClient) { }

 registrar(request: Transaccion): Observable<ResponseApi> {

   return this.http.post<ResponseApi>(`${this.apiBase}Registrar`, request, { headers: { 'Content-Type': 'application/json;charset=utf-8' } })

 }

  historal(buscarPor:string,numeroTransaccion:string,fechaInicio:string,fechaFin:string): Observable<ResponseApi> {

    return this.http.get<ResponseApi>(`${this.apiBase}Historial?buscarPor=${buscarPor}&numeroTransaccion=${numeroTransaccion}&fechaInicio=${fechaInicio}&fechaFin=${fechaFin}`);

  }

  reporte(fechaInicio: string, fechaFin: string): Observable<ResponseApi> {

    return this.http.get<ResponseApi>(`${this.apiBase}Reporte?fechaInicio=${fechaInicio}&fechaFin=${fechaFin}`);

  }

  consultar(id: number): Observable<ResponseApi> {

    return this.http.get<ResponseApi>(`${this.apiBase}Consultar/${id}`);

  }

  ConsultarTransacciones(id: string, idRol: string): Observable<ResponseApi> {

    return this.http.get<ResponseApi>(`${this.apiBase}ConsultarTransacciones/${id}/${idRol}`);

  }
}
