import { Component, OnInit } from '@angular/core';
import { AccountApiServiceService } from '../../../Services/Account-api-service.service';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-Login',
  standalone :true,
  imports: [FormsModule,CommonModule],
  templateUrl: './Login.component.html',
  styleUrls: ['./Login.component.css']
})
export class LoginComponent implements OnInit {
 username = '';
  password = '';
  constructor(private accountApiSevice:AccountApiServiceService) { }

  ngOnInit() {
  }

  onSubmit() {
    this.accountApiSevice.login(this.username, this.password).subscribe({
      next: (token) => {
        console.log('Login Success, Token:', token);
        localStorage.setItem('auth_token', token);
      },
      error: (err) => {
        console.error('Login Error:', err);
      }
    });
}
}