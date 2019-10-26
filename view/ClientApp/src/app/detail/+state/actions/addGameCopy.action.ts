import { createAction, props } from '@ngrx/store';
import { IAddGameCopy } from '../../models';

export const addGameCopy = createAction(
  '[Title] Add Game Copy',
  props<IAddGameCopy>()
);
