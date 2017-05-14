import {Component, OnInit} from "@angular/core";
import { Http, RequestOptions, Headers } from '@angular/http';
import { Router } from "@angular/router";
import { Observable } from 'rxjs/Observable';

@Component({
    selector: "app",
    templateUrl: "./app/app.html"
})
export class AppComponent implements OnInit {
    constructor(private http: Http, private router:Router) {}

    ngOnInit() {
        console.log("Application component initialized ...");
    }
    foo: string;
    fileChange(event) {
        console.log('select file');
        let res;
        let fileList: FileList = event.target.files;
        if (fileList.length > 0) {
            let file: File = fileList[0];
            let formData:FormData = new FormData();
            formData.append('uploadFile', file, file.name);
            let headers = new Headers();
            headers.append('Content-Type', 'multipart/form-data');
            headers.append('Accept', 'application/json');
            this.http.post('http://localhost:2514/api/ocr', formData, new RequestOptions(headers))
                .map(res => res.json())
                .subscribe(
                    data => {
                        console.log('success');
                        res = data;
                        console.log(res);
                        this.foo = "";
                        this.router.navigate(['/report', {report: JSON.stringify(res)}]);
                    },
                    error => console.log(error)
                );
        }
    }
}