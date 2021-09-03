import { HttpClient, HttpHeaders } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { environment } from "src/environments/environment";
import { BaseResult } from "../models/baseResult";
import { ElencoPartita } from "../models/elencoPartita";
import { NewEditPartita } from "../models/newEditPartita";

@Injectable({ providedIn: 'root' })
export class PartitaService {
  constructor(private http: HttpClient) { }

  headers = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json'
    })
  };

  nuova(item: NewEditPartita): Observable<NewEditPartita> {
    return this.http.post<NewEditPartita>(`${environment.apiUrl}partite`, item, this.headers);
  }
  aggiorna(id: number, item: NewEditPartita): Observable<NewEditPartita> {
    return this.http.put<NewEditPartita>(`${environment.apiUrl}partite`, item, this.headers);
  }

  getPartite(): Observable<ElencoPartita[]> {
    return this.http.get<ElencoPartita[]>(`${environment.apiUrl}partite`, this.headers);
  }

  getPartita(id: number): Observable<NewEditPartita> {
    return this.http.get<NewEditPartita>(`${environment.apiUrl}partite/${id}`, this.headers);
  }
}