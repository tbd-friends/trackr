import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { SearchResult } from '../models/search.result';
import { Observable } from 'rxjs';

@Injectable()
export class SearchService {
  constructor(private http: HttpClient) {}

  public doSearch(search: any) {
    return this.http.get<SearchResult[]>(
      `search?query=${search.term}` +
        `&includeOnlyWanted=${search.includeOnlyWanted}` +
        `&includeWithCopies=${search.includeWithCopies}`
    );
  }

  public getCovertArt(id: string): Observable<any> {
    const headers = new HttpHeaders({
      'Content-Type': 'text/plain',
      Accept: 'text/plain'
    });

    return this.http.get<any>(`cover-art/${id}`, {
      headers,
      responseType: 'text' as 'json'
    });
  }
}
