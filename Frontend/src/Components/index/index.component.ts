import { Component, OnInit } from '@angular/core';
import { MovieApiService } from '../../../services/Movies/MovieApi.service';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { Router, RouterModule } from '@angular/router';
import { Movie } from '../../../models/Movie';
import { environment } from '../../../environments/environment';
@Component({
  selector: 'app-index',
  imports:[FormsModule,CommonModule,RouterModule],
  templateUrl: './index.component.html',
  styleUrls: ['./index.component.css']
})
export class IndexComponent implements OnInit {
 movies :Movie[] = [];
 domainUrl = environment.domainUrl;
  constructor(private movieService:MovieApiService,private router:Router) { }

  ngOnInit() {
   this.movieService.getMovies().subscribe(
      (data: Movie[]) => {
        this.movies = data;
      }
    );
  }

  
}
