import {
  administrationStateKey,
  IAdministrationState
} from '../state/administration.state';
import { createFeatureSelector, createSelector } from '@ngrx/store';
import { ILookupModel } from '../../../services/lookup.service';
import { IGameListModel } from '../../models';

const getAdministrationState = createFeatureSelector<IAdministrationState>(
  administrationStateKey
);

export const getGameConsoleLookup = createSelector(
  getAdministrationState,
  (s: IAdministrationState): ILookupModel[] => {
    return s.gameConsoles.map(m => ({
      id: m.id,
      description: `${m.name} (${m.manufacturer})`
    }));
  }
);

export const getTitleLookup = createSelector(
  getAdministrationState,
  (s: IAdministrationState): ILookupModel[] => {
    return s.titles.map(m => ({
      id: m.id,
      description: m.name
    }));
  }
);

export const getAllGames = createSelector(
  getAdministrationState,
  (s: IAdministrationState): IGameListModel[] => {
    return s.games;
  }
);

export const formIsSubmitting = createSelector(
  getAdministrationState,
  (s: IAdministrationState): boolean => {
    return s.submitting;
  }
);
