import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Player } from '../models/player.model';

@Injectable({
  providedIn: 'root'
})
export class PlayerService {
  readonly rootUrl = 'http://localhost:56571';
  reqHeaders = new HttpHeaders({ 'Content-Type': 'application/json', 'No-Auth': 'True' });
  constructor(private http: HttpClient) { }

  
  getAllPlayers(): Observable<Player[]> {
    return this.http.get<Player[]>(this.rootUrl + `api/player`, { headers: this.reqHeaders });
  }

  getPlayerById(playerId: number): Observable<Player> {
    return this.http.get<Player>(this.rootUrl + `api/player/id?id${playerId}`);
  }

}
