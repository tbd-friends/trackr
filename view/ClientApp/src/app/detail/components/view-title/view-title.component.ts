import { ActivatedRoute } from '@angular/router';
import { Store, select } from '@ngrx/store';
import { Location } from '@angular/common';
import { Component, OnInit } from '@angular/core';

import { Observable } from 'rxjs';

import { IGame } from '../../+state/models';
import { getTitle } from '../../+state/selectors';
import { ITitleState } from '../../+state/state/title.state';
import {
  loadTitle,
  toggleWantedGame,
  deleteCoverArt,
  selectCoverArt
} from '../../+state/actions';
import { TitleService } from '../../services/title.service';

@Component({
  selector: 'app-view-title',
  templateUrl: './view-title.component.html',
  styleUrls: ['./view-title.component.scss']
})
export class ViewTitleComponent implements OnInit {
  public title: IGame;
  public matches: Observable<string[]>;
  public coverArt: string;
  private gameId: string;

  constructor(
    private store: Store<ITitleState>,
    private location: Location,
    private activeRoute: ActivatedRoute,
    private service: TitleService
  ) {
    this.store.pipe(select(getTitle)).subscribe(title => {
      if (title && this.gameId) {
        this.title = title;

        if (!this.title.coverArtUrl) {
          this.matches = this.service.findCoverArtFor(this.gameId);
        } else {
          this.service.getCovertArt(this.gameId).subscribe(art => {
            this.coverArt = art;
          });
        }
      }
    });
  }

  ngOnInit() {
    this.activeRoute.params.subscribe(params => {
      this.gameId = params.id;
      this.store.dispatch(loadTitle({ gameId: this.gameId }));
    });
  }

  public toggleIsWanted() {
    this.store.dispatch(toggleWantedGame({ id: this.gameId }));
  }

  public selectCoverArt(url: string) {
    this.store.dispatch(
      selectCoverArt({ payload: { gameId: this.gameId, url } })
    );
  }

  public deleteCoverArt(id: string) {
    this.store.dispatch(deleteCoverArt({ id }));
  }

  goBack() {
    this.location.back();
  }
}
