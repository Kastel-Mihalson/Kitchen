import {HttpClient} from "@angular/common/http";
import {Observable} from "rxjs";
import {environment} from "../../../environments/environment";
import {Injectable} from "@angular/core";
import {Project} from "../../models/project";
import {IProject} from "../../interfaces/i-project";

@Injectable({
  providedIn: 'root'
})
export class ProjectService {

  private baseUrl: string = `${environment.apiUrl}/Projects`;

  constructor(
    private httpClient: HttpClient
  ) { }

  GetProjects() : Observable<Project[]> {
    return this.httpClient.get<Project[]>(`${this.baseUrl}`);
  }

  GetProjectById(projectId: string) : Observable<Project> {
    return this.httpClient.get<Project>(`${this.baseUrl}/${projectId}`);
  }

  CreateProject(data: IProject) : Observable<any> {
    return this.httpClient.post<any>(`${this.baseUrl}`, data);
  }

  UpdateProject(data: IProject) : Observable<any> {
    return this.httpClient.put(`${this.baseUrl}`, data);
  }

  DeleteProject(projectId: string) : Observable<any> {
    return this.httpClient.delete(`${this.baseUrl}/${projectId}`);
  }
}
