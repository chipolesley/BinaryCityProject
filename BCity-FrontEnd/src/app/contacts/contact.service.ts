import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";

const Url = "https://localhost:7154/api/";

interface Contact {
    Name: string
}

@Injectable()
export class ContactService {

    constructor(private http: HttpClient) { }

    getContacts() {
        return this.http.get(Url + "contacts")
    }

    postContacts(contact: Contact) {
        return this.http.post(Url + "contact", contact)
    }
}