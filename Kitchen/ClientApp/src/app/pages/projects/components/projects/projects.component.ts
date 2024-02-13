import {Component, OnInit} from '@angular/core';
import {ProjectService} from "../../../../shared/services/project.service";
import {FormControl, FormGroup} from "@angular/forms";
import {Project} from "../../../../models/project";
import {IProject} from "../../../../interfaces/i-project";
import {ConfirmationService, MenuItem, MenuItemCommandEvent, MessageService} from "primeng/api";

@Component({
  selector: 'app-projects',
  templateUrl: './projects.component.html',
  styleUrls: ['./projects.component.scss'],
  providers: [ConfirmationService, MessageService]
})
export class ProjectsComponent implements OnInit{
  projects: Project[] = [];
  loading: boolean = true;

  displayModalVisible: boolean = false;
  displayProjectInfoModalVisible: boolean = false;
  formGroup!: FormGroup;

  constructor(
    private confirmationService: ConfirmationService,
    private messageService: MessageService,
    private projectService: ProjectService
  ) {
  }

  ngOnInit(): void {
    this.formGroup = new FormGroup({
      projectName: new FormControl<string | null>(null),
      projectDescription: new FormControl<string | null>(null)
    });
    this.loadProjects();
  }

  loadProjects() {
    this.projectService.GetProjects().subscribe(data => {
      this.projects = data;
      this.loading = false;
    })
  }

  showModal() {
    this.displayModalVisible = true;
  }

  addProject() {
    this.displayModalVisible = false;
    let formValues = this.formGroup.getRawValue();
    let data : IProject = {
      name: formValues.projectName,
      description: formValues.projectDescription,
      image: ""
    }
    this.projectService.CreateProject(data).subscribe(response => {
      this.loadProjects();
    });
  }

  editProject() {

  }

  deleteProject(id: string) {
    this.confirmationService.confirm({
      message: 'Вы действительно хотите удалить проект?',
      header: 'Подтверждение удаления',
      icon: 'pi pi-info-circle',
      acceptButtonStyleClass:"p-button-danger p-button-text",
      rejectButtonStyleClass:"p-button-text p-button-text",
      acceptLabel: "Удалить",
      rejectLabel: "Отмена",

      accept: () => {
        this.projectService.DeleteProject(id).subscribe(() => {
          this.messageService.add({
            severity: 'success',
            summary: 'Success',
            detail: 'Project deleted!'
          });
          this.loadProjects();
        })
      }
    });
  }
}
