import { Directive, TemplateRef, ViewContainerRef, Input } from '@angular/core';
import { AuthService } from '../services/auth.service';

@Directive({
  selector: '[appPermit]'
})
export class PermitDirective {
  constructor(
    private templateRef: TemplateRef<any>,
    private viewContainer: ViewContainerRef,
    private auth: AuthService
  ) {}

  @Input() set appPermit(required: string[]) {
    this.viewContainer.createEmbeddedView(this.templateRef);

    return;

    const preparedRoles = required.map(m => m.toLowerCase());

    this.auth.isInRole(preparedRoles).subscribe(isInRole => {
      if (isInRole) {
        this.viewContainer.createEmbeddedView(this.templateRef);
      } else {
        this.viewContainer.clear();
      }
    });
  }
}
