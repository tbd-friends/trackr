import { Injectable } from '@angular/core';
import { Actions, createEffect, ofType } from '@ngrx/effects';
import { mergeMap, map } from 'rxjs/operators';

import {
  addGameConsole,
  gameConsolesLoaded,
  loadGameConsoles,
  addGame,
  loadTitles,
  titlesLoaded,
  loadAllGames,
  gamesLoaded,
  deleteGame
} from '../actions';

import { AdministrationService } from '../../services/administration.service';
import { LookupService } from '../../../services/lookup.service';
import { gameAddedSuccess } from '../actions/gameAddedSuccess.action';
import { consoleAddedSuccess } from '../actions/consoleAddedSuccess.action';

@Injectable()
export class AdministrationEffects {
  addGameConsole = createEffect(() =>
    this.actions$.pipe(
      ofType(addGameConsole),
      mergeMap((args: any) =>
        this.service
          .addGameConsole(args.payload)
          .pipe(mergeMap(_ => [loadGameConsoles(), consoleAddedSuccess()]))
      )
    )
  );

  loadGameConsoles$ = createEffect(() =>
    this.actions$.pipe(
      ofType(loadGameConsoles),
      mergeMap(() =>
        this.lookups
          .getGameConsoles()
          .pipe(map(results => gameConsolesLoaded({ payload: results })))
      )
    )
  );

  loadTitles$ = createEffect(() =>
    this.actions$.pipe(
      ofType(loadTitles),
      mergeMap(() =>
        this.lookups
          .getTitles()
          .pipe(map(results => titlesLoaded({ payload: results })))
      )
    )
  );

  addGame$ = createEffect(() =>
    this.actions$.pipe(
      ofType(addGame),
      mergeMap((args: any) =>
        this.service
          .addGame(args.payload)
          .pipe(mergeMap(_ => [loadAllGames(), gameAddedSuccess()]))
      )
    )
  );

  loadGames$ = createEffect(() =>
    this.actions$.pipe(
      ofType(loadAllGames),
      mergeMap(_ =>
        this.service
          .getAllGames()
          .pipe(map(results => gamesLoaded({ payload: results })))
      )
    )
  );

  deleteGame$ = createEffect(() =>
    this.actions$.pipe(
      ofType(deleteGame),
      mergeMap((action: { id: string }) =>
        this.service.deleteGame(action.id).pipe(map(_ => loadAllGames()))
      )
    )
  );

  constructor(
    private actions$: Actions,
    private service: AdministrationService,
    private lookups: LookupService
  ) {}
}
