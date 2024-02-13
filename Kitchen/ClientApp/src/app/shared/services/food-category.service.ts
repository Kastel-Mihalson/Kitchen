import {HttpClient} from "@angular/common/http";
import {environment} from "../../../environments/environment";
import {Observable} from "rxjs";
import {FoodCategory} from "../../models/food-category";
import {IFoodCategory} from "../../interfaces/i-food-category";
import {Injectable} from "@angular/core";

@Injectable({
  providedIn: 'root'
})
export class FoodCategoryService {

  private baseUrl: string = `${environment.apiUrl}/FoodCategories`;

  constructor(
    private httpClient: HttpClient
  ) { }

  GetFoodCategories() : Observable<FoodCategory[]> {
    return this.httpClient.get<FoodCategory[]>(`${this.baseUrl}`);
  }

  GetFoodCategoryById(categoryId: string) : Observable<FoodCategory> {
    return this.httpClient.get<FoodCategory>(`${this.baseUrl}/${categoryId}`);
  }

  GetFoodCategoriesByProjectId(projectId: string) : Observable<FoodCategory[]> {
    return this.httpClient.get<FoodCategory[]>(`${this.baseUrl}/project/${projectId}`);
  }

  CreateFoodCategory(data: IFoodCategory) : Observable<any> {
    return this.httpClient.post(`${this.baseUrl}`, data);
  }

  UpdateFoodCategory(data: IFoodCategory) : Observable<any> {
    return this.httpClient.put(`${this.baseUrl}`, data);
  }

  DeleteFoodCategory(categoryId: string) : Observable<any> {
    return this.httpClient.delete<any>(`${this.baseUrl}/${categoryId}`);
  }
}
