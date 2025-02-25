import { Component, OnInit } from '@angular/core';
import { TrainComponentService } from './train.service';
import { TrainComponent } from './types/types';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { ModalComponent } from '../shared/components/modal/modal.component';

@Component({
  selector: 'train-component-list',
  templateUrl: './train.component.html',
  styleUrl: './train.component.scss', 
  standalone: true,
  imports: [CommonModule, FormsModule, ModalComponent]
})
export class TrainComponentListComponent implements OnInit {
  components: TrainComponent[] = [];
  currentPage = 1;
  message: string = '';
  messageType: 'success' | 'error' = 'success';
  isModalOpen = false;
  newComponent: TrainComponent = { id: 0, name: '', uniqueNumber: '', canAssignQuantity: false, quantity: 1 };
  editMode: { [id: number]: boolean } = {};

  constructor(private readonly trainService: TrainComponentService) {}

  ngOnInit() {
    this.loadComponents();
  }

  openCreateModal() {
    this.newComponent = { id: 0, name: '', uniqueNumber: '', canAssignQuantity: false, quantity: 1 };
    this.isModalOpen = true;
  }
  
  createComponent() {
    this.trainService.createComponent(this.newComponent).subscribe(response => {
      this.showMessage(response, 'success');
      this.isModalOpen = false;
      this.loadComponents();
    }, error => {
      this.showMessage(error.error, 'error');
    });
  }

  updateComponent(component: TrainComponent) {
    this.trainService.updateComponent(component).subscribe(response => {
      this.showMessage(response, 'success');
      this.editMode[component.id] = false;
    }, error => {
      this.showMessage(error.error, 'error');
    });
  }
  
  enableEdit(component: TrainComponent) {
    this.editMode[component.id] = true;
  }
  
  cancelEdit(component: TrainComponent) {
    this.editMode[component.id] = false;
    this.loadComponents();
  }
  
  updateQuantity(component: TrainComponent) {
    if (component.quantity && component.quantity > 0) {
      this.trainService.updateQuantity(component.id, component.quantity).subscribe(response => {
        this.showMessage(response, 'success');
      }, error => {
        this.showMessage(error.error, 'error');
      });
    } else {
      this.showMessage('Quantity must be a positive integer', 'error');
    }
  }
  
  nextPage() {
    this.currentPage++;
    this.loadComponents();
  }
  
  prevPage() {
    if (this.currentPage > 1) {
      this.currentPage--;
      this.loadComponents();
    }
  }
  
  private loadComponents() {
    this.trainService.getComponents(this.currentPage).subscribe((data) => {
      this.components = data;
    });
  }
  
  private showMessage(text: string, type: 'success' | 'error') {
    this.message = text;
    this.messageType = type;
    setTimeout(() => this.message = '', 3000);
  }
}
