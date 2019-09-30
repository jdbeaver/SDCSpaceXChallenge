import { TestBed, async, ComponentFixture } from '@angular/core/testing';
import { HomeComponent } from './home.component';
import { MatTableModule, MatTable } from '@angular/material';
import { NO_ERRORS_SCHEMA } from '@angular/core';
import { SDCSpaceXService } from '../../services/sdcspacexService'
import { HttpClientTestingModule, HttpTestingController } from '@angular/common/http/testing';



describe('HomeComponent', () => {
  let hc: HomeComponent;
  let fixture: ComponentFixture<HomeComponent>
  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [
        HomeComponent
      ],
      imports: [
        MatTableModule,
        HttpClientTestingModule
      ],
      providers: [SDCSpaceXService,],
      schemas: [NO_ERRORS_SCHEMA]
    }).compileComponents().then(() => {
      fixture = TestBed.createComponent(HomeComponent);
      hc = fixture.componentInstance; //homecompont test instance
    })
  }));

  it('should create the componenet', async(() => {
    expect(hc).toBeTruthy();
  }));
  it('should populate the table', async(() => {
    const displayedColumns: string[] = ['id', 'full_name', 'status'];
    const dataSource = [
      { id: 'vafb_slc_3w', full_name: 'Vandenberg Air Force Base Space Launch Complex 3W', status: 'retired' },
      { id: 'ccafs_slc_40', full_name: 'Cape Canaveral Air Force Station Space Launch Complex 40', status: 'active' }
    ];
    hc.dataSource = dataSource
    hc.displayedColumns = displayedColumns
    fixture.detectChanges()
  }));
});
