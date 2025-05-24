import { Component, OnInit } from '@angular/core';
import { AuthApiService } from '../../../services/User/AuthApi.service';
import { Router, RouterModule } from '@angular/router';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-login',
  imports:[FormsModule,CommonModule,RouterModule],
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
 username = '';
 password = '';
  constructor(private authApi:AuthApiService,private router:Router) { }
 
  ngOnInit() {
  }
  onSubmit() {
    this.authApi.login(this.username, this.password).subscribe({
      next: (token) => {
        this.navigateToHome();
        localStorage.setItem('auth_token', token);
      },
      error: (err) => {
        console.error('Login Error:', err);
      }
    });
           }

           navigateToHome() {
  this.router.navigate(['/index']);}
}
