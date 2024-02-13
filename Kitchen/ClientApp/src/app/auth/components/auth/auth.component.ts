import {Component} from '@angular/core';
import {FormBuilder, FormGroup, Validators} from "@angular/forms";
import {AuthService} from "../../../shared/services/auth.service";
import {Router} from "@angular/router";

@Component({
  selector: 'app-auth',
  templateUrl: './auth.component.html',
  styleUrls: ['./auth.component.scss']
})
export class AuthComponent {
  form: FormGroup;
  loading: boolean = false;

  constructor(
    private formBuilder: FormBuilder,
    private authService: AuthService,
    private router: Router
  ) {
    this.form = this.formBuilder.group({
      email: [null, [Validators.required, Validators.email]],
      password: [null, [Validators.required]]
    })
  }

  onClickLogin() {
    if (this.form.valid) {
      this.loading = true;
      this.authService.Login(this.form.value.email, this.form.value.password).subscribe(data => {
          this.loading = false;
          localStorage.setItem('accessToken', data.access_token);
          this.router.navigate(['/welcome']);
        },
        error => {
          this.loading = false;
        });
    }
  }

  onClickRegistration() {
    this.router.navigate(['/', 'registration'])
  }
}
