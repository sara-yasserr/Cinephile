import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { environment } from '../../environments/environment';
import { User } from '../../models/User';
@Injectable({
  providedIn: 'root'
})
export class AuthApiService {
private apiUrl = `${environment.baseUrl}/account`
username : string ='';
userId : string = '';
user : User | any;
constructor(private httpClient:HttpClient) { 

}
getUserId():string{
  this.user= this.getUserByUsername(this.username).subscribe(
          (data:User)=>{
            this.user = data;
            console.log(this.user)
          }
        )
  console.log(this.user)
  return this.userId;
}
login(username: string, password: string): Observable<any> {
  this.username = username;
   return this.httpClient.post(
    `${this.apiUrl}/login`, 
    { username, password },
    { responseType: 'text' } 
  );
  }

getUserByUsername(username:string):Observable<User>{
 return this.user = this.httpClient.get<User>( `${this.apiUrl}?username=${username}`)
}
register(username: string, email: string, password: string): Observable<any> {
    return this.httpClient.post<void>(`${this.apiUrl}/register`, { Username: username, Email: email, Password: password}
    );
  }

  
}
