import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { HomeRoutingModule } from './home-routing.module';
import { HomeComponent } from './home.component';
import {SharedModule} from "../../shared/shared.module";
import { AdsComponent } from './components/ads/ads.component';
import { CategoriesComponent } from './components/categories/categories.component';
import { ConversationComponent } from './components/conversation/conversation.component';
import { LastPostsComponent } from './components/last-posts/last-posts.component';
import { MainSliderComponent } from './components/main-slider/main-slider.component';
import { MostViewNewsComponent } from './components/most-view-news/most-view-news.component';
import { NotesComponent } from './components/notes/notes.component';
import { PicturesComponent } from './components/pictures/pictures.component';
import { ReportsComponent } from './components/reports/reports.component';
import { VideoComponent } from './components/video/video.component';


@NgModule({
  declarations: [
    HomeComponent,
    AdsComponent,
    CategoriesComponent,
    ConversationComponent,
    LastPostsComponent,
    MainSliderComponent,
    MostViewNewsComponent,
    NotesComponent,
    PicturesComponent,
    ReportsComponent,
    VideoComponent
  ],
  imports: [
    CommonModule,
    HomeRoutingModule,
    SharedModule
  ]
})
export class HomeModule { }
