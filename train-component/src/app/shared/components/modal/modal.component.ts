import { CommonModule } from '@angular/common';
import { Component, EventEmitter, Input, Output } from '@angular/core';

@Component({
  selector: 'app-modal',
  templateUrl: './modal.component.html',
  styleUrl: './modal.component.scss',
  standalone: true,
  imports: [CommonModule]
})
export class ModalComponent {
  @Input() isOpen = false;
  @Input() title = '';
  @Output() closeEvent = new EventEmitter<void>();
  @Output() saveEvent = new EventEmitter<void>();

  close() {
    this.closeEvent.emit();
  }

  save() {
    this.saveEvent.emit();
  }
}
