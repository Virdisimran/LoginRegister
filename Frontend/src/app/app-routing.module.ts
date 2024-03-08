import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { MyProductsComponent } from './Dashboard/my-products/my-products.component';
import { AddProductComponent } from './Dashboard/add-product/add-product.component';
import { NavbarComponent } from './Dashboard/navbar/navbar.component';
import { LoginComponent } from './Registration/login/login.component';
import { SignupComponent } from './Registration/signup/signup.component';

const routes: Routes = [
  {
    path:'',component:SignupComponent
  },
  
  {
    path:'login',component:LoginComponent
  },

  {
    path:'addProduct',component:AddProductComponent
  },

  {
    path:'navbar',component:NavbarComponent
  },

  {
    path:'myProducts',component:MyProductsComponent
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
