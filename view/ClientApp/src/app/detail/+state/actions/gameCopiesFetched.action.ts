import { createAction, props } from '@ngrx/store';
import { IGameCopy } from '../../models';

export const gameCopiesFetched = createAction(
  '[Title] Game Copies Fetched',
  props<{ payload: IGameCopy[] }>()
);
