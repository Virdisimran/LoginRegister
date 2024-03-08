import { Component } from '@angular/core';
import { AbstractControl, FormBuilder, FormGroup,Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { AppServiceService } from 'src/app/app-service.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent {
constructor(private service:AppServiceService,private fb:FormBuilder,public toastr:ToastrService,public route:Router){}
username:string=""
password:string=""
myForm!:FormGroup
id:any

login()
{
  const obj={
    "loginDTO": {
      "username": this.username,
      "password": this.password
    }
  }
  this.service.login(obj).subscribe({
    next:(res)=>
    {
      console.log(res);
       sessionStorage.setItem('Id',res.Id)
      if(res.StatusCode===200)
      {
        this.toastr.success("Login Successfull")
        this.route.navigate(['/navbar'])
      }
      else
      {
        this.toastr.error("Invalid Username or Password")
      }
    },
    error:(err)=>
    {
      console.error(err);
      
    }
  })
}

}
