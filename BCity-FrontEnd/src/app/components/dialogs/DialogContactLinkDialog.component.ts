import { FormControl, FormGroup, Validators } from '@angular/forms';
import { ClientsService } from './../../clients/clients.service';
import { Component, Inject } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { MatSnackBar } from '@angular/material/snack-bar';
@Component({
    selector: "app-contactlink-dialog",
    templateUrl: "./DialogContactLinkDialog.component.html"
})

export class DialogContactLinkDialog {
    clients: Array<any> = [];
    ClientForm: FormGroup;

    constructor(
        private clientService: ClientsService,
        private _snackBar: MatSnackBar,
        public dialogRef: MatDialogRef<any>,
        @Inject(MAT_DIALOG_DATA) public data: any,
    ) {
        this.clientService.getClients().subscribe((results: any) => {
            this.clients = results.data;
        });

        this.ClientForm = new FormGroup({
            'client': new FormControl('', Validators.required),
        })
    }

    onSubmit(): void {

        if (this.ClientForm.valid) {
            let linkData = {
                "client": this.ClientForm.value.client,
                "contact": this.data
            }

            console.log('log data ', linkData)

            this.clientService.postClientLink(linkData).subscribe((response: any) => {
                this._snackBar.open(response.message, 'close')
            })

            this.dialogRef.close();
        }
        this._snackBar.open("No Client Selected", 'close')
        this.dialogRef.close();
    }

}