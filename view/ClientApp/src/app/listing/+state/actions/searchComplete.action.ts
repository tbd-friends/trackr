import { createAction, props } from '@ngrx/store';
import { SearchResult } from '../../models/search.result';

export const searchComplete = createAction(
    '[Search] SearchComplete',
    props<{ results: SearchResult[] }>()
);
