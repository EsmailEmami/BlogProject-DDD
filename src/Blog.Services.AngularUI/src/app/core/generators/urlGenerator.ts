import {Router} from "@angular/router";

export abstract class UrlGenerator {
  public static getCurrentUrlWithoutParams(router: Router): string {
    let urlTree = router.parseUrl(router.url);

    urlTree.queryParams = {};
    urlTree.fragment = null; // optional

    return decodeURIComponent(urlTree.toString());
  }
}
