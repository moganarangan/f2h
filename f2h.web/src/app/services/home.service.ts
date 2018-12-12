import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

import HomeBanner from '../models/home-banner-model';

@Injectable()
export class HomeService {

  private url = 'https://localhost:44369/api/homebanner';

  constructor(private http: HttpClient) { }

  getHomeBanner(): Observable<Array<HomeBanner>> {
    return this.http.get<Array<HomeBanner>>(this.url);
  }

}
