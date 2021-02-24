import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Game } from '../models/game.model';
import { Move } from '../models/move.model';

@Injectable({
  providedIn: 'root'
})
export class GameService {
  readonly rootUrl = 'https://localhost:44387/';
  reqHeaders = new HttpHeaders({ 'Content-Type': 'application/json', 'No-Auth': 'True' });
  constructor(private http: HttpClient) { }

  
  getAllGames(): Observable<Game[]> {
    return this.http.get<Game[]>(this.rootUrl + `api/game/all`);
  }

  getGameById(gameId: number): Observable<Game> {
    return this.http.get<Game>(this.rootUrl + `api/game/id?id${gameId}`);
  }
  
  addGame(game: Game): Observable<number>  {
    return this.http.post<number>(this.rootUrl + 'api/game', game);
  }

  updateGame(game: Game) {
    return this.http.put(this.rootUrl + 'api/game', game);
  }

  addMoves(moves: Move[])  {
    return this.http.post(this.rootUrl + 'api/game/move', moves);
  }

}
