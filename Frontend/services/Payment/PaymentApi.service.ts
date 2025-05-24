import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from '../../environments/environment';
import { Payment } from '../../models/Payment';
@Injectable({
  providedIn: 'root'
})
export class PaymentApiService {
private apiUrl = `${environment.baseUrl}/payment`
constructor(private httpClient:HttpClient) { }

getPayments(): Observable<Payment[]> {
    return this.httpClient.get<Payment[]>(`${this.apiUrl}`);
  }

getPaymentById(id: string): Observable<any> {
  console.log(id);
    return this.httpClient.get(`${this.apiUrl}/${id}`);
  }

PostPayment(PaymentData: any): Observable<any> {
    return this.httpClient.post(`${this.apiUrl}`, PaymentData);
  }

PutPayment(id: string,PaymentData: any): Observable<any> {
    return this.httpClient.put(`${this.apiUrl}/${id}`,PaymentData);
  }

  deletePayment(id: string): Observable<any> {
    return this.httpClient.delete(`${this.apiUrl}/${id}`);
  }
}
