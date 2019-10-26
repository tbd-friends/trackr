import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import {
  MatToolbarModule,
  MatMenuModule,
  MatIconModule,
  MatInputModule,
  MatButtonModule,
  MatCardModule,
  MatSelectModule,
  MatAutocompleteModule,
  MatTableModule,
  MatPaginatorModule
} from '@angular/material';
import { ReactiveFormsModule } from '@angular/forms';

import { StoreModule } from '@ngrx/store';
import { EffectsModule } from '@ngrx/effects';

import { SecurityModule } from '../security/security.module';

import {
  AddGameComponent,
  AddSystemComponent,
  AddManyGamesComponent,
  HomeComponent
} from './components';
import { administrationStateKey } from './+state/state/administration.state';
import * as fromAdministration from './+state/reducers/administration.reducer';
import { AdministrationEffects } from './+state/effects/administration.effects';
import { ListAllGamesComponent } from './components/list-all-games/list-all-games.component';
import { AuthGuard } from '../security/auth.guard';

@NgModule({
  declarations: [
    HomeComponent,
    AddGameComponent,
    AddSystemComponent,
    AddManyGamesComponent,
    ListAllGamesComponent
  ],
  imports: [
    CommonModule,
    ReactiveFormsModule,
    RouterModule.forRoot([
      {
        path: 'administration',
        component: HomeComponent,
        canActivate: [AuthGuard],
        data: { roles: ['administrator'] }
      }
    ]),
    StoreModule.forFeature(administrationStateKey, fromAdministration.reducer),
    EffectsModule.forFeature([AdministrationEffects]),
    SecurityModule,
    MatToolbarModule,
    MatMenuModule,
    MatIconModule,
    MatInputModule,
    MatButtonModule,
    MatCardModule,
    MatSelectModule,
    MatAutocompleteModule,
    MatTableModule,
    MatPaginatorModule
  ],
  entryComponents: []
})
export class AdministrationModule {}
