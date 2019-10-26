import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl } from '@angular/forms';
import { IAdministrationState } from '../../+state/state/administration.state';
import { Store, select } from '@ngrx/store';
import { addGameConsole } from '../../+state/actions';
import { formIsSubmitting } from '../../+state/selectors/administration.selector';

@Component({
  selector: 'app-add-system',
  templateUrl: './add-system.component.html',
  styleUrls: ['./add-system.component.scss']
})
export class AddSystemComponent implements OnInit {
  systemForm = new FormGroup({
    name: new FormControl(''),
    manufacturer: new FormControl('')
  });

  constructor(private store: Store<IAdministrationState>) {
    this.store.pipe(select(formIsSubmitting)).subscribe(state => {
      if (!state) {
        this.systemForm.reset();
      }
    });
  }

  ngOnInit() {}

  saveSystem() {
    this.store.dispatch(addGameConsole({ payload: this.systemForm.value }));
  }
}
