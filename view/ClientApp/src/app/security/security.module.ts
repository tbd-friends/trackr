import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { PermitDirective } from './directives/permit.directive';
import { HTTP_INTERCEPTORS } from '@angular/common/http';
import { InterceptorService } from './services/interceptor.service';

@NgModule({
  imports: [CommonModule],
  declarations: [PermitDirective],
  providers: [
    {
      provide: HTTP_INTERCEPTORS,
      useClass: InterceptorService,
      multi: true
    }
  ],
  exports: [PermitDirective]
})
export class SecurityModule {}
