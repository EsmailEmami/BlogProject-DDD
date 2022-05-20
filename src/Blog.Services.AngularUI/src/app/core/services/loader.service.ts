import {Injectable} from '@angular/core';

declare function startLoading(): any;
declare function stopLoading(): any;

@Injectable({
  providedIn: 'root'
})
export class LoaderService {

  constructor() {
  }

  public start(): void {
    startLoading();
  }

  public stop(): void {
    stopLoading();
  }
}
