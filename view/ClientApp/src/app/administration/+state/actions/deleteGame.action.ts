import { props, createAction } from '@ngrx/store';

export const deleteGame = createAction(
  '[Administration] Delete Game',
  props<{ id: string }>()
);
