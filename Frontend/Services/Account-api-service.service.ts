import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class AccountApiServiceService {
private apiUrl = 'https://localhost:44372/api/Account'
constructor(private httpClient:HttpClient) { }

login(username: string, password: string): Observable<any> {
   return this.httpClient.post(
    `${this.apiUrl}/login`, 
    { username, password },
    { responseType: 'text' } 
  );
  }

register(username: string, email: string, password: string): Observable<any> {
    return this.httpClient.post<void>(`${this.apiUrl}/register`, { Username: username, Email: email, Password: password}
    );
  }
}
