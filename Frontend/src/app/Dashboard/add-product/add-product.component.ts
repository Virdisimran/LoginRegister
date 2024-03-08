import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { FormBuilder, FormGroup,Validators } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';
import { AppServiceService } from 'src/app/app-service.service';

@Component({
  selector: 'app-add-product',
  templateUrl: './add-product.component.html',
  styleUrls: ['./add-product.component.css']
})
export class AddProductComponent {
constructor(private service:AppServiceService,public toastr:ToastrService,public route:Router, public fb:FormBuilder){}

productName:string="";
category:string="";
brand:string="";
sellingPrice:any;
purchasePrice:any;
myForm!:FormGroup

ngOnInit()
{
  this.myForm = this.fb.group({
    productName:['',Validators.required],
    category : ['',Validators.required],
    brand:['',Validators.required],
    sellingPrice:['',Validators.required],
    purchasePrice:['',Validators.required]
  })
}
addProduct()
{
  const userId = sessionStorage.getItem('Id')
  const formValue = { ...this.myForm.value, userId};
  return this.service.addProduct(formValue).subscribe({
    next:(response)=>
    {

      console.log(response);
      this.myForm.reset();
      if(response.statusCode === 200)
      {
        this.toastr.success("Added Successfully")
        this.route.navigateByUrl('/navbar')
      }
    },
    error:(err)=>
    {
      console.error(err);
      
    }
  })
}
  }

