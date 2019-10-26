import { createSelector, createFeatureSelector } from "@ngrx/store";
import { ISearchState, listingStateFeatureKey } from "../state/search.state";
import { SearchResult } from "../../models/search.result";

export interface ISearchParameters {
  term: string;
  includeOnlyWanted: boolean;
  includeWithCopies: boolean;
}

const getSearchState = createFeatureSelector<ISearchState>(
  listingStateFeatureKey
);

export const getSearchResults = createSelector(
  getSearchState,
  s => s.results
);
export const getSearchParameters = createSelector(
  getSearchState,
  (s): ISearchParameters => {
    if (s.search) {
      return {
        term: s.search.term,
        includeWithCopies: s.search.includeWithCopies,
        includeOnlyWanted: s.search.includeOnlyWanted
      } as ISearchParameters;
    }

    return undefined;
  }
);
