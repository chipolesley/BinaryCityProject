import { ClientsService } from './clients.service';
import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { MatSnackBar } from '@angular/material/snack-bar';
import { ContactService } from 'app/contacts/contact.service';
import { MatDialog } from '@angular/material/dialog';
import { DialogContactLinkDialog } from 'app/components/dialogs/DialogContactLinkDialog.component';

@Component({
    selector: "app-create-clients",
    templateUrl: "./create-client.component.html",
    styleUrls: ["./clients.component.css"]

})
export class CreateClientComponent implements OnInit {
    clients: Array<any> = [];
    contacts: Array<any> = [];
    message: string = "";
    loadingIndicator = true;
    reorderable = true;
    GeneralForm: FormGroup;

    constructor(private clientService: ClientsService,
        private contactService: ContactService,
        private _snackBar: MatSnackBar,
        public dialog: MatDialog) { }

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
            'ClientCode': new FormControl()
        });
    }

    onSubmit() {
        // console.log(this.GeneralForm.value);
        if (this.GeneralForm.valid) {
            this.clientService.postClient(this.GeneralForm.value).subscribe((response: any) => {
                console.log(response.message);
                this._snackBar.open(response.message, 'close');
                this.GeneralForm.reset();
            })
        }
        this._snackBar.open('Fill the required fields', 'close');
    }

    openDialog(contact: any) {
        console.log('data sent ', contact);

        this.dialog.open(DialogContactLinkDialog, { 'data': contact });
    }

}