import { Component, OnInit } from '@angular/core';
import { Router, RouterModule } from '@angular/router';
import { AuthApiService } from '../../../services/User/AuthApi.service';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { HttpClientModule } from '@angular/common/http';

@Component({
  selector: 'app-register',
  imports:[RouterModule,FormsModule,CommonModule,HttpClientModule],
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {
username = '';
  password = '';
  userData = {
    Username: '',
    Email: '',
    Password: ''
  };
  confirmPassword = '';
  constructor(private authService:AuthApiService,private router: Router) { }


  ngOnInit() {
  }

     passwordsMatch(): boolean {
    return this.userData.Password === this.confirmPassword;}


 onSubmitReg() {
    if (!this.passwordsMatch()) return;
    
    this.authService.register(
      this.userData.Username,
      this.userData.Email,
      this.userData.Password
    ).subscribe({
      next: () =>this.navigateToLogin(),
      error: (err) => console.error('Register error:', err)
    });
  }


  navigateToLogin() {
  this.router.navigate(['/login']);}
}
