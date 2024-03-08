import { Component } from '@angular/core';
import { AppServiceService } from 'src/app/app-service.service';

@Component({
  selector: 'app-my-products',
  templateUrl: './my-products.component.html',
  styleUrls: ['./my-products.component.css']
})
export class MyProductsComponent {
constructor(public service:AppServiceService){}

// ngOnInit()
// {
//   // return this.service.getProducts().subscribe({
//     next:(response)=>
//     {
//       console.log(response);
      
//     },
//     error:(err)=>
//     {
//       console.error(err);
      
//     }
//   })
// }
}
