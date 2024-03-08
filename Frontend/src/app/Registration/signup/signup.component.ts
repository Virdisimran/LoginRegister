import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup,Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { AppServiceService } from 'src/app/app-service.service';

@Component({
  selector: 'app-signup',
  templateUrl: './signup.component.html',
  styleUrls: ['./signup.component.css']
})
export class SignupComponent implements OnInit {
  myForm!:FormGroup;
constructor(public service:AppServiceService,public route:Router,public toastr:ToastrService,private fb:FormBuilder)
{}

firstName:string="";
lastName:string="";
email: string="";
dob:string="";
res:any;


ngOnInit()
{
  this.myForm = this.fb.group({
    firstName: ['abc', Validators.required],
    lastName: ['', Validators.required],
    email: ['', [Validators.required, Validators.email]],
    dob: ['', Validators.required]
  });
}


signUp(){
  const obj=
    {
        "user": {
          "firstName": this.firstName,
          "lastName": this.lastName,
          "email": this.email,
          "dob": this.dob,
          "username": "string",
          "password": "string",
          "isActive": 0
        
      }
    }
    this.service.signUp(obj).subscribe({
      next:(response)=>
      {
       console.log(response);
       if(response.statusCode ===200)
       {
         this.toastr.success("Username and Password has been sent to your mail")
       }
      },
      error:(err)=>
      {
        console.error(err);
        
      }
    })
}

}
