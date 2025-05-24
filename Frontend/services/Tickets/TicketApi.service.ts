import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../environments/environment';
import { Tickets } from '../../models/Tickets';
@Injectable({
  providedIn: 'root'
})
export class TicketApiService {
private apiUrl = `${environment.baseUrl}/ticket`

constructor(private httpClient:HttpClient) { }
getTicket(): Observable<Tickets[]> {
    return this.httpClient.get<Tickets[]>(`${this.apiUrl}`);
  }

getTicketById(id: string): Observable<any> {
  console.log(id);
    return this.httpClient.get(`${this.apiUrl}/${id}`);
  }

PostTicket(TicketData: any): Observable<any> {
    return this.httpClient.post(`${this.apiUrl}`, TicketData);
  }

PutTicket(id: string, TicketData: any): Observable<any> {
    return this.httpClient.put(`${this.apiUrl}/${id}`, TicketData);
  }

  deleteTicket(id: string): Observable<any> {
    return this.httpClient.delete(`${this.apiUrl}/${id}`);
  }
}
