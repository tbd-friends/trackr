import { createAction, props } from '@ngrx/store';
import { IGameConsole } from 'src/app/services/lookup.service';

export const addGameConsole = createAction(
  '[Administration] Add Game Console',
  props<{ payload: IGameConsole }>()
);
