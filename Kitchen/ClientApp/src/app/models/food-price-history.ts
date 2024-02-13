export class FoodPriceHistory {
  constructor(
    public id: string,
    public creationDate: string,
    public foodId: string,
    public price: number
  ) { }
}
