import { Injectable } from '@angular/core';
import { Actions, createEffect, ofType } from '@ngrx/effects';

import { mergeMap, map, delay } from 'rxjs/operators';
import {
  loadTitle,
  ITitleRequest,
  titleLoaded,
  getGameCopies,
  gameCopiesFetched,
  addGameCopy,
  toggleWantedGame,
  deleteCoverArt
} from '../actions';
import { TitleService } from '../../services/title.service';
import { IAddGameCopy, ISelectedCoverArt } from '../../models';
import { selectCoverArt } from '../actions/selectCoverArt.action';

@Injectable()
export class TitleEffects {
  loadTitle$ = createEffect(() =>
    this.actions$.pipe(
      ofType(loadTitle.type),
      mergeMap((args: ITitleRequest) =>
        this.titleService
          .getGame(args.gameId)
          .pipe(map(result => titleLoaded({ payload: result })))
      )
    )
  );

  getGameCopies$ = createEffect(() =>
    this.actions$.pipe(
      ofType(getGameCopies.type),
      mergeMap((args: any) =>
        this.titleService
          .loadGameCopies(args.id)
          .pipe(map(result => gameCopiesFetched({ payload: result })))
      )
    )
  );

  addGameCopy$ = createEffect(() =>
    this.actions$.pipe(
      ofType(addGameCopy.type),
      mergeMap((copy: IAddGameCopy) =>
        this.titleService
          .saveGameCopy(copy)
          .pipe(map(result => getGameCopies({ id: copy.gameId })))
      )
    )
  );

  toggleWantedGame$ = createEffect(() =>
    this.actions$.pipe(
      ofType(toggleWantedGame.type),
      mergeMap((props: any) =>
        this.titleService
          .toggleTitleWanted(props.id)
          .pipe(map(_ => loadTitle({ gameId: props.id })))
      )
    )
  );

  selectCoverArt = createEffect(() =>
    this.actions$.pipe(
      ofType(selectCoverArt.type),
      mergeMap((args: any) =>
        this.titleService
          .selectCoverArt(args.payload)
          .pipe(map(_ => loadTitle({ gameId: args.payload.gameId })))
      )
    )
  );

  deleteCoverArt$ = createEffect(() =>
    this.actions$.pipe(
      ofType(deleteCoverArt.type),
      mergeMap((action: { id: string }) =>
        this.titleService
          .deleteCoverArt(action.id)
          .pipe(map(_ => loadTitle({ gameId: action.id })))
      )
    )
  );

  constructor(private actions$: Actions, private titleService: TitleService) {}
}
