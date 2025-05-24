import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from '../../environments/environment';
import { Movie } from '../../models/Movie';

@Injectable({
  providedIn: 'root'
})
export class MovieApiService {
private apiUrl = `${environment.baseUrl}/movie`
constructor(private httpClient:HttpClient) { }

getMovies(): Observable<Movie[]> {
    return this.httpClient.get<Movie[]>(`${this.apiUrl}`);
  }

getMovieById(id: string): Observable<any> {
  console.log(id);
    return this.httpClient.get(`${this.apiUrl}/${id}`);
  }

PostMovie(movieData: any): Observable<any> {
    return this.httpClient.post(`${this.apiUrl}`, movieData);
  }

PutMovie(id: string, movieData: any): Observable<any> {
    return this.httpClient.put(`${this.apiUrl}/${id}`, movieData);
  }

  deleteMovie(id: string): Observable<any> {
    return this.httpClient.delete(`${this.apiUrl}/${id}`);
  }

}
