import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import * as moment from 'moment';
import { User } from '../models/user';
import { BehaviorSubject, Observable } from "rxjs";
import { environment } from 'src/environments/environment';
import { catchError, map } from 'rxjs/operators';
import { BaseResult } from '../models/baseResult';

@Injectable({
    providedIn: 'root'
})
export class AuthService {
    private currentUserSubject: BehaviorSubject<User | null>;
    public currentUser: Observable<User | null>;

    constructor(private http: HttpClient) {
        let localUser = localStorage.getItem('currentUser');
        console.log(localUser);
        if (localUser){
            this.currentUserSubject = new BehaviorSubject<User | null>(JSON.parse(localUser));            
        }else{
            this.currentUserSubject = new BehaviorSubject<User | null>(null);
        }
        
        this.currentUser = this.currentUserSubject.asObservable();

    }

    public get currentUserValue(): User | null {
        return this.currentUserSubject.value;
    }

    login(username: string, password: string) {
        return this.http.post<User>(`${environment.apiUrl}account/login`, { email: username, password: password })
            .pipe(map(user => {
                // store user details and jwt token in local storage to keep user logged in between page refreshes
                localStorage.setItem('currentUser', JSON.stringify(user));
                this.currentUserSubject.next(user);
                return user;
            }));
    }

    logout() {
        // remove user from local storage to log user out
        localStorage.removeItem('currentUser');
        this.currentUserSubject.next(null);
    }
}
