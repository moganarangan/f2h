import { Component, OnInit } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';

@Component({
  selector: 'app-admin-home',
  templateUrl: './admin-home.component.html',
  styleUrls: ['./admin-home.component.scss']
})
export class AdminHomeComponent implements OnInit {
  selectedFile: File = null;
  dot = '.';

  constructor(private http: HttpClient) { }

  ngOnInit() {
  }

  onFileChanged = (event) => {
    this.selectedFile = event.target.files[0];
  }

  Uint8ToString = (uint8Array) => {
    const chunkSize = 0x8000; // Decimal 32768
    const chunks = [];
    for (let index = 0; index < uint8Array.length; index += chunkSize) {
      chunks.push(String.fromCharCode.apply(null, uint8Array.subarray(index, index + chunkSize)));
    }
    return chunks.join('');
  }

  onUpload() {
    // upload code goes here
    // this.http is the injected HttpClient

    const file = this.selectedFile;
    const filenameSansExtension = file.name.substring(0, file.name.lastIndexOf('.'));
    const extension = this.dot + file.name.split(this.dot).pop();

    const fileReader = new FileReader();

    if (fileReader && file) {
      fileReader.readAsArrayBuffer(file);

      fileReader.onload = () => {
        const imageData: any = fileReader.result,
          array = new Uint8Array(imageData),
          binaryString = btoa(this.Uint8ToString(array));

        const payload = {
          'content': binaryString,
          'imageName': filenameSansExtension,
          'fileExtension': extension
        };

        const formData = new FormData();
        formData.append('content', binaryString);
        formData.append('imageName', filenameSansExtension);
        formData.append('fileExtension', extension);

        const httpHeaders = new HttpHeaders({
          'Content-Type': 'application/json',
          'Cache-Control': 'no-cache'
        });

        const options = {
          headers: httpHeaders
        };

        this.http.post('https://localhost:44369/api/image/home_banner', payload, options)
          .subscribe(event => {
            console.log(event);
          });
      };
    }
  }

}
