import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { BookService } from 'src/app/services/book.service';
import { BookCreateDto, BookUpdateDto, BookViewDto } from 'src/features/books/models/book.model';
@Component({
  selector: 'app-book-form',
  templateUrl: './book-form.component.html',
  styleUrls: ['./book-form.component.scss']
})
export class BookFormComponent implements OnInit {
  form!: FormGroup;;
  isEdit = false;
  bookId!: number;

  loading = false;
  saving = false;

  constructor(private fb: FormBuilder, private route: ActivatedRoute,
     private router: Router, private bookService: BookService) { }

  ngOnInit(): void {
    this.buildForm();
    
    this.route.paramMap.subscribe(params => {
      const id = params.get('id');
      if (id) {
        this.isEdit = true;
        this.bookId = +id;
        this.loadBook(+id);
      }
    });
  }

  buildForm(): void {
    this.form = this.fb.group({
      title: ['', [Validators.required, Validators.minLength(2), Validators.maxLength(100)]],
      description: ['', [Validators.required, Validators.maxLength(500)]],
      authorId: [null, Validators.required],
      genreId: [null, Validators.required],
    });
  }

  loadBook(id: number): void {
    this.loading = true;
    this.bookService.getBookById(id).subscribe({
      next: (book: BookViewDto) => {
        console.log(book.authorId + 'book carregado');
        this.form.patchValue({
          title: book.title,
          description: book.description,
          authorId: book.authorId,
          genreId: book.genreId,
        });
        this.loading = false;
      },
      error: () => {
        this.loading = false;
      }
    });
  }

  submit(): void {
    console.log(this.form.value + 'submit chamado');
    if (this.form.invalid) {
      this.form.markAllAsTouched();
      return;
    }

    const bookData: BookUpdateDto = this.form.value;

    this.saving = true;

    if (this.isEdit && this.bookId) {
      this.bookService.updateBook(this.bookId, bookData).subscribe({
        next: () => {
          this.saving = false;
          this.router.navigate(['/books']);
        },
        error: () => {
          this.saving = false;
        }
      });
    } else {
      this.bookService.createBook(bookData as unknown as BookCreateDto).subscribe({
        next: () => {
          this.saving = false;
          this.router.navigate(['/books']);
        },
        error: () => {
          this.saving = false;
        }
      });
    }
  }

  
    cancel(): void {
      this.router.navigate(['/books']);
    }

}
