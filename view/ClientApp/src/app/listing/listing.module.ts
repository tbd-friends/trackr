import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { CommonModule } from '@angular/common';
import { HttpClientModule } from '@angular/common/http';
import { StoreModule } from '@ngrx/store';
import { EffectsModule } from '@ngrx/effects';
import { listingStateFeatureKey } from './+state';
import { ScrollingModule } from '@angular/cdk/scrolling';

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
  MatDialogModule
} from '@angular/material';

import {
  SearchResultsComponent,
  SearchInputComponent,
  HomeComponent
} from './components';

import * as fromSearch from './+state/reducers/search.reducer';
import { SearchEffects } from './+state/effects/search.effects';
import { SearchService } from './services/search.service';
import { LookupService } from '../services/lookup.service';
import { AuthGuard } from '../security/auth.guard';

@NgModule({
  declarations: [SearchResultsComponent, SearchInputComponent, HomeComponent],
  imports: [
    CommonModule,
    RouterModule.forRoot([
      { path: '', component: HomeComponent, canActivate: [AuthGuard] }
    ]),
    StoreModule.forFeature(listingStateFeatureKey, fromSearch.reducer),
    EffectsModule.forFeature([SearchEffects]),
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    // Material
    ScrollingModule,
    MatToolbarModule,
    MatMenuModule,
    MatIconModule,
    MatInputModule,
    MatButtonModule,
    MatCardModule,
    MatSelectModule,
    MatAutocompleteModule,
    MatDialogModule
  ],

  exports: [HomeComponent],
  providers: [SearchService, LookupService]
})
export class ListingModule {}
