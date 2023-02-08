import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";

const Url = "https://localhost:7154/api/";

interface Client {
    Name: string
}

@Injectable()
export class ClientsService {

    constructor(private http: HttpClient) { }

    getClients() {
        return this.http.get(Url + "clients")
    }

    postClient(client: Client) {
        return this.http.post(Url + "client", client)
    }

    postClientLink(linkData: any) {
        return this.http.post(Url + "contactassignment", linkData);
    }
}