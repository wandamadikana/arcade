import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { GameDetailComponent } from './game-detail/game-detail.component';
import { GameListComponent } from './game-list/game-list.component';
import { NewGameComponent } from './new-game/new-game.component';

const routes: Routes = [
  { path: '', component: NewGameComponent, pathMatch: 'full' },
  { path: 'game-list', component: GameListComponent },
  { path: 'game-detail', component: GameDetailComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
