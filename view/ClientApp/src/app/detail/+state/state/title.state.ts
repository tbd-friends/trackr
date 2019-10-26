import { IGame } from '../models';
import { IGameCopy } from '../../models';

export const titleStateKey = 'titleState';

export interface ITitleState {
  title: IGame;
  copies: IGameCopy[];
}
