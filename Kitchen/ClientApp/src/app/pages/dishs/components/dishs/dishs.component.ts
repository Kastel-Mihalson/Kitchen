import {Component, ElementRef, OnInit, ViewChild} from '@angular/core';
import {FoodCategoryService} from "../../../../shared/services/food-category.service";
import {FormControl, FormGroup} from "@angular/forms";
import {ConfirmationService, MenuItem, MenuItemCommandEvent, MessageService} from "primeng/api";
import {FoodService} from "../../../../shared/services/food.service";
import {Food} from "../../../../models/food";
import {ProjectService} from "../../../../shared/services/project.service";
import {Project} from "../../../../models/project";
import {FoodCategory} from "../../../../models/food-category";
import {ActivatedRoute} from "@angular/router";
import {FoodPriceHistoryService} from "../../../../shared/services/food-price-history.service";
import {FoodPriceHistory} from "../../../../models/food-price-history";
import {IFood} from "../../../../interfaces/i-food";
import {IFoodCategory} from "../../../../interfaces/i-food-category";

@Component({
  selector: 'app-dishs',
  templateUrl: './dishs.component.html',
  styleUrls: ['./dishs.component.scss'],
  providers: [ConfirmationService, MessageService]
})

export class DishsComponent implements OnInit{
  isCategoryDeleteButtonVisible: boolean = false;
  displayCategoryModalVisible: boolean = false;
  displayMoreInfoModalVisible: boolean = false;
  displayModalVisible: boolean = false;
  isCategoryVisible: boolean = true;
  isCategoryEmpty: boolean = true;
  isFoodsEmpty: boolean = true;
  isFoodEditMode: boolean = false;
  loading: boolean = true;

  categories: FoodCategory[] = [];
  foods: Food[] = [];
  selectedFood: Food | undefined;
  originalFoods: Food[] = [];
  projects: Project[] = [];
  project: Project | undefined;
  foodPrices: FoodPriceHistory[] = [];

  formGroup: FormGroup;
  formGroupCategory: FormGroup;

  uploadedFoodImage: string = "";
  selectedCategory: string = "";

  constructor(
    private confirmationService: ConfirmationService,
    private messageService: MessageService,
    private foodCategoryService: FoodCategoryService,
    private foodPriceHistoryService: FoodPriceHistoryService,
    private foodService: FoodService,
    private projectService: ProjectService,
    private route: ActivatedRoute
  ) {
    this.formGroup = new FormGroup({
      foodId: new FormControl<string | null>(null),
      foodName: new FormControl<string | null>(null),
      foodDescription: new FormControl<string | null>(null),
      foodPrice: new FormControl<number>(0),
      foodCategory: new FormControl<IFoodCategory | null>(null),
      project: new FormControl<string | null>(null)
    });
    this.formGroupCategory = new FormGroup({
      categoryName: new FormControl<string | null>(null)
    });
    this.route.queryParams.subscribe(params => {
      if (Object.keys(params).length === 0) {
        this.isCategoryVisible = false
        return;
      }

      this.project = new Project(
        params.projectId,
        params.projectName,
        params.projectDescription,
        "");
    });
  }

  ngOnInit(): void {
    this.loadFoodCategoriesByProject();
    this.loadFoodsByProject();
    this.loadProjects();
  }

  showAddModal(): void {
    this.displayModalVisible = true;
    this.isFoodEditMode = false;
  }

  showEditModal(food: Food) {
    let foodCategory = this.categories.find(x => x.id == this.selectedCategory);
    this.formGroup.setValue({
      foodId: food.id,
      foodName: food.name,
      foodDescription: food.description,
      foodPrice: food.price,
      foodCategory: foodCategory ?? null,
      project: food.projectId
    });
    this.displayModalVisible = true;
    this.isFoodEditMode = true;
  }

  showAddCategoryModal() {
    this.displayCategoryModalVisible = true;
  }

  showMoreInfoModal(food: Food) {
    this.selectedFood = food;
    this.loadFoodMoreInfo(food.id);
    this.displayMoreInfoModalVisible = true;
  }

  loadFoodCategoriesByProject() {
    this.foodCategoryService.GetFoodCategoriesByProjectId(this.project?.id as string)
      .subscribe(data => {
        this.isCategoryEmpty = data.length == 0;
        this.categories = data;
        this.loading = false;
    });
  }

  loadProjects() {
    this.projectService.GetProjects()
      .subscribe( data => {
        this.projects = data;
        this.loading = false;
    });
  }

  loadFoodsByProject() {
    this.foodService.GetFoodsByProjectId(this.project?.id as string)
      .subscribe(data => {
        this.isFoodsEmpty = data.length == 0;
        this.foods = data;
        this.originalFoods = data;
        this.loading = false;
    });
  }

  loadFoodMoreInfo(foodId: string) {
    this.foodPriceHistoryService.GetFoodPricesById(foodId)
      .subscribe(response => {
        this.foodPrices = response;
    });
  }

  uploadFoodImage(event: any) {
    let file = event.target.files[0];
    let toMb = 1024 * 1024;
    let uploadFileMaxSize = 2 * toMb;

    if (file != null && file.size >= uploadFileMaxSize) {
      event.target.files = null;
      this.messageService.add({
        severity: "error",
        summary: "Error",
        detail: `Загружаемое изображение больше ${uploadFileMaxSize}Мб!`
      })
      return;
    }

    let reader = new FileReader();

    reader.readAsDataURL(file);
    reader.onload = e => {
      this.uploadedFoodImage = reader.result as string;
      console.log(reader.result);
    }

  }

  saveFood() {
    if (!this.isFoodEditMode) {
      this.addFood();
    } else {
      this.editFood();
    }
    this.displayModalVisible = false;
  }

  addFood() {
    let formValues = this.formGroup.getRawValue();
    let data : IFood = {
      name: formValues.foodName,
      description: formValues.foodDescription,
      price: formValues.foodPrice,
      image: this.uploadedFoodImage,
      foodCategoryId: formValues.foodCategory.id,
      projectId: this.project?.id as string
    }
    this.foodService.CreateFood(data).subscribe( response => {
      this.loadFoodsByProject();
      this.messageService.add({
        severity: "success",
        summary: "Success",
        detail: "Блюдо успешно Добавлено!"
      })
    });
  }

  editFood() {
    let formValues = this.formGroup.getRawValue();
    let data : IFood = {
      name: formValues.foodName,
      description: formValues.foodDescription,
      price: formValues.foodPrice,
      image: this.uploadedFoodImage,
      foodCategoryId: formValues.foodCategory.id,
      projectId: this.project?.id as string
    }
    this.foodService.UpdateFood(formValues.foodId, data).subscribe(response => {
      this.messageService.add({
        severity: "success",
        summary: "Success",
        detail: "Блюдо успешно обновлено!"
      })
      this.loadFoodsByProject();
    });
  }

  deleteFood(id: string) {
    this.confirmationService.confirm({
      message: 'Вы действительно хотите удалить блюдо?',
      header: 'Подтверждение удаления',
      icon: 'pi pi-info-circle',
      acceptButtonStyleClass:"p-button-danger p-button-text",
      rejectButtonStyleClass:"p-button-text p-button-text",
      acceptLabel: "Удалить",
      rejectLabel: "Отмена",

      accept: () => {
        this.foodService.DeleteFood(id).subscribe(response => {
          this.messageService.add({
            severity: "success",
            summary: "Success",
            detail: "Блюдо успешно удалено!"
          })
          this.loadFoodsByProject();
        });
      }
    });
  }

  addCategory() {
    let formValues = this.formGroupCategory.getRawValue();
    let data : IFoodCategory = {
      name: formValues.categoryName,
      description: "",
      projectId: this.project?.id as string
    }
    this.foodCategoryService.CreateFoodCategory(data).subscribe(response => {
      this.displayCategoryModalVisible = false;
      this.messageService.add({
        severity: 'success',
        summary: "Success",
        detail: "Категория успешно добавлена"
      });
      this.loadFoodCategoriesByProject();
    });
  }

  selectCategory() {
    let categoryId = this.selectedCategory;

    if (!categoryId) {
      this.isCategoryDeleteButtonVisible = false;
      this.foods = this.originalFoods;
      return;
    } else {
      this.isCategoryDeleteButtonVisible = true;
    }

    let data = this.originalFoods.filter( x => x.foodCategoryId === categoryId);
    this.foods = data;
  }

  deleteSelectedCategory() {
    if (this.selectedCategory) {
      this.foodCategoryService.DeleteFoodCategory(this.selectedCategory)
        .subscribe(response => {
          this.messageService.add({
            severity: 'success',
            summary: "Success",
            detail: "Категория успешно удалена"
          });
          this.isCategoryDeleteButtonVisible = false;
          this.loadFoodCategoriesByProject();
        });
    }
  }
}
