import {AfterViewInit, Component} from '@angular/core';

declare function DocumentInit(): any;

@Component({
  selector: 'app-main-slider',
  templateUrl: './main-slider.component.html'
})
export class MainSliderComponent implements AfterViewInit {

  constructor() {
  }

  ngAfterViewInit(): void {
    DocumentInit();
  }

}
