import {Injectable} from "@angular/core";
import { HttpClient, HttpParams } from '@angular/common/http';
import { Observable } from "rxjs/Rx";


@Injectable()
export class SDCSpaceXService {
    //simple angular interface to RESTFul service 
    public _spaceX_API_getinfo: string = "api/spacexlaunchpad/getlpinfo";

    constructor(private http: HttpClient) { }

  getLPInfo(status:string, limit:string) {
    // Setup log namespace query parameter
    // Initialize Params Object
    let params = new HttpParams();
    // Begin assigning parameters
    params = params.append('Status', status);
    params = params.append('Limit', limit);
    return this.http.get(this._spaceX_API_getinfo, { params: params });
  }
}
