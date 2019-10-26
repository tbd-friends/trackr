import { IGameConsole, ITitle } from 'src/app/services/lookup.service';
import { IGameListModel } from '../../models';

export const administrationStateKey = 'administrationState';

export interface IAdministrationState {
  gameConsoles: IGameConsole[];
  titles: ITitle[];
  games: IGameListModel[];
  submitting: boolean;
}
