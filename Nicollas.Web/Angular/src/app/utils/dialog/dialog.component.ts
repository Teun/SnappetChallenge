import { Component, OnInit, Inject } from '@angular/core';
import { MdDialogRef, MD_DIALOG_DATA } from '@angular/material';

@Component({
  selector: 'app-dialog',
  templateUrl: './dialog.component.html',
  styleUrls: ['./dialog.component.scss']
})
export class DialogComponent implements OnInit {
  private default = {
    response: true,
    customResponse: false,
    title: 'Waring',
    okText: 'Yes',
    noText: 'Cancel',
    question: 'Confirm the action?',
    timeout: 0,
  } as Utils.DialogData;

  constructor(
    public dialogRef: MdDialogRef<DialogComponent>,
    @Inject(MD_DIALOG_DATA) public data: Utils.DialogData) {
      this.data = Object.assign({}, this.default, data);
    }

  onNoClick(): void {
    this.data.response = false;
    this.dialogRef.close();
  }

  ngOnInit() {
    if (this.data.timeout > 0){
      this.CountDown();
    }
  }

  CountDown() {
    setTimeout(() => {
      if ( --this.data.timeout > 0) {
        this.CountDown();
      } else {
        this.onNoClick();
      }
    }, 1000);
  }
}


