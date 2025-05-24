import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from '../../environments/environment';
import { Booking } from '../../models/Booking';

@Injectable({
  providedIn: 'root'
})
export class BookingApiService {
private apiUrl = `${environment.baseUrl}/booking`
constructor(private httpClient:HttpClient) { }

getBookings(): Observable<Booking[]> {
    return this.httpClient.get<Booking[]>(`${this.apiUrl}`);
  }

getBookingById(id: string): Observable<any> {
  console.log(id);
    return this.httpClient.get(`${this.apiUrl}/${id}`);
  }

PostBooking(BookingData: any): Observable<Booking> {
    return this.httpClient.post<Booking>(`${this.apiUrl}`, BookingData);
  }

PutBooking(id: string,BookingData: any): Observable<any> {
    return this.httpClient.put(`${this.apiUrl}/${id}`,BookingData);
  }

  deleteBooking(id: string): Observable<any> {
    return this.httpClient.delete(`${this.apiUrl}/${id}`);
  }
}
