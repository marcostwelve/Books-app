import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable, tap } from 'rxjs';
import { BookCreateDto, BookUpdateDto, BookViewDto } from 'src/features/books/models/book.model';

@Injectable({
  providedIn: 'root'
})
export class BookService {
  private readonly endpoint = 'books';

  private _book$ = new BehaviorSubject<BookViewDto[]>([]);
  public book$ = this._book$.asObservable();

  constructor(private http: HttpClient) { }

  loadAllBooks() {
    return this.http.get<BookViewDto[]>(this.endpoint).pipe(
      tap(books => this._book$.next(books))
    );
  }

  getBookById(id: number): Observable<BookViewDto> {
    return this.http.get<BookViewDto>(`${this.endpoint}/${id}`);
  }

  createBook(bookDto: BookCreateDto): Observable<BookViewDto> {
    return this.http.post<BookViewDto>(this.endpoint, bookDto).pipe(
      tap(created => {
        const currentBook = this._book$.value;
        this._book$.next([...currentBook, created]);
      })
    )
  }

  updateBook(id: number, bookDto: BookUpdateDto): Observable<BookViewDto> {
    return this.http.put<BookViewDto>(`${this.endpoint}/${id}`, bookDto).pipe(
      tap(updated => {
        const currentBook = this._book$.value;
        const index = currentBook.findIndex(b => b.id === id);
        if (index !== -1) {
          const newList = [...currentBook];
          newList[index] = updated;
          this._book$.next(newList);
        }
      })
    );
  }

  deleteBook(id: number): Observable<void> {
    return this.http.delete<void>(`${this.endpoint}/${id}`).pipe(
      tap(() => {
        const currentBook = this._book$.value;
        const newList = currentBook.filter(b => b.id !== id);
        this._book$.next(newList);
      })
    );
  }
}
