import {
  Component,
  OnInit,
  Inject,
  ElementRef,
  ViewChild
} from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { COMMA, ENTER } from '@angular/cdk/keycodes';
import { TitleService } from '../../../services/title.service';
import { Observable } from 'rxjs';
import { startWith, map } from 'rxjs/operators';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import {
  MatAutocompleteSelectedEvent,
  MatChipInputEvent,
  MatAutocomplete
} from '@angular/material';
import { ITitleState } from 'src/app/detail/+state/state/title.state';
import { Store } from '@ngrx/store';
import { addGameCopy } from '../../../+state/actions';
import { IAddGameCopy } from 'src/app/detail/models';

@Component({
  selector: 'app-add-game-copy-dialog',
  templateUrl: './add-game-copy-dialog.component.html',
  styleUrls: ['./add-game-copy-dialog.component.scss']
})
export class AddGameCopyDialogComponent implements OnInit {
  public readonly separatorKeysCodes: number[] = [ENTER, COMMA];

  public filterTags: Observable<string[]>;
  public allTags: string[];
  public visible = true;
  public selectable = true;
  public removable = true;
  public addOnBlur = false;

  form = new FormGroup({
    purchasedOn: new FormControl(''),
    pricePaid: new FormControl(''),
    tags: new FormControl([]),
    tagsControl: new FormControl('')
  });

  @ViewChild('attributeInput', { static: false })
  public attributeInput: ElementRef<HTMLInputElement>;

  @ViewChild('auto', { static: false })
  public matAutocomplete: MatAutocomplete;

  constructor(
    public dialogRef: MatDialogRef<AddGameCopyDialogComponent>,
    @Inject(MAT_DIALOG_DATA) public data: any,
    private service: TitleService,
    private store: Store<ITitleState>
  ) {
    this.data = data;
  }

  ngOnInit() {
    this.service.getTags().subscribe(tags => {
      this.allTags = tags;

      this.filterTags = this.form.get('tagsControl').valueChanges.pipe(
        startWith(null),
        map((tag: string | null) =>
          tag ? this._filter(tag) : this.allTags.slice()
        )
      );
    });
  }

  public save() {
    const data: IAddGameCopy = {
      gameId: this.data.id,
      tags: this.form.get('tags').value,
      pricePaid: this.form.get('pricePaid').value || null,
      purchasedOn: this.form.get('purchasedOn').value || null
    };

    this.store.dispatch(addGameCopy(data));

    this.dialogRef.close();
  }

  public add(event: MatChipInputEvent): void {
    const input = event.input;
    const value = event.value;

    if (!this.matAutocomplete.isOpen) {
      if (value && value.length > 0) {
        const index = this.form.value.tags.indexOf(value);

        if (index === -1) {
          this.form.value.tags.push(value);

          this.form.updateValueAndValidity();
        }
      }
      if (input) {
        input.value = '';
      }
    }
  }

  public remove(index: string): void {
    this.form.value.tags.splice(index, 1);
  }

  public selected(event: MatAutocompleteSelectedEvent): void {
    this.form.value.tags.push(event.option.viewValue);
    this.attributeInput.nativeElement.value = '';
  }

  private _filter(value: string): string[] {
    const filterValue = value.toLowerCase();

    return this.allTags.filter(
      tag => tag.toLowerCase().indexOf(filterValue) === 0
    );
  }
}
