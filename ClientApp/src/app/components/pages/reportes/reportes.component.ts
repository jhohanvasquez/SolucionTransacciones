import { Component, OnInit, ViewChild} from '@angular/core';

import { MatTableDataSource } from '@angular/material/table';
import { MatPaginator } from '@angular/material/paginator';
import { MatDialog } from '@angular/material/dialog';
import { MatSnackBar } from '@angular/material/snack-bar';
import { ComercioService } from '../../../services/comercio.service';
import { TransaccionService } from '../../../services/transaccion.service';
import { CookieService } from 'ngx-cookie-service';

@Component({
  selector: 'app-reportes',
  templateUrl: './reportes.component.html',
  styleUrls: ['./reportes.component.css']
})
export class ReportesComponent implements OnInit {

  constructor(
    private cookieService: CookieService,
    private dialog: MatDialog,
    private _snackBar: MatSnackBar,
    private _comercioServicio: ComercioService,
    private _transaccionServicio: TransaccionService
  ) {

  }

  ngOnInit(): void {

  }
}
