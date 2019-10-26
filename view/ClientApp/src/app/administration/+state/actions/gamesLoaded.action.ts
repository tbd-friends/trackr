import { IGameListModel } from '../../models';
import { props, createAction } from '@ngrx/store';

export const gamesLoaded = createAction(
  '[Administration] Games Loaded',
  props<{ payload: IGameListModel[] }>()
);
