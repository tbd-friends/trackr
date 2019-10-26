import { ActionReducerMap, MetaReducer } from '@ngrx/store';
import { environment } from '../../environments/environment';

export interface GlobalState {}

export const reducers: ActionReducerMap<GlobalState> = {};

export const metaReducers: MetaReducer<GlobalState>[] = !environment.production
  ? []
  : [];
