import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { ProductListComponent } from './product-list/product-list.component';
import { ProductDetailComponent } from './product-detail/product-detail.component';
import { ViewcartComponent } from './viewcart/viewcart.component';

const routes: Routes = [
  { path: '', component: HomeComponent },
  { path: 'product-list', component: ProductListComponent },
  { path: 'product-detail', component: ProductDetailComponent },
  { path: 'view-cart', component: ViewcartComponent },
  { path: '**', redirectTo: '' },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
