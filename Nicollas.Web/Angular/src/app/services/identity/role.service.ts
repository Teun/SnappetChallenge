import { Injectable } from '@angular/core';
import { Api } from 'app/api.service';
import { Observable } from 'rxjs/Observable';

@Injectable()
export class RoleService {
  constructor(private api: Api) { }

  Read(): Observable<Nicollas.Dto.Identity.roleDto[]> {
    return this.api.get<Nicollas.Dto.Identity.roleDto[]>('Role/Read').publishLast().refCount();
  }

  Create(Entity:  Nicollas.Dto.Identity.roleDto): Observable<number> {
    return this.api.post<number>('Role/Create', Entity).publishLast().refCount();
  }

  Update(Entity:  Nicollas.Dto.Identity.roleDto): Observable<boolean> {
    return this.api.put<boolean>('Role/Update', Entity).publishLast().refCount();
  }

  DisableOrEnable(Entity:  Nicollas.Dto.Identity.roleDto): Observable<boolean> {
    return this.api.put<boolean>('Role/DisableOrEnable', Entity).publishLast().refCount();
  }
}
