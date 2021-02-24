import { Component, OnInit } from '@angular/core';
import { Game } from '../shared/models/game.model';
import { GameService } from '../shared/service/game.service';

@Component({
  selector: 'app-game-list',
  templateUrl: './game-list.component.html',
  styleUrls: ['./game-list.component.scss']
})
export class GameListComponent implements OnInit {
  gameList: Game[];

  constructor(private gameService: GameService) { }

  ngOnInit(): void {
    this.getAllGames();
  }

  getAllGames(): void {
    this.gameService.getAllGames().subscribe(games => {
      this.gameList = games;
    });
  }
}
