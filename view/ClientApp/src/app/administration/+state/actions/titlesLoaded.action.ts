import { createAction, props } from '@ngrx/store';
import { ITitle } from 'src/app/services/lookup.service';

export const titlesLoaded = createAction(
  '[Administration] Titles Loaded',
  props<{ payload: ITitle[] }>()
);
