import {environment} from "../../../environments/environment";
import {HttpClient} from "@angular/common/http";
import {Observable} from "rxjs";
import {Injectable} from "@angular/core";
import {FoodPriceHistory} from "../../models/food-price-history";

@Injectable({
  providedIn: 'root'
})
export class FoodPriceHistoryService {
  private baseUrl: string = `${environment.apiUrl}/FoodPriceHistories`;

  constructor(
    private httpClient: HttpClient
  ) { }

  GetFoodPricesById(foodId: string) : Observable<FoodPriceHistory[]> {
    return this.httpClient.get<FoodPriceHistory[]>(`${this.baseUrl}/${foodId}`);
  }

  DeleteFoodPrice(priceId: string) : Observable<any> {
    return this.httpClient.delete<any>(`${this.baseUrl}/${priceId}`);
  }
}
