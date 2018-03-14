import { Injectable } from '@angular/core';
import { Api } from 'app/api.service';
import { Observable } from 'rxjs/Observable';

@Injectable()
export class UserService {
  constructor(private api: Api) { }

  Read(): Observable<Nicollas.Dto.Identity.userDto[]> {
    return this.api.get<Nicollas.Dto.Identity.userDto[]>('User/Read').publishLast().refCount();
  }

  Create(Entity:  Nicollas.Dto.Identity.userDto, RoleId: string): Observable<number> {
    return this.api.post<number>(`User/Create?roleId=${RoleId}`, Entity).publishLast().refCount();
  }

  Update(Entity:  Nicollas.Dto.Identity.userDto): Observable<boolean> {
    return this.api.put<boolean>('User/Update', Entity).publishLast().refCount();
  }

  DisableOrEnable(Entity:  Nicollas.Dto.Identity.userDto): Observable<boolean> {
    return this.api.put<boolean>('User/DisableOrEnable', Entity).publishLast().refCount();
  }

  ResetPassword(Entity:  Nicollas.Dto.Identity.userDto): Observable<boolean> {
    return this.api.put<boolean>('User/ResetPassword', Entity).publishLast().refCount();
  }

  ChangePassword(Entity:  Nicollas.Dto.Identity.userDto, NewPassword: string, OldPassword: string): Observable<boolean> {
    Entity.password = NewPassword;
    return this.api.put<boolean>(`User/ChangePassword/&old=${OldPassword}`, Entity).publishLast().refCount();
  }

  UploadFile(Entity:  Nicollas.Dto.Identity.userDto, file: File): Observable<boolean> {
    return this.api.postFile<boolean>('User/imageUpload', Entity, [file]).publishLast().refCount();
  }
}
