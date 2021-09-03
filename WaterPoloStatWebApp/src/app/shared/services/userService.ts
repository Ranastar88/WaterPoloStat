import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { User } from '../models/user';
import { NuovaRegistrazione } from '../models/nuovaRegistrazione';
import { Observable } from 'rxjs';


@Injectable({ providedIn: 'root' })
export class UserService {
    constructor(private http: HttpClient) { }

    headers = {
        headers: new HttpHeaders({
          'Content-Type': 'application/json'
        })
      };
    getAll() {
        return this.http.get<User[]>(`${environment.apiUrl}/users`);
    }

    registra(item: NuovaRegistrazione): Observable<NuovaRegistrazione> {
        return this.http.post<NuovaRegistrazione>(`${environment.apiUrl}account/registrazione`, item, this.headers);
      }
}