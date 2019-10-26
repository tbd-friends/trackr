import { Search } from "../../models/search.model";
import { SearchResult } from "../../models/search.result";

export const listingStateFeatureKey = "listingState";

export interface ISearchState {
  search: Search;
  results: SearchResult[];
}
