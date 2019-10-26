import { props, createAction } from '@ngrx/store';

export const deleteCoverArt = createAction(
  '[Detail] Delete Cover Art',
  props<{ id: string }>()
);
