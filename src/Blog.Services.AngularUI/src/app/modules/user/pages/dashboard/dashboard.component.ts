import {Component, OnInit, ViewEncapsulation} from '@angular/core';
import {ActivatedRoute, Data} from "@angular/router";
import {UserDashboardRequest} from "../../../../core/models/requests/user/userDashboardRequest";

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.scss'],
  encapsulation: ViewEncapsulation.None
})
export class DashboardComponent implements OnInit {
  public dashboard!: UserDashboardRequest;

  constructor(
    private route: ActivatedRoute
  ) {
  }

  ngOnInit(): void {
    this.route.data.subscribe((data: Data) => {
      this.dashboard = data['dashboard'];
    });
  }

}
