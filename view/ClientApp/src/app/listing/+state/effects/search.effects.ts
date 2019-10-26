import { Injectable } from '@angular/core';
import { Actions, createEffect, ofType } from '@ngrx/effects';

import { mergeMap, tap, debounceTime, map } from 'rxjs/operators';
import { doSearch, searchComplete } from '../actions';
import { SearchService } from '../../services/search.service';

@Injectable()
export class SearchEffects {
    doSearch$ = createEffect(() => this.actions$.pipe(
        ofType(doSearch.type),
        debounceTime(1000),
        mergeMap((action: any) =>
            this.searchService.doSearch({ term: action.term, includeWithCopies: action.includeWithCopies, includeOnlyWanted: action.includeOnlyWanted }).pipe(
                map(results => searchComplete({ results: results }))
            ))
    ));

    constructor(
        private actions$: Actions,
        private searchService: SearchService
    ) { }
}
