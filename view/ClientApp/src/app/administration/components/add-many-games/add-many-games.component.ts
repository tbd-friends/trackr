import { Component, OnInit, ViewChild, NgZone, Inject } from '@angular/core';
import { CdkTextareaAutosize } from '@angular/cdk/text-field';
import { FormGroup, FormControl } from '@angular/forms';
import { take } from 'rxjs/operators';

import { ILookupModel } from '../../../services/lookup.service';
import { IAdministrationState } from '../../+state/state/administration.state';
import { Store, select } from '@ngrx/store';

import { Observable } from 'rxjs';
import { getGameConsoleLookup } from '../../+state/selectors/administration.selector';

@Component({
  selector: 'app-add-many-games',
  templateUrl: './add-many-games.component.html',
  styleUrls: ['./add-many-games.component.scss']
})
export class AddManyGamesComponent implements OnInit {
  systemsLookup: Observable<ILookupModel[]>;

  addGroup = new FormGroup({
    system: new FormControl(''),
    titles: new FormControl('')
  });

  @ViewChild('autosize', { static: false }) autosize: CdkTextareaAutosize;

  constructor(
    private ngZone: NgZone,
    private store: Store<IAdministrationState>
  ) {}

  ngOnInit() {
    this.systemsLookup = this.store.pipe(select(getGameConsoleLookup));
  }

  saveGamesBatch() {
    // this.http
    //   .post<any>('save/titles-batch', this.addGroup.value)
    //   .subscribe(_ => {
    //     this.addGroup.reset();
    //     this.dialogRef.close();
    //   });
  }

  triggerResize() {
    this.ngZone.onStable
      .pipe(take(1))
      .subscribe(() => this.autosize.resizeToFitContent(true));
  }
}
