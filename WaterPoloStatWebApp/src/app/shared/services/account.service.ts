import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { NuovaRegistrazione } from '../models/nuovaRegistrazione';

@Injectable({
  providedIn: 'root'
})
export class AccountService {
  headers = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json'
    })
  };
  constructor(public http: HttpClient) { }
  
  registraUtente(item: NuovaRegistrazione): Observable<NuovaRegistrazione> {
    return this.http.post<NuovaRegistrazione>(`${environment.apiHost}account/registrazione`, item, this.headers);
  }
}
