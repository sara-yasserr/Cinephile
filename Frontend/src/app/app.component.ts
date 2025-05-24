import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { IndexComponent } from "../components/index/index.component";
import { provideHttpClient } from '@angular/common/http';
import { FooterComponent } from "../components/footer/footer.component";

@Component({
  selector: 'app-root',
  imports: [RouterOutlet, IndexComponent, FooterComponent],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent {
  title = 'Cinephile';
}
