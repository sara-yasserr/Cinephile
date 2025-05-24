import { Component, OnInit } from '@angular/core';
import { Input } from '@angular/core';
import { ActivatedRoute, Router, RouterLink } from '@angular/router';
import { TicketApiService } from '../../../services/Tickets/TicketApi.service';
import { Tickets } from '../../../models/Tickets';
import { CommonModule, NgFor } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { BookingApiService } from '../../../services/Booking/BookingApi.service';
import { Booking } from '../../../models/Booking';
import { AuthApiService } from '../../../services/User/AuthApi.service';
@Component({
  selector: 'app-tickets',
  imports : [CommonModule,FormsModule, NgFor,RouterLink],
  templateUrl: './tickets.component.html',
  styleUrls: ['./tickets.component.css']
})
export class TicketsComponent implements OnInit {
@Input() ShowtimeId:string =''; 
tickets :Tickets[] = [];
booking : Booking |any;
userId :string = '';
ticketId :string ='';
isProcessing = false;

  constructor(private activeRoute:ActivatedRoute,private ticketService:TicketApiService,private bookingService:BookingApiService,private authService:AuthApiService
    ,private router:Router
  ) { }

  ngOnInit() {
     this.ShowtimeId = this.activeRoute.snapshot.params['ShowtimeId'];
    this.getCurrentUser();

      this.ticketService.getTicket().subscribe(
        (data:Tickets[])=>{
          this.tickets = data;
          console.log(this.tickets)
        }
      ) }

  async proceedToPayment(ticketId: string) {
  this.isProcessing = true;
  
  try {
    this.selectTicket(ticketId);
    const booking = await this.createBooking(ticketId);
    this.router.navigate(['/payment', booking.id]);
  } catch (error) {
    console.error('Payment process failed:', error);
  } finally {
    this.isProcessing = false;
  }
}

getCurrentUser() {
  this.userId = this.authService.getUserId()
}

 selectTicket(ticketId: string) {
    this.ticketId = ticketId;
  }
private createBooking(ticketId: string): Promise<any> {
  return new Promise((resolve, reject) => {
    const bookingData = {
      UserId: this.userId,
      TicketId: ticketId,
      ShowtimeId: this.ShowtimeId
    };
   console.log(bookingData)
   this.bookingService.PostBooking(bookingData).subscribe({
      next: (booking) => resolve(booking),
      error: (err) => {
        console.error('Full error response:', err);
        if (err.error) {
 
          const errorMsg = typeof err.error === 'string' ? err.error : 
                         err.error.message || JSON.stringify(err.error);
          reject(new Error(errorMsg));
        } else {
          reject(new Error('Failed to create booking'));
        }
      }
    });
  });
}

}
