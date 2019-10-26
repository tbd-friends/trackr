import { Component, OnInit, Input } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { Store, select } from '@ngrx/store';
import { ITitleState } from '../../+state/state/title.state';
import { IGameCopy } from '../../models';
import { getCopies } from '../../+state/selectors';
import { getGameCopies } from '../../+state/actions';
import { Observable } from 'rxjs';
import { AddGameCopyDialogComponent } from '../dialogs/add-game-copy-dialog/add-game-copy-dialog.component';

@Component({
  selector: 'app-game-copies',
  templateUrl: './game-copies.component.html',
  styleUrls: ['./game-copies.component.scss']
})
export class GameCopiesComponent implements OnInit {
  @Input() id: string;
  @Input() name: string;

  public copies: Observable<IGameCopy[]>;
  public displayedColumns: string[] = ['tags', 'pricePaid', 'purchasedOn'];

  constructor(private store: Store<ITitleState>, private dialog: MatDialog) {}

  ngOnInit() {
    this.store.dispatch(getGameCopies({ id: this.id }));

    this.copies = this.store.pipe(select(getCopies));
  }

  addGameCopy() {
    this.dialog.open(AddGameCopyDialogComponent, {
      width: '650px',
      data: { id: this.id, name: this.name }
    });
  }

  public join(tags: string[]) {
    return tags.join(', ');
  }
}
