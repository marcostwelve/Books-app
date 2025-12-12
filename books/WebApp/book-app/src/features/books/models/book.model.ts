export interface BookViewDto {
    id: number;
    title: string;
    description: string;
    authorId: number;
    authorName: string;
    genreId: number;
    genreName: string;
}

export interface BookCreateDto {
    title: string;
    description: string;
    authorId: number;
    genreId: number;
}
export interface BookUpdateDto {
    id: number;
    title: string;
    description: string;
}