import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { JwtHelperService } from '@auth0/angular-jwt';
import { map } from 'rxjs/operators';
import { User } from '../models/User';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  baseURL = 'https://localhost:5001/api/users';
  jwtHelper = new JwtHelperService();
  decodeToken: any;

  constructor(private http: HttpClient) { }

  login(model: any): any {
   return this.http.post(`${this.baseURL}/login`, model).pipe(
     map((response: any) => {
       const user = response;
       if (user) {
         localStorage.setItem('token', user.token);
         this.decodeToken = this.jwtHelper.decodeToken(user.token);
         sessionStorage.setItem('username', this.decodeToken.unique_name);
       }
     })
   );
  }

  register(user: User): any {
    return this.http.post(`${this.baseURL}/register`, user);
  }

  loggedIn(): boolean {
     const token = localStorage.getItem('token');
     return !this.jwtHelper.isTokenExpired(token);
  }

  logout(): void {
    localStorage.removeItem('token');
 }
}
