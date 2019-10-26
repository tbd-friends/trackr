import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class LookupService {
  constructor(private http: HttpClient) {}

  public getTitles(): Observable<ITitle[]> {
    return this.http.get<ITitle[]>('titles');
  }

  public getGameConsoles(): Observable<IGameConsole[]> {
    return this.http.get<IGameConsole[]>('game-consoles');
  }
}

export interface IGameConsole {
  id: string;
  name: string;
  manufacturer: string;
}

export interface ITitle {
  id: string;
  name: string;
}

export interface ILookupModel {
  id: string;
  description: string;
}
