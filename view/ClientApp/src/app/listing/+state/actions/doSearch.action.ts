import { createAction, props } from '@ngrx/store';

export const doSearch = createAction(
    '[Search] DoSearch',
    props<{ term: string, includeOnlyWanted: boolean, includeWithCopies: boolean }>()
);
