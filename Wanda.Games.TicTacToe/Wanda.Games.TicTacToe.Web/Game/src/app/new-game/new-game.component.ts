import { Component, OnInit } from '@angular/core';
import { GameService } from 'src/app/shared/service/game.service';
import { PlayerService } from 'src/app/shared/service/player.service';
import { Game } from '../shared/models/game.model';
import { Player } from '../shared/models/player.model';
import * as moment from 'moment';
import { Move } from '../shared/models/move.model';

@Component({
  selector: 'app-new-game',
  templateUrl: './new-game.component.html',
  styleUrls: ['./new-game.component.scss']
})
export class NewGameComponent implements OnInit {
  title = 'Tic Tac Toe';
  playerList: Player[];
  computer: Player;
  player1: Player;
  playingTurn: Player;
  board: any[];
  isGameOver: boolean;
  isBoardLocked: boolean;
  winner: Player;
  currentGame: Game;


  get winningPatterns() {
    return [[0, 1, 2], [3, 4, 5], [6, 7, 8], [0, 3, 6], [1, 4, 7], [2, 5, 8], [0, 4, 8], [2, 4, 6]];
  }

  constructor(
    private gameService: GameService,
    private playerService: PlayerService) { }

  ngOnInit(): void {
    this.getAllPlayers();
  }

  startGame() {
    const gameName = this.makeRandomGameName(10);
    this.currentGame = this.populateNewGame(0, gameName, '')
    this.addGame(this.currentGame);
    this.isGameOver = false;
    this.isBoardLocked = false;

    this.board = [{ value: '' }, { value: '' }, { value: '' }, { value: '' }, { value: '' }, { value: '' }, { value: '' }, { value: '' }, { value: '' }];

    if (this.playingTurn == this.computer) {
      this.isBoardLocked = true;
      this.computerTurn();
    }
  }

  computerTurn() {
    this.isBoardLocked = true;

    setTimeout(() => {
      let availableSquares = this.board.filter(s => s.value === '');
      var squareIndex = Math.floor(Math.random() * (availableSquares.length - 1 - 0 + 1)) + 0;
      let square = availableSquares[squareIndex];
      square.value = this.computer.symbol;
      this.checkMove(this.computer);
      this.isBoardLocked = false;
    }, 600);
  }

  checkMove(player: Player) {
    if (this.checkWin(player)) { this.EndGame(player); }

    const availableSquares = this.board.filter(s => s.value == '').length > 0;
    if (!availableSquares)
      this.EndGame(null);
    else {
      this.playingTurn = (this.playingTurn == this.computer ? this.player1 : this.computer);
      if (this.playingTurn == this.computer)
        this.computerTurn();
    }
  }

  EndGame(player: Player) {
    this.isGameOver = true;
    this.winner = player;
    this.currentGame.winner = player.playerName;

    this.updateGame(this.currentGame);
    this.addMoves(this.convertBoardToMoves());
    if (player !== null)
      this.playingTurn = player;
  }


  checkWin(player: Player): boolean {
    for (let pattern of this.winningPatterns) {
      const winner = this.board[pattern[0]].value == player.symbol && this.board[pattern[1]].value == player.symbol
        && this.board[pattern[2]].value == player.symbol;

      if (winner) {
        for (let index of pattern) {
          this.board[index].winner = true;
        }
        return true;
      }
    }
    return false;
  }


  selectSquare(square) {
    if (square.value === '' && !this.isGameOver) {
      square.value = this.player1.symbol;
      this.checkMove(this.player1);
    }
  }


  populateNewGame(gameId: number, gameName: string, gameWinner: string): Game {
    const newGame: Game = {
      id: gameId,
      gameName: gameName,
      winner: gameWinner,
      lastUpdated: `${moment(new Date()).format('YYYY-MM-DD')}`,
      dateCreated: `${moment(new Date()).format('YYYY-MM-DD')}`
    };
    return newGame;
  }

  makeRandomGameName(lengthOfCode: number) {
    let possible = "ABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";
    let text = "";
    for (let i = 0; i < lengthOfCode; i++) {
      text += possible.charAt(Math.floor(Math.random() * possible.length));
    }
    return text;
  }

  convertBoardToMoves() {
    let moveList: Move[]=[];
    this.board.forEach((item, index) => {
      const newPlayerId = this.playerList.find(a => a.symbol === item.value)?.id;
      const newMove: Move = {
        id: 0,
        gameId: this.currentGame.id,
        moveCode: index.toString(),
        playerId: newPlayerId ?? null,
        lastUpdated: `${moment(new Date()).format('YYYY-MM-DD')}`,
        dateCreated: `${moment(new Date()).format('YYYY-MM-DD')}`
      };
      moveList.push(newMove);
    });
    return moveList;
  }


  getAllPlayers(): void {
    this.playerService.getAllPlayers().subscribe(players => {
      this.computer = players.find(a => a.playerName === "Computer");
      this.player1 = players.find(a => a.playerName === "Player1");
      this.playingTurn = this.player1;
      this.playerList = players;
      this.startGame();
    });
  }

  addGame(game: Game): void {
    this.gameService.addGame(game).subscribe(gameId => {
      this.currentGame.id = gameId;
    });
  }

  updateGame(game: Game): void {
    this.gameService.updateGame(game).subscribe();
  }

  addMoves(moves: Move[]): void {
    this.gameService.addMoves(moves).subscribe();
  }

}
