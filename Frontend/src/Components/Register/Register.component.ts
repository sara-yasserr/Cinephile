import { Component, OnInit } from '@angular/core';
import { AccountApiServiceService } from '../../../Services/Account-api-service.service';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-Register',
  imports:[FormsModule,CommonModule],
  templateUrl: './Register.component.html',
  styleUrls: ['./Register.component.css']
})
export class RegisterComponent implements OnInit {
userData = {
    Username: '',
    Email: '',
    Password: ''
  };
  confirmPassword = '';
  constructor(private accountApiService:AccountApiServiceService) { }

  ngOnInit() {
  }

  passwordsMatch(): boolean {
    return this.userData.Password === this.confirmPassword;
  }

  onSubmit() {
    if (!this.passwordsMatch()) return;
    
    this.accountApiService.register(
      this.userData.Username,
      this.userData.Email,
      this.userData.Password
    ).subscribe({
      next: () => alert('Register success'),
      error: (err) => console.error('Register error:', err)
    });
}

}
