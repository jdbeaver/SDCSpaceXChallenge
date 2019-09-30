import { TestBed, async, inject, fakeAsync, tick } from '@angular/core/testing';
import { XHRBackend, ResponseOptions, Response } from '@angular/http';
import { MockBackend, MockConnection } from '@angular/http/testing';
import { SDCSpaceXService } from './sdcspacexService';
import { HttpClientTestingModule, HttpTestingController } from '@angular/common/http/testing';
import { HttpClientModule, HttpErrorResponse, HttpClient } from '@angular/common/http';

import { NO_ERRORS_SCHEMA } from '@angular/core';



describe('SDCSpaceXService', () => {
  let service: SDCSpaceXService;
  let httpTestingController: HttpTestingController;
  let backend: MockBackend;
  beforeEach(async(() => {
    TestBed.configureTestingModule({
      imports: [HttpClientTestingModule],
      providers: [
        SDCSpaceXService,
        MockBackend
        //{ provide: XHRBackend, useClass: MockBackend },
        //{ provide: HttpClient }
      ],
      schemas: [NO_ERRORS_SCHEMA]
    });
    // Inject the http service and test controller for each test
    service = TestBed.get(SDCSpaceXService);
    httpTestingController = TestBed.get(HttpTestingController);
    backend = TestBed.get(MockBackend)
  }));

  afterEach(() => {
    httpTestingController.verify();
  })

  /// Tests begin ///
  it('should get launchpad info', () => {
    expect(service).toBeTruthy();
  });

  //test for response 
  it('should get HttpClient.get response', fakeAsync(() => {
    //create the mock data
    const mockResponse = [
        { id: 'vafb_slc_3w', full_name: 'Vandenberg Air Force Base Space Launch Complex 3W', status: 'retired' },
        { id: 'ccafs_slc_40', full_name: 'Cape Canaveral Air Force Station Space Launch Complex 40', status: 'active' },
    ];
    const limit = '0';
    const status = 'all';

    //When the request subscribes for results on a connection, return a fake response
    backend.connections.subscribe((connection) => {
      connection.mockRespond(new Response(<ResponseOptions>{
        body: JSON.stringify(mockResponse)
      }));
    });

    //call the service 
    service.getLPInfo(status, limit).subscribe((res) => {
      //expect(res.length).toBe(2);
      expect(res[1].id).toBe('ccafs_slc_40');
      expect(res[1].full_name).toBe('Cape Canaveral Air Force Station Space Launch Complex 40');
      expect(res[1].status).toBe('active');
      expect(res).toEqual(mockResponse)
    });

    //set the HttpClient mock - url 
    const req = httpTestingController.expectOne(`${service._spaceX_API_getinfo}` + '?Status=all&Limit=0');
    expect(req.request.method).toEqual("GET")
    //need to flush for the data to be returned by the mock
    req.flush(mockResponse);
   
  }));

  //test for no service/error


})
