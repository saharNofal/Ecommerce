import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CategoryListComponent } from './components/category-list/category-list.component';
import { AddCategoryComponent } from './components/add-category/add-category.component';
import { EditCategoryComponent } from './components/edit-category/edit-category.component';
import { ProductListComponent } from './components/product-list/product-list.component';
import { ProductAddComponent } from './components/product-add/product-add.component';


const routes: Routes = [

  { path: 'Category', component: CategoryListComponent },
  { path: 'Add-category', component: AddCategoryComponent },
  { path: 'edit-category/:categoryId', component: EditCategoryComponent },
  { path: 'Product', component: ProductListComponent },
  { path: 'AddProduct', component: ProductAddComponent },
  { path: 'EditProduct/:productId', component: ProductAddComponent },

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
