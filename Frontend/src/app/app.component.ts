import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { LoginComponent } from "../Components/Login/Login.component";
import { FormsModule } from '@angular/forms';
import { RegisterComponent } from "../Components/Register/Register.component";

@Component({
  selector: 'app-root',
  imports: [RouterOutlet, LoginComponent, FormsModule, RegisterComponent],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent {
  title = 'AICodeReviewer-Frontend';
}
