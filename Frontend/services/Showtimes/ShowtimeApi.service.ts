import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment';
import { Observable } from 'rxjs';
import { Showtimes } from '../../models/Showtimes';
@Injectable({
  providedIn: 'root'
})
export class ShowtimeApiService {
private apiUrl = `${environment.baseUrl}/showtime`

constructor(private httpClient:HttpClient) { }

getShowtime(): Observable<Showtimes[]> {
    return this.httpClient.get<Showtimes[]>(`${this.apiUrl}`);
  }

getShowtimesByMovie(id: string):Observable<Showtimes[]> {
    return this.httpClient.get<Showtimes[]>(`${this.apiUrl}/movie/${id}`);
  }

getShowtimeById(id: string): Observable<Showtimes> {
    return this.httpClient.get<Showtimes>(`${this.apiUrl}/${id}`);
  }

PostShowtime(ShowtimeData: any): Observable<any> {
    return this.httpClient.post(`${this.apiUrl}`, ShowtimeData);
  }

PutShowtime(id: string, ShowtimeData: any): Observable<any> {
    return this.httpClient.put(`${this.apiUrl}/${id}`, ShowtimeData);
  }

  deleteShowtime(id: string): Observable<any> {
    return this.httpClient.delete(`${this.apiUrl}/${id}`);
  }
}
