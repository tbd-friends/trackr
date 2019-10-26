import { createAction, props } from '@ngrx/store';

export const loadTitle = createAction(
  '[Title] Load Title',
  props<ITitleRequest>()
);

export interface ITitleRequest {
  gameId: string;
}
