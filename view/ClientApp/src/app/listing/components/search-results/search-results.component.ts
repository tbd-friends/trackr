import { Component, OnInit, ChangeDetectionStrategy } from '@angular/core';
import { Store, select } from '@ngrx/store';
import { Router } from '@angular/router';
import { ISearchState } from '../../+state/state/search.state';
import { SearchResult } from '../../models/search.result';
import { getSearchResults } from '../../+state/selectors';
import { Observable } from 'rxjs';
import { tap } from 'rxjs/operators';
import { SearchService } from '../../services/search.service';

@Component({
  selector: 'app-search-results',
  templateUrl: './search-results.component.html',
  styleUrls: ['./search-results.component.scss'],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class SearchResultsComponent implements OnInit {
  results: Observable<SearchResult[]>;
  coverArt: Observable<{}>[];

  constructor(
    private store$: Store<ISearchState>,
    private router: Router,
    private service: SearchService
  ) {
    this.coverArt = [];
  }

  ngOnInit() {
    this.results = this.store$.pipe(select(getSearchResults)).pipe(
      tap(results => {
        results.forEach((result: SearchResult) => {
          this.coverArt[result.gameId] = this.service.getCovertArt(
            result.gameId
          );
        });
      })
    );
  }

  pluralize(plural: string, singular: string, expr: boolean) {
    return expr ? plural : singular;
  }

  navigate(result: SearchResult) {
    this.router.navigateByUrl(`title/${result.gameId}`);
  }
}
