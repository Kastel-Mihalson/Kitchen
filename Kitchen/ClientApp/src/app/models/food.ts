export class Food {
  constructor(
    public id: string,
    public creationDate: Date,
    public name: string,
    public description: string,
    public price: number,
    public image: string,
    public foodCategoryId: string,
    public projectId: string
  ) { }
}
