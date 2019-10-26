import { createReducer, on, Action } from '@ngrx/store';
import { IAdministrationState } from '../state/administration.state';

import {
  gamesLoaded,
  titlesLoaded,
  gameConsolesLoaded,
  addGame
} from '../actions';
import { gameAddedSuccess } from '../actions/gameAddedSuccess.action';
import { addGameConsole } from '../actions/addGameConsole.action';
import { consoleAddedSuccess } from '../actions/consoleAddedSuccess.action';

export const initialState: IAdministrationState = {
  gameConsoles: [],
  titles: [],
  games: [],
  submitting: false
};

const administrationReducer = createReducer(
  initialState,
  on(addGame, state => ({
    ...state,
    submitting: true
  })),
  on(addGameConsole, state => ({
    ...state,
    submitting: true
  })),
  on(gameConsolesLoaded, (state, args) => ({
    ...state,
    gameConsoles: args.payload
  })),
  on(titlesLoaded, (state, args) => ({
    ...state,
    titles: args.payload
  })),
  on(gamesLoaded, (state, args) => ({
    ...state,
    games: args.payload
  })),
  on(consoleAddedSuccess, state => ({
    ...state,
    submitting: false
  })),
  on(gameAddedSuccess, state => ({
    ...state,
    submitting: false
  }))
);

export function reducer(
  state: IAdministrationState | undefined,
  action: Action
) {
  return administrationReducer(state, action);
}
