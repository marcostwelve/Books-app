import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { BookListComponent } from './features/books/pages/book-list/book-list.component';
import { BookFormComponent } from './features/books/pages/book-form/book-form.component';

const routes: Routes = [
  {path: '', redirectTo: 'books', pathMatch: 'full'},
  {path: 'books',
    children: [
      {path: '', component: BookListComponent},
      {path: 'new', component: BookFormComponent},
      {path: ':id/edit', component: BookFormComponent},
    ]
  },

  {path: '**', redirectTo: 'books' }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
