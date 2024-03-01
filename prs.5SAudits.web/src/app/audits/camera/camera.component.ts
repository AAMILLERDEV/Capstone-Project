import { Component, Input, OnInit } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { WebcamImage, WebcamInitError } from 'ngx-webcam';
import { Observable, Subject } from 'rxjs';
import { Resources } from 'src/models/Resources';
import { ResourcesService } from 'src/services/resource.service';

@Component({
  selector: 'app-camera',
  templateUrl: './camera.component.html',
  styleUrls: ['./camera.component.scss']
})
export class CameraComponent implements OnInit {

  @Input() audit_ID: number = 0;
  @Input() scoreCategory_ID: number = 0;
  @Input() public photoCollection: Resources[] = [];

  public trigger: Subject<void> = new Subject<void>();

  constructor(private toastr: ToastrService,
    private resourceService: ResourcesService){

  }

  ngOnInit() {
    
  }

  public handleInitError(error: WebcamInitError){
    console.log(error.message);
    if (error.mediaStreamError){
      this.toastr.error(error.message);
    }
  }

  public async stashPhoto(image: WebcamImage){
    let resource: Resources = {
      audit_ID: this.audit_ID,
      dateAdded: new Date(),
      id: 0,
      score_ID: this.scoreCategory_ID,
      resourceData: image.imageAsBase64
    };

    this.photoCollection.push(resource);
  }

  public triggerSnapshot(): void {
    this.trigger.next();
  }

  public async savePhotos(){
    for (let x of this.photoCollection){
      await this.resourceService.upsertResource(x);
    }
  }

  public get triggerObservable(): Observable<void>{
    return this.trigger.asObservable();
  }



}
