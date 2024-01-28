import { Component } from '@angular/core';
import { BreakpointObserver, Breakpoints } from '@angular/cdk/layout';
import { Observable } from 'rxjs';
import { map, shareReplay } from 'rxjs/operators';
import { CookieService } from 'ngx-cookie-service';

@Component({
  selector: 'app-navigation',
  templateUrl: './navigation.component.html',
  styleUrls: ['./navigation.component.css']
})
export class NavigationComponent {

  idRolAdmin: boolean = false;
  idRolComercio: boolean = false;
  idRolPagador: boolean = false;
  isHandset$: Observable<boolean> = this.breakpointObserver.observe(Breakpoints.Handset)
    .pipe(
      map(result => result.matches),
      shareReplay()
    );

  constructor(private cookieService: CookieService, private breakpointObserver: BreakpointObserver) {
    this.idRolAdmin = this.cookieService.get('idRol') == "1" ? true : false;
    this.idRolComercio = this.cookieService.get('idRol') == "2" ? true : false;
    this.idRolPagador = this.cookieService.get('idRol') == "3" ? true : false;
  }

}
