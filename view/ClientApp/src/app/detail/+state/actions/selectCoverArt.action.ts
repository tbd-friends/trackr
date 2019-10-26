import { createAction, props } from '@ngrx/store';
import { ISelectedCoverArt } from '../../models';

export const selectCoverArt = createAction(
  '[Title] Select Cover-Art',
  props<{ payload: ISelectedCoverArt }>()
);
