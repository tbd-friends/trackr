import { Component, OnInit, ViewChild } from '@angular/core';
import { IAdministrationState } from '../../+state/state/administration.state';
import { MatPaginator, MatTableDataSource } from '@angular/material';
import { Store, select } from '@ngrx/store';
import { getAllGames } from '../../+state/selectors/administration.selector';

import { loadAllGames, deleteGame } from '../../+state/actions';
import { IGameListModel } from '../../models';

@Component({
  selector: 'app-list-all-games',
  templateUrl: './list-all-games.component.html',
  styleUrls: ['./list-all-games.component.scss']
})
export class ListAllGamesComponent implements OnInit {
  public displayedColumns = ['name', 'console', 'manufacturer', 'actions'];
  public dataSource: MatTableDataSource<IGameListModel>;

  @ViewChild(MatPaginator, { static: true }) paginator: MatPaginator;

  constructor(private store: Store<IAdministrationState>) {
    store.pipe(select(getAllGames)).subscribe(results => {
      this.dataSource = new MatTableDataSource<IGameListModel>(results);
      this.dataSource.paginator = this.paginator;
    });
  }

  ngOnInit() {
    this.store.dispatch(loadAllGames());
  }

  deleteGame(id: string) {
    this.store.dispatch(deleteGame({ id }));
  }
}
