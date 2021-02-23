import { Component, OnInit } from '@angular/core';
import { GameService } from 'src/app/shared/service/game.service';
import { PlayerService } from 'src/app/shared/service/player.service';
import { Player } from '../shared/models/player.model';

@Component({
  selector: 'app-new-game',
  templateUrl: './new-game.component.html',
  styleUrls: ['./new-game.component.scss']
})
export class NewGameComponent implements OnInit {
  title = 'Tic Tac Toe';
  playerList: Player[];

  constructor(
    private gameService: GameService,
    private playerService: PlayerService) { }

  ngOnInit(): void {
    this.getAllPlayers();
  }


  getAllPlayers(): void {
    this.playerService.getAllPlayers().subscribe(players => {
      this.playerList = players;
    });
  }

}
