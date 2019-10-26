import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';

import { IGame } from '../+state/models';
import { IGameCopy, IAddGameCopy, ISelectedCoverArt } from '../models';

@Injectable({
  providedIn: 'root'
})
export class TitleService {
  constructor(private http: HttpClient) {}

  public getGame(id: string): Observable<IGame> {
    return this.http.get<IGame>(`games/${id}`);
  }

  public selectMatch(id: string, url: string) {
    return this.http.post('save/cover-art', { titleId: id, url });
  }

  public loadGameCopies(id: string): Observable<IGameCopy[]> {
    return this.http.get<IGameCopy[]>(`game-copies/${id}`);
  }

  public getTags(): Observable<string[]> {
    return this.http.get<string[]>('tags');
  }

  public saveGameCopy(copy: IAddGameCopy): Observable<any> {
    return this.http.post('game-copies', copy);
  }

  public toggleTitleWanted(id: string): Observable<any> {
    return this.http.post<any>(`save/toggle-is-wanted/${id}`, {});
  }

  public findCoverArtFor(id: string): Observable<string[]> {
    return this.http.get<string[]>(`search/match/${id}`);
  }

  public selectCoverArt(data: ISelectedCoverArt): Observable<any> {
    return this.http.post('save/cover-art', data);
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

  public deleteCoverArt(id: string): Observable<any> {
    return this.http.delete(`cover-art/${id}`);
  }
}
