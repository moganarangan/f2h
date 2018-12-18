import { Component, Input, OnChanges } from '@angular/core';
import {HttpClient} from '@angular/common/http';
import {Observable, BehaviorSubject} from 'rxjs';
import { switchMap, map } from 'rxjs/operators';
import { DomSanitizer, SafeUrl } from '@angular/platform-browser';

@Component({
  selector: 'app-image-widget',
  template: `<img [src]="dataUrl$|async" alt="{{caption}}" class="{{imageClass}}" />`
})
export class ImageWidgetComponent implements OnChanges {
  @Input() private src: string;
  @Input() private caption: string;
  @Input() private imageClass: string;

  private src$ = new BehaviorSubject(this.src);
  dataUrl$ = this.src$.pipe(switchMap(url => this.loadImage(url)));

  ngOnChanges(): void {
    this.src$.next(this.src);
  }

  constructor(private httpClient: HttpClient, private domSanitizer: DomSanitizer) {
  }

  private loadImage(url: string): Observable<any> {
    return this.httpClient
      .get(url, {responseType: 'blob'})
      .pipe(map(e => this.domSanitizer.bypassSecurityTrustUrl(URL.createObjectURL(e))));
  }
}
