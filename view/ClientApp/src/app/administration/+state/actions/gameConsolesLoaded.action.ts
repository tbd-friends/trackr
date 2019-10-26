import { createAction, props } from '@ngrx/store';
import { IGameConsole } from 'src/app/services/lookup.service';

export const gameConsolesLoaded = createAction(
  '[Administration] Game Consoles Loaded',
  props<{ payload: IGameConsole[] }>()
);
