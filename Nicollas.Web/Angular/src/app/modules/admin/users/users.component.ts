import { Component, OnInit, ViewChild, OnDestroy } from '@angular/core';

import { Store } from '@ngrx/store';
import * as fromRoot from 'app/store/reducers';
import * as fromIdentity from 'app/store/reducers/identity';
import * as userAction from 'app/store/actions/identity/user.action';
import * as roleAction from 'app/store/actions/identity/role.action';
import { Observable } from 'rxjs/Observable';
import { BsModalComponent } from 'Ng2-bs3-modal/';
import { Subscription } from 'rxjs/Subscription';
import { CdkDataSource } from 'app/utils/cdk-data-source';
import { BehaviorSubject } from 'rxjs/BehaviorSubject';
import { MdDialog, MdDialogConfig } from '@angular/material';
import { DialogComponent } from 'app/utils/dialog/dialog.component';

@Component({
  selector: 'app-users',
  templateUrl: './users.component.html',
  styleUrls: ['./users.component.scss']
})
export class UsersComponent implements OnInit, OnDestroy {
  IsBusy: Observable<boolean>;
  dataSource: CdkDataSource<Nicollas.Dto.Identity.userDto, string>;

  rolesSourceSelect: CdkDataSource<Nicollas.Dto.Identity.roleDto, string>;
  rolesSource: CdkDataSource<Nicollas.Dto.Identity.roleDto, string>;

  Entity = {} as Nicollas.Dto.Identity.userDto;
  getDisabled = false;
  error: string;
  private subscriptions: Subscription[] = [];
  private keepOpen: boolean;

  private roleToAdd: string;

  @ViewChild('modal') modal: BsModalComponent;

  constructor(private store: Store<fromRoot.State>, public dialog: MdDialog) { }

  ngOnInit() {
    // For principal
    this.IsBusy = this.store.select(_ => _.user.loading);
    this.dataSource = new CdkDataSource(this.store.select(fromIdentity.getUsers));
    this.dataSource.filter = (data: Nicollas.Dto.Identity.userDto) => data.disabled !== true || this.getDisabled;
    this.subscriptions.push(this.store.select(_ => _.user.lastActionOnReducer).distinctUntilChanged().subscribe(data => {
      switch (data) {
        case userAction.ACTION_FAILED:
        case userAction.CREATE:
        case userAction.READ:
        case userAction.DELETE:
        case userAction.UPDATE:
          break;
        default:
          if (!this.keepOpen) {
            this.modal.close();
          }
          this.Entity = {} as Nicollas.Dto.Identity.userDto;
      }
    }));
    this.subscriptions.push(this.store.select(_ => _.user.error).subscribe(async (data) => {
      if (data) {
        this.error = await data.text();
      }
    }));
    this.store.select(fromIdentity.getUsers).take(1).subscribe(data => {
      if (data.length === 0) {
        this.store.dispatch(new userAction.ReadAction());
      }
    })
    // For principal

    // For Roles
    this.rolesSourceSelect = new CdkDataSource(this.store.select(fromIdentity.getRoles));
    this.rolesSource = new CdkDataSource(this.store.select(fromIdentity.getRoles));
    this.store.select(fromIdentity.getRoles).take(1).subscribe(data => {
      if (data.length === 0) {
        this.store.dispatch(new roleAction.ReadAction());
      }
    })
  }

  ngOnDestroy() {
    this.subscriptions.forEach(sub => sub.unsubscribe());
  }

  dismissed() {
    this.Entity = {} as Nicollas.Dto.Identity.userDto
  }

  openModal(entity: Nicollas.Dto.Identity.userDto) {
    this.Entity = Object.assign({}, entity);
    this.rolesSource.filter = this.userRolefilter;
    this.rolesSourceSelect.filter = this.addRoleToUserFilter;
    this.modal.open('lg');
  }

  enableOrDisable(entity: Nicollas.Dto.Identity.userDto) {
    this.store.dispatch(new userAction.DisableAction(entity));
  }

  create(keep: boolean) {
    this.keepOpen = keep;
    if (this.Entity.id) {
      this.store.dispatch(new userAction.UpdateAction(Object.assign({}, this.Entity)));

    } else {
      this.store.dispatch(new userAction.CreateAction(Object.assign({}, this.Entity)));
    }
  }

  filterChange() {
    this.getDisabled = !this.getDisabled;
    this.dataSource.filter = (data: Nicollas.Dto.Identity.userDto) => data.disabled !== true || this.getDisabled;
  }

  removeRole(row: Nicollas.Dto.Identity.roleDto) {
    this.Entity.roles = [...this.Entity.roles.filter(role => role.roleId !== row.id)];
    this.rolesSource.filter = this.userRolefilter;
    this.rolesSourceSelect.filter = this.addRoleToUserFilter;
  }

  resetPassword() {
    const dialogRef = this.dialog.open(DialogComponent, {
      width: '250px', disableClose: true,
      data: { timeout: 30, question: 'For application propuse, This function was disabled.' } as Utils.DialogData
    } as MdDialogConfig );
    dialogRef.afterClosed().subscribe(result => {
      // if (result) {
      //   this.store.dispatch(new userAction.ResetPasswordAction(Object.assign({}, this.Entity)));
      // }
    });
  }

  addRole() {
    if (this.Entity.roles) {
      this.Entity.roles.push({roleId: this.roleToAdd} as Nicollas.Dto.Identity.userRoleDto);
    }else {
      this.Entity.roles = [{roleId: this.roleToAdd} as Nicollas.Dto.Identity.userRoleDto];
    }
    this.roleToAdd = null;
    this.rolesSource.filter = this.userRolefilter;
    this.rolesSourceSelect.filter = this.addRoleToUserFilter;
  }

  private addRoleToUserFilter = row => {
    if (this.Entity.roles && this.Entity.roles.length > 0) {
      return !this.Entity.roles.some(role => role.roleId === row.id);
    }
    return true;
  }

  private userRolefilter = row => {
    if (this.Entity.roles && this.Entity.roles.length > 0) {
      return this.Entity.roles.some(role => role.roleId === row.id);
    }
    return false;
  }
}
