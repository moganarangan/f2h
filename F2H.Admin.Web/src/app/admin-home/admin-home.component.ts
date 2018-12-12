import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-admin-home',
  templateUrl: './admin-home.component.html',
  styleUrls: ['./admin-home.component.scss']
})
export class AdminHomeComponent implements OnInit {
  selectedFile: File = null;

  constructor(private http: HttpClient) { }

  ngOnInit() {
  }

  onFileChanged = (event) => {
    this.selectedFile = event.target.files[0];
  }

  onUpload() {
    // upload code goes here
    // this.http is the injected HttpClient
    const formData = new FormData();
    formData.append('file', this.selectedFile)
    this.http.post('https://localhost:44369/api/image/home_banner', formData)
      .subscribe(event => {
        console.log(event);
      });
  }
}
