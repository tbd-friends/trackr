import { Action, on, createReducer } from '@ngrx/store';
import { ITitleState } from '../state/title.state';
import { loadTitle, titleLoaded, gameCopiesFetched } from '../actions';
import { IGame } from '../models';

export const initialState: ITitleState = {
  title: null,
  copies: []
};

const titleReducer = createReducer(
  initialState,
  on(titleLoaded, (state, args) => ({ ...state, title: args.payload })),
  on(gameCopiesFetched, (state, args) => ({ ...state, copies: args.payload }))
);

export function reducer(state: ITitleState | undefined, action: Action) {
  return titleReducer(state, action);
}
