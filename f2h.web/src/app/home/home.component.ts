import { Component, OnInit } from '@angular/core';
import { SwiperConfigInterface } from 'ngx-swiper-wrapper';
import { HomeService } from '../services/home.service';
import HomeBanner from '../models/home-banner-model';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent implements OnInit {

  sliderConfig: SwiperConfigInterface = {
    direction: 'horizontal',
    slidesPerView: 1,
    spaceBetween: 30,
    centeredSlides: true,
    loop: true,
    preloadImages: true,
    updateOnImagesReady: true,
    autoplay: {
      delay: 2500,
      disableOnInteraction: false,
    },
    pagination: {
      el: '.swiper-pagination',
      clickable: true,
    }
  };

  private homeBannerList: Array<HomeBanner>;

  constructor(private homeService: HomeService) { }

  ngOnInit() {
    this.loadHomeBanner();
  }

  loadHomeBanner = () => {
    this.homeService.getHomeBanner().subscribe(
      data => this.homeBannerList = data,
      error => console.log(error)
    );
  }

}
