import { ModuleWithProviders } from '@angular/core';
import { RouterModule }        from '@angular/router';

import { ChatFormComponent }    from './chat-form/chat-form.component';

export const routing: ModuleWithProviders = RouterModule.forChild([
  { path: 'chat', component: ChatFormComponent}
]);

