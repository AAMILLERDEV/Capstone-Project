import { Component, Input, OnInit } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { WebcamImage, WebcamInitError } from 'ngx-webcam';
import { Observable, Subject } from 'rxjs';
import { Resources } from 'src/models/Resources';
import { ResourcesService } from 'src/services/resource.service';
import { OwlOptions } from 'ngx-owl-carousel-o';

declare var bootstrap: any;

@Component({
  selector: 'app-camera',
  templateUrl: './camera.component.html',
  styleUrls: ['./camera.component.scss']
})
export class CameraComponent implements OnInit {

  @Input() audit_ID: number | null = null;
  @Input() scoreCategory_ID: number = 0;
  @Input() public photoCollection: Resources[] = [];
  @Input() public afterPhotoCollection: Resources[] = [];
  @Input() public editMode: boolean = false;
  
  public customOptions!: OwlOptions;

  openedPhoto: Resources | null = null;
  openedIndex: number = 0;

  afterMode: boolean = false;

  public trigger: Subject<void> = new Subject<void>();

  constructor(private toastr: ToastrService,
    private resourcesService: ResourcesService){

  }

  ngOnInit() {
    this.fetchResources();

    if (this.editMode) {
      this.afterMode = true;
    }

    this.customOptions = {
      loop: true,
      mouseDrag: false,
      touchDrag: false,
      pullDrag: false,
      autoWidth: true,
      autoHeight: true,
      dots: true,
      navSpeed: 700,
      navText: [ '<i class="btn bi bi-arrow-bar-left text-dark"> Previous</i>', '<i class="btn bi bi-arrow-bar-right text-dark"> Next</i>' ],
      responsive: {
        0: {
          items: 1
        },
        400: {
          items: 2
        },
        740: {
          items: 3
        }
      },
      nav: true
    }
  }

  public async fetchResources() {
    let resources = await this.resourcesService.getResources(this.audit_ID!);
    for (let x of resources) {
      if (x.score_ID == this.scoreCategory_ID) {
        if (!x.isDeleted) {
          x.isNew = false;

          if (x.isAfter) {
            this.afterPhotoCollection.push(x);
          }
          else {
            this.photoCollection.push(x);
          }
        }
      }
    }
    console.log(this.photoCollection);
    console.log(this.afterPhotoCollection);
  }

  public handleInitError(error: WebcamInitError){
    console.log(error.message);
    if (error.mediaStreamError){
      this.toastr.error(error.message);
    }
  }

  public async stashPhoto(image: WebcamImage){
    let resource: Resources = {
      audit_ID: this.audit_ID!,
      dateAdded: new Date(),
      id: 0,
      score_ID: this.scoreCategory_ID,
      resourceData: image.imageAsBase64,
      isDeleted: false,
      isAfter: this.afterMode,
      isNew: true
    };
    
    if (this.afterMode) {
      this.afterPhotoCollection.push(resource);
    }
    else {
      this.photoCollection.push(resource);
    }
  }

  public triggerSnapshot(): void {
    this.trigger.next();
  }

  public async savePhotos(){
    let allPhotos = [...this.photoCollection, ...this.afterPhotoCollection];

    for (let x of allPhotos){
      console.log(x);
      if (x.isNew) {
        x.isNew = false;
        let response = await this.resourcesService.upsertResources(x);
        console.log(response);
  
        if (response > 0) {
          this.toastr.success("Images Saved Successfully");
        }
      }
    }
  }

  public get triggerObservable(): Observable<void>{
    return this.trigger.asObservable();
  }

  public openPhotoPopup (photo: Resources, index: number) {
    this.openedPhoto = photo;
    this.openedIndex = index;

    const photoModalTemplate = document.getElementById('photoPopup');
    const photoModal = new bootstrap.Modal(photoModalTemplate);
    photoModal.show();
  }


  public deletePhoto() {

    if (this.afterMode) {
      this.resourcesService.deleteResource(this.afterPhotoCollection[this.openedIndex].id);
      this.afterPhotoCollection.splice(this.openedIndex, 1);
    }

    else {
      this.resourcesService.deleteResource(this.photoCollection[this.openedIndex].id);
      this.photoCollection.splice(this.openedIndex, 1);
    }

    const photoModalTemplate = document.getElementById('photoPopup');
    const photoModal = bootstrap.Modal.getInstance(photoModalTemplate);

    photoModal.hide();
  }

  public swapModes() {
    this.afterMode = !this.afterMode;
  }

}
