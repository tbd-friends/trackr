import { createAction, props } from '@ngrx/store';
import { IGame } from '../models';

export const titleLoaded = createAction(
  '[Title] Title Loaded',
  props<{ payload: IGame }>()
);
