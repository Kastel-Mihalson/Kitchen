import {HttpClient} from "@angular/common/http";
import {Injectable} from "@angular/core";
import {environment} from "../../../environments/environment";
import {Observable} from "rxjs";
import {Food} from "../../models/food";
import {IFood} from "../../interfaces/i-food";

@Injectable({
  providedIn: 'root'
})
export class FoodService {

  private baseUrl: string = `${environment.apiUrl}/Foods`;

  constructor(
    private httpClient: HttpClient
  ) { }

  GetAllFoods() : Observable<Food[]> {
    return this.httpClient.get<Food[]>(`${this.baseUrl}`);
  }

  GetFoodById(foodId: string) : Observable<Food> {
    return this.httpClient.get<Food>(`${this.baseUrl}/${foodId}`);
  }

  GetFoodsByCategoryId(categoryId: string) : Observable<Food[]> {
    return this.httpClient.get<Food[]>(`${this.baseUrl}/category/${categoryId}`);
  }

  GetFoodsByProjectId(projectId: string) : Observable<Food[]> {
    return this.httpClient.get<Food[]>(`${this.baseUrl}/project/${projectId}`);
  }

  CreateFood(data: IFood) : Observable<any> {
    return this.httpClient.post<any>(`${this.baseUrl}`, data);
  }

  UpdateFood(foodId: string, data: IFood) : Observable<any> {
    return this.httpClient.put(`${this.baseUrl}/${foodId}`, data);
  }

  DeleteFood(foodId: string) : Observable<any> {
    return this.httpClient.delete<any>(`${this.baseUrl}/${foodId}`);
  }
}
