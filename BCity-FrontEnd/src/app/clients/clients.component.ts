import { Router } from '@angular/router';
import { ClientsService } from './clients.service';
import { Component, OnInit } from '@angular/core';
import { ColumnMode } from '@swimlane/ngx-datatable';

@Component({
    selector: "app-clients",
    templateUrl: "./clients.component.html",
    styleUrls: ["./clients.component.css"]

})
export class ClientsComponent implements OnInit {
    clients: Array<any> = [];
    message: string = "";
    loadingIndicator = true;
    reorderable = true;

    constructor(private clientService: ClientsService, private router: Router) { }

    ngOnInit(): void {
        this.clientService.getClients().subscribe((result: any) => {
            console.log(result);

            this.clients = result.data;
            this.message;
        })
    }

    onCreateClient() {
        this.router.navigate(["create-client"])
    }

}