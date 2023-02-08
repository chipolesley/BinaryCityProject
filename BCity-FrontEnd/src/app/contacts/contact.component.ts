import { Router } from '@angular/router';
import { ContactService } from './contact.service';
import { Component, OnInit } from '@angular/core';

@Component({
    selector: "app-contact",
    templateUrl: "./contact.component.html",
    styleUrls: ["./contact.component.css"]

})
export class ContactComponent implements OnInit {

    contacts: Array<any> = [];
    message: string = ""
    loadingIndicator = true;
    reorderable = true;

    constructor(private contactService: ContactService, private router: Router) { }

    ngOnInit(): void {
        this.contactService.getContacts().subscribe((result: any) => {
            this.contacts = result.data;
            this.message = result.message;
        })
    }

    onCreateContact() {
        this.router.navigate(["create-contact"])
    }

}