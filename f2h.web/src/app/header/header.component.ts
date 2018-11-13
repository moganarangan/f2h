import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.scss']
})
export class HeaderComponent implements OnInit {

  showSideBar: Boolean = false;

  constructor() { }

  ngOnInit() {
  }

  public w3_open = () => {
    this.showSideBar = true;
  }

  public w3_close = () => {
    this.showSideBar = false;
  }

}
