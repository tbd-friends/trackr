import { createAction, props } from '@ngrx/store';

export const getGameCopies = createAction(
  '[Title] Get Game Copies',
  props<{ id: string }>()
);
