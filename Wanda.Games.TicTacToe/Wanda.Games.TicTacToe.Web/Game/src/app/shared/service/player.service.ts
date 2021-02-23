import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Player } from '../models/player.model';

@Injectable({
  providedIn: 'root'
})
export class PlayerService {
  readonly rootUrl = 'https://localhost:44387/';
  reqHeaders = new HttpHeaders({ 'Content-Type': 'application/json', 'No-Auth': 'True' });
  constructor(private http: HttpClient) { }

  
  getAllPlayers(): Observable<Player[]> {
    return this.http.get<Player[]>(this.rootUrl + `api/player`);
  }

  getPlayerById(playerId: number): Observable<Player> {
    return this.http.get<Player>(this.rootUrl + `api/player/id?id${playerId}`);
  }

}
