import { Component, NgModule, OnInit } from '@angular/core';
import { Showtimes } from '../../../models/Showtimes';
import { ShowtimeApiService } from '../../../services/Showtimes/ShowtimeApi.service';
import { FormsModule } from '@angular/forms';
import { CommonModule, NgFor } from '@angular/common';
import { Router, RouterModule } from '@angular/router';
import { environment } from '../../../environments/environment';
import { Input } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Movie } from '../../../models/Movie';
import { MovieApiService } from '../../../services/Movies/MovieApi.service';
import { ElementRef, ViewChild, AfterViewInit } from '@angular/core';
declare var $: any;
@Component({
  selector: 'app-Details',
  standalone: true,
  imports:[FormsModule,CommonModule,RouterModule,NgFor],
  templateUrl: './Details.component.html',
  styleUrls: ['./Details.component.css']
})

export class DetailsComponent implements OnInit {

domainUrl = environment.domainUrl;
 @Input() id:string =''
showtimes:Showtimes[] = []
trailer:string|undefined|null 
movie :Movie |null|undefined;
  constructor(private showtimeService:ShowtimeApiService,private activeRoute:ActivatedRoute,private movieService:MovieApiService,private router:Router) { 
  }

  ngOnInit() {
    this.id=this.activeRoute.snapshot.params['id']
    this.showtimeService.getShowtimesByMovie(this.id).subscribe(
      (data:Showtimes[])=>{
        this.showtimes = data;
        // console.log(this.showtimes)
      }
    )

 this.movieService.getMovieById(this.id).subscribe({
      next:(res)=>{this.movie=res;
      this.trailer =`https://www.youtube.com/embed/${this.movie?.youTubeTrailerId}`;
      console.log(this.trailer)
      },
      error:(err)=>{console.log(err)}
    })

    }

     ngAfterViewInit(): void {
     const modal = document.getElementById('templateVideoModal');
    const iframe = document.getElementById('youtubeVideo') as HTMLIFrameElement;
    
    modal?.addEventListener('show.bs.modal', () => {
      if (this.movie?.youTubeTrailerId) {
        iframe.src = `https://www.youtube.com/embed/${this.movie.youTubeTrailerId}?autoplay=1&mute=1`;
      }
    });

    modal?.addEventListener('hidden.bs.modal', () => {
      iframe.src = '';
    });
  }


  
  }

