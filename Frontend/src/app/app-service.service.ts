import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class AppServiceService {

  constructor(public http:HttpClient) { }
  
  registrationUrl = "https://localhost:7290/api/Registration"
  producturl = "https://localhost:7290/api/Product"

  signUp(data:any):Observable<any>
  {
    return this.http.post<any>(this.registrationUrl+`/SignUp`,data)
  }

  login(data:any):Observable<any>
  {
    return this.http.post<any>("https://localhost:7290/api/Registration/Login",data)
  }

  getProducts(id:number):Observable<any>
  {
    return this.http.get<any>(this.producturl+`GetProducts?id=${id}`)
  }

  addProduct(data:any):Observable<any>
  {
    return this.http.post<any>(this.producturl+`/AddProducts`,data)
  }
}
