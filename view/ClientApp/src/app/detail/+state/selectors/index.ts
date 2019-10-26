import { createSelector, createFeatureSelector } from '@ngrx/store';
import { ITitleState, titleStateKey } from '../state/title.state';
import { IGameCopy } from '../../models';
import { IGame } from '../models';

const getTitleState = createFeatureSelector<ITitleState>(titleStateKey);

export const getTitle = createSelector(
  getTitleState,
  (s: ITitleState): IGame => {
    return s.title;
  }
);

export const getCopies = createSelector(
  getTitleState,
  (s: ITitleState): IGameCopy[] => {
    return s.copies;
  }
);
