import { createAction, props } from '@ngrx/store';

export const toggleWantedGame = createAction(
  '[Title] Toggle Wanted Game',
  props<{ id: string }>()
);
