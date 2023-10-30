import { environment } from './../environments/environment';
import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css'],
})
export class AppComponent {
  selectedFile: File | null = null;
  fileName: string = '';
  apiUrl: string = 'http://localhost:5073/api/Videos';

  constructor(private client: HttpClient) {}

  onFileSelected(event: Event): void {
    const input = event.target as HTMLInputElement;
    console.log(input);
    if (input.files && input.files[0]) {
      this.selectedFile = input.files[0];
      this.fileName = this.selectedFile.name;
    }
  }

  uploadFile(): void {
    if (!this.selectedFile) {
      return;
    }

    const formData = new FormData();
    formData.append('file', this.selectedFile, this.selectedFile.name);

    // Here, you would send the formData to your server using Angular's HttpClient.
    // For simplicity, this example just logs the file name.
    debugger;
    this.client
      .post('http://localhost:5073/api/Videos/upload', formData)
      .subscribe(
        (response) => {
          console.log('Upload successful:', response);
        },
        (error) => {
          console.error('Upload error:', error);
        }
      );
    console.log(`Uploading ${this.selectedFile.name}...`);

    // Reset for demonstration purposes
    this.selectedFile = null;
    this.fileName = '';
  }
}
