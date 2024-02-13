import {HttpClient} from "@angular/common/http";
import {Observable} from "rxjs";
import {environment} from "../../../environments/environment";
import {User} from "../../models/user";
import {Injectable} from "@angular/core";
import {IUser} from "../../interfaces/i-user";

@Injectable({
  providedIn: 'root'
})
export class UserService {

  private baseUrl: string = `${environment.apiUrl}/Users`;

  constructor(
    private httpClient: HttpClient
  ) { }

  GetUsers() : Observable<User[]> {
    return this.httpClient.get<User[]>(`${this.baseUrl}`);
  }

  GetUserById(userId: string) : Observable<User> {
    return this.httpClient.get<User>(`${this.baseUrl}/id/${userId}`);
  }

  GetUserByEmail(email: string) : Observable<User> {
    return this.httpClient.get<User>(`${this.baseUrl}/email/${email}`);
  }

  UpdateUser(userId: string, data: IUser) : Observable<any> {
    return this.httpClient.put<any>(`${this.baseUrl}/${userId}`, data);
  }

  DeleteUser(userId: string) : Observable<any> {
    return this.httpClient.delete(`${this.baseUrl}/${userId}`)
  }
}
