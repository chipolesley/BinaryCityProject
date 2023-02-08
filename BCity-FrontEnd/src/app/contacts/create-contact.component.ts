import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { MatSnackBar } from '@angular/material/snack-bar';
import { ClientsService } from 'app/clients/clients.service';
import { ContactService } from 'app/contacts/contact.service';

@Component({
    selector: "app-create-contact",
    templateUrl: "./create-contact.component.html",
    styleUrls: ["./contact.component.css"]

})
export class CreateContactComponent implements OnInit {
    clients: Array<any> = [];
    contacts: Array<any> = [];
    message: string = "";
    loadingIndicator = true;
    reorderable = true;
    GeneralForm: FormGroup;

    constructor(private clientService: ClientsService, private contactService: ContactService, private _snackBar: MatSnackBar) { }

    ngOnInit(): void {
        this.clientService.getClients().subscribe((result: any) => {
            console.log('client', result);

            this.clients = result.data;
            this.message = result.message;
        });

        this.contactService.getContacts().subscribe((result: any) => {
            console.log('contact', result.data);

            this.contacts = result.data;
            this.message = result.message;
        })

        this.GeneralForm = new FormGroup({
            'Name': new FormControl('', Validators.required),
            'Surname': new FormControl('', Validators.required),
            'Email': new FormControl('', [Validators.required, Validators.email])
        });
    }

    onSubmit() {
        // console.log(this.GeneralForm.value);
        if (this.GeneralForm.valid) {
            this.contactService.postContacts(this.GeneralForm.value).subscribe((response: any) => {
                console.log(response.message);
                this._snackBar.open(response.message, 'close');
                this.GeneralForm.reset();
            })
        }
        this._snackBar.open('Fill the required fields', 'close');
    }

}