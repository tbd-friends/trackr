import { createReducer, on, Action } from '@ngrx/store';

import { ISearchState } from '../';
import { Search } from '../../models/search.model';
import * as SearchActions from '../actions';

export const initialState: ISearchState = {
    search: null,
    results: []
};

const searchReducer = createReducer(
    initialState,
    on(SearchActions.doSearch,
        (state, args) => ({
            ...
            state,
            search:
            {
                term: args.term,
                includeWithCopies:
                    args.includeWithCopies,
                includeOnlyWanted:
                    args.includeOnlyWanted
            }
        }
        )),
    on(SearchActions.searchComplete,
        (state, args) => (
            {
                ...
                state,
                results: args.results
            })
    )
);

export function reducer(state: ISearchState | undefined, action: Action) {
    return searchReducer(state, action);
}

