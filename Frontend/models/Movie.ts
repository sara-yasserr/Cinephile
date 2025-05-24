export interface Movie {
  id: number;
  title: string;
  releaseYear: number;
  director: string;
  runtime: number;
  backgroundPath: string;
  posterPath: string;
  description: string;
  youTubeTrailerId: string;
  language: string;
  genres: string[];
  showtimes: string[];
}