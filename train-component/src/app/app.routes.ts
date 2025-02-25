import { Routes } from '@angular/router';
import { TrainComponentListComponent } from './train/train.component';

export const routes: Routes = [
    { 
        path: '', 
        redirectTo: 'components', 
        pathMatch: 'full' 
    },
    { 
        path: 'components', 
        component: TrainComponentListComponent 
    }
];
