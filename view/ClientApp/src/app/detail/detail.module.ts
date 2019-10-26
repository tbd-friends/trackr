import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';

import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import {
  MatToolbarModule,
  MatMenuModule,
  MatIconModule,
  MatInputModule,
  MatButtonModule,
  MatCardModule,
  MatSelectModule,
  MatAutocompleteModule,
  MatDialogModule,
  MatTableModule,
  MatChipsModule
} from '@angular/material';

import { TitleService } from './services/title.service';

import { ViewTitleComponent } from './components/view-title/view-title.component';
import { titleStateKey } from './+state/state/title.state';
import { StoreModule } from '@ngrx/store';
import { EffectsModule } from '@ngrx/effects';
import { TitleEffects } from './+state/effects/title.effects';
import * as fromTitle from './+state/reducers/title.reducer';
import { GameCopiesComponent } from './components/game-copies/game-copies.component';
import { AddGameCopyDialogComponent } from './components/dialogs/add-game-copy-dialog/add-game-copy-dialog.component';
import { AuthGuard } from '../security/auth.guard';
import { SecurityModule } from '../security/security.module';

@NgModule({
  declarations: [
    ViewTitleComponent,
    GameCopiesComponent,
    AddGameCopyDialogComponent
  ],
  imports: [
    CommonModule,
    RouterModule.forRoot([
      {
        path: 'title/:id',
        component: ViewTitleComponent,
        canActivate: [AuthGuard]
      }
    ]),
    StoreModule.forFeature(titleStateKey, fromTitle.reducer),
    EffectsModule.forFeature([TitleEffects]),
    SecurityModule,
    // Module Imports
    CommonModule,
    FormsModule,
    ReactiveFormsModule,
    // Material
    MatToolbarModule,
    MatMenuModule,
    MatIconModule,
    MatInputModule,
    MatButtonModule,
    MatCardModule,
    MatSelectModule,
    MatAutocompleteModule,
    MatDialogModule,
    MatTableModule,
    MatChipsModule
  ],
  entryComponents: [AddGameCopyDialogComponent],
  providers: [TitleService]
})
export class DetailModule {}
