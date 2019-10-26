import { Component, OnInit } from '@angular/core';
import { Location } from '@angular/common';
import { IAdministrationState } from '../../+state/state/administration.state';
import { Store } from '@ngrx/store';
import { loadGameConsoles } from '../../+state/actions/loadGameConsoles.action';
import { loadTitles } from '../../+state/actions/loadTitles.action';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent implements OnInit {
  constructor(
    private store: Store<IAdministrationState>,
    private location: Location
  ) {}

  ngOnInit() {
    this.store.dispatch(loadGameConsoles());
    this.store.dispatch(loadTitles());
  }

  goBack() {
    this.location.back();
  }
}
