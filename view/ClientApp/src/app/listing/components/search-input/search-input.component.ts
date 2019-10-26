import { Component, OnInit } from '@angular/core';
import { Store, select } from '@ngrx/store';
import { ISearchState } from '../../+state';
import { doSearch } from '../../+state/actions';
import { getSearchParameters, ISearchParameters } from '../../+state/selectors';
import { Observable } from 'rxjs';
import { AuthService } from 'src/app/security/services/auth.service';

@Component({
  selector: 'app-search-input',
  templateUrl: './search-input.component.html',
  styleUrls: ['./search-input.component.scss']
})
export class SearchInputComponent implements OnInit {
  public includeWithCopies: boolean;
  public includeOnlyWanted: boolean;
  public searchText: string;

  public parameters: Observable<ISearchParameters>;

  constructor(private auth: AuthService, private store$: Store<ISearchState>) {}

  ngOnInit() {
    this.parameters = this.store$.pipe(select(getSearchParameters));

    this.parameters.subscribe(p => {
      if (p) {
        this.searchText = p.term;
        this.includeWithCopies = p.includeWithCopies;
        this.includeOnlyWanted = p.includeOnlyWanted;
      } else {
        this.searchText = '';
        this.includeWithCopies = false;
        this.includeOnlyWanted = false;
      }
    });
  }

  toggleHasCopies() {
    this.dispatch({
      term: '',
      includeOnlyWanted: this.includeOnlyWanted,
      includeWithCopies: !this.includeWithCopies
    });
  }

  toggleShowOnlyFavorites() {
    this.dispatch({
      term: '',
      includeOnlyWanted: !this.includeOnlyWanted,
      includeWithCopies: this.includeWithCopies
    });
  }

  onSearch() {
    this.dispatch({
      term: this.searchText || '',
      includeOnlyWanted: this.includeOnlyWanted,
      includeWithCopies: this.includeWithCopies
    });
  }

  private dispatch(parameters: ISearchParameters): void {
    this.store$.dispatch(doSearch(parameters));
  }
}
