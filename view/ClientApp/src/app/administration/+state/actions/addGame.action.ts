import { createAction, props } from '@ngrx/store';

export const addGame = createAction(
  '[Administration] Add Game',
  props<{ payload: { gameConsoleId: string; title: any } }>()
);
