export interface IGameCopy {
  purchasedOn?: Date;
  pricePaid?: number;
  tags: string[];
}

export interface IAddGameCopy extends IGameCopy {
  gameId: string;
}

export interface ISelectedCoverArt {
  gameId: string;
  url: string;
}
