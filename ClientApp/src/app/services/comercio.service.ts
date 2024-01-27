import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Comercio } from '../interfaces/comercio';
import { ResponseApi } from '../interfaces/response-api';

@Injectable({
  providedIn: 'root'
})
export class ComercioService {
  apiBase: string = '/api/comercio/'
  constructor(private http: HttpClient) {
  }


  getComercios(): Observable<ResponseApi> {

    return this.http.get<ResponseApi>(`${this.apiBase}Lista`)

  }

  save(request: Comercio): Observable<ResponseApi> {

    return this.http.post<ResponseApi>(`${this.apiBase}Guardar`, request, { headers: { 'Content-Type': 'application/json;charset=utf-8' } })

  }

  edit(request: Comercio): Observable<ResponseApi> {

    return this.http.put<ResponseApi>(`${this.apiBase}Editar`, request, { headers: { 'Content-Type': 'application/json;charset=utf-8' } })

  }

  delete(id: number): Observable<ResponseApi> {

    return this.http.delete<ResponseApi>(`${this.apiBase}Eliminar/${id}`);

  }
}
