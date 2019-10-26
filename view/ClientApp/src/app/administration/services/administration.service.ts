import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { IGameConsole } from 'src/app/services/lookup.service';
import { IGameListModel } from '../models';

@Injectable({
  providedIn: 'root'
})
export class AdministrationService {
  constructor(private http: HttpClient) {}

  public addGameConsole(gameConsole: IGameConsole): Observable<any> {
    return this.http.post('game-consoles', gameConsole);
  }

  public addGame(args: any): Observable<any> {
    if (args.title instanceof Object) {
      return this.http.post(`titles/${args.title.id}/games`, {
        gameConsoleId: args.gameConsoleId,
        titleId: args.title.id
      });
    } else {
      return this.http.post(`titles/${args.title}/games`, {
        gameConsoleId: args.gameConsoleId,
        title: args.title
      });
    }
  }

  public getAllGames(): Observable<IGameListModel[]> {
    return this.http.get<IGameListModel[]>('games');
  }

  public deleteGame(id: string): Observable<any> {
    return this.http.delete(`games/${id}`);
  }
}
