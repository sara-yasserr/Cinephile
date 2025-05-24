import { Routes } from '@angular/router';
import { LoginComponent } from '../components/login/login.component';
import { RegisterComponent } from '../components/register/register.component';
import { IndexComponent } from '../components/index/index.component';
import { DetailsComponent } from '../components/Details/Details.component';
import { TicketsComponent } from '../components/tickets/tickets.component';
import { PaymentComponent } from '../components/payment/payment.component';

export const routes: Routes = [
    {path:'',redirectTo:'login',pathMatch:'full'},
    {path:"login",component:LoginComponent},
    {path:"register",component:RegisterComponent},
    {path:"index",component:IndexComponent},
    {path:"tickets/:id",component:TicketsComponent},
    {path:"details/:id",component:DetailsComponent},
    {path:"payment",component:PaymentComponent}
    // {path:'**'}

];
