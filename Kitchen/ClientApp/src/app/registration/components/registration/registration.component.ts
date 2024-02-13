import { Component } from '@angular/core';
import {FormBuilder, FormGroup, Validators} from "@angular/forms";
import {AuthService} from "../../../shared/services/auth.service";
import {Router} from "@angular/router";

@Component({
  selector: 'app-registration',
  templateUrl: './registration.component.html',
  styleUrls: ['./registration.component.scss']
})
export class RegistrationComponent {
  form: FormGroup;
  loading: boolean = false;

  constructor(
    private formBuilder: FormBuilder,
    private authService: AuthService,
    private router: Router
  ) {
    this.form = this.formBuilder.group({
      email: [null, [Validators.required, Validators.email]],
      name: [null, Validators.required],
      password: [null, Validators.required],
      retryPassword: [null, Validators.required]
    })
  }

  onClickRegistration() {
    if (this.form.valid) {
      if (this.form.value.password === this.form.value.retryPassword) {
        this.loading = true;
        this.authService.Registration(this.form.value.email, this.form.value.name, this.form.value.password).subscribe(() => {
          this.loading = false;
          this.router.navigate(['/','auth'])
        }, error => {
          this.loading = false;
        })
      }else{
        this.form.controls['retryPassword'].markAsDirty()
      }
    }
  }
}
