import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { BookService } from 'src/app/services/book.service';
import { BookViewDto } from 'src/features/books/models/book.model';

@Component({
  selector: 'app-book-list',
  templateUrl: './book-list.component.html',
  styleUrls: ['./book-list.component.scss']
})
export class BookListComponent implements OnInit {
  books: BookViewDto[] = [];
  loading: boolean = false;

  displayedColumns: string[] = ['title', 'author', 'publishedDate', 'actions'];
  
  constructor(private bookService: BookService, private router: Router) { }

  ngOnInit(): void {
    this.loadBooks();
  }

  loadBooks(): void {
    this.loading = true;
    this.bookService.loadAllBooks().subscribe({
      next: (books) => {
        this.books = books;
        this.loading = false;
      },
      error: () => {
        this.loading = false;
      }
    });
  }

  newBook(): void {
    this.router.navigate(['/books/new']);
  }

  editBook(book: BookViewDto): void {
    this.router.navigate([`/books/${book.id}/edit`]);
  }

  deleteBook(book: BookViewDto): void {
    if (confirm(`Are you sure you want to delete the book: ${book.title}?`)) {
      this.bookService.deleteBook(book.id).subscribe({
        next: () => {
          this.books = this.books.filter(b => b.id !== book.id);
        },
        error: (err) => {
          console.error('Error deleting book:', err);
        }
      });
    }
  }

}
