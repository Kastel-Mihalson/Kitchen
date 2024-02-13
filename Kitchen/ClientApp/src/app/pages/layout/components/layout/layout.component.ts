import { Component, OnInit } from '@angular/core';
import {Router} from "@angular/router";

@Component({
  selector: 'app-layout',
  templateUrl: './layout.component.html',
  styleUrls: ['./layout.component.scss']
})
export class LayoutComponent implements OnInit {
  menuItems: {label:string, router: string}[] = [];
  selectedMenuItemIndex?: number;

  constructor(
    private router: Router
  ) {
    this.menuItems = [
      {
        label: 'Проекты',
        router: 'projects'
      },
      {
        label: 'Блюда',
        router: 'dishs'
      }
    ];
  }

  ngOnInit(): void {
  }

  onClickLogout() {
    localStorage.clear();
    this.router.navigate(['/', 'auth'])
  }
}
