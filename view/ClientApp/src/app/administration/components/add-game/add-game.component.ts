import { Component, OnInit, Inject } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { Observable } from 'rxjs';
import { startWith, map, tap } from 'rxjs/operators';
import { ILookupModel, LookupService } from '../../../services/lookup.service';
import { IAdministrationState } from '../../+state/state/administration.state';
import { Store, select } from '@ngrx/store';
import {
  getGameConsoleLookup,
  getTitleLookup,
  formIsSubmitting
} from '../../+state/selectors/administration.selector';
import { addGame } from '../../+state/actions/addGame.action';

@Component({
  selector: 'app-add-game',
  templateUrl: './add-game.component.html',
  styleUrls: ['./add-game.component.scss']
})
export class AddGameComponent implements OnInit {
  gameConsolesLookup: Observable<ILookupModel[]>;
  titlesLookup: ILookupModel[];
  filteredTitlesLookup: Observable<ILookupModel[]>;

  gameToGameConsoleGroup = new FormGroup({
    gameConsoleId: new FormControl('', [Validators.required]),
    title: new FormControl('', [Validators.required])
  });

  constructor(private store: Store<IAdministrationState>) {}

  ngOnInit() {
    this.gameConsolesLookup = this.store.pipe(select(getGameConsoleLookup));
    this.store.pipe(select(formIsSubmitting)).subscribe(state => {
      if (!state) {
        this.gameToGameConsoleGroup.reset();
      }
    });

    this.store.pipe(select(getTitleLookup)).subscribe(lookup => {
      this.titlesLookup = lookup;
    });

    this.filteredTitlesLookup = this.gameToGameConsoleGroup
      .get('title')
      .valueChanges.pipe(
        startWith(''),
        map(title =>
          title ? this._filteredTitles(title) : this.titlesLookup.slice()
        )
      );
  }

  private _filteredTitles(value: string): ILookupModel[] {
    if (value && value.length > 0) {
      const filterValue = value.toLowerCase();

      return this.titlesLookup.filter(
        game => game.description.toLowerCase().indexOf(filterValue) !== -1
      );
    }
  }

  displayFn(lookup: ILookupModel) {
    return lookup ? lookup.description : undefined;
  }

  save() {
    this.store.dispatch(
      addGame({ payload: this.gameToGameConsoleGroup.value })
    );
  }
}
