import { Injectable, OnDestroy } from '@angular/core';
import { Api } from 'app/api.service';
import { Observable } from 'rxjs/Observable';
import { Store } from '@ngrx/store'
import * as fromRoot from 'app/store/reducers';
import { Filter } from 'app/store/reducers/BaseReducer';

@Injectable()
export class RealtimeService implements OnDestroy {


  private static socket: WebSocket;
public static readonly path = `ws://${window.location.host}/ws`
  private static store: Store<fromRoot.State>;
  private static api: Api;

  private static OnMessageHandler(this: WebSocket, ev: MessageEvent) {
    const data = JSON.parse(ev.data) as Nicollas.Dto.Realtime.realtimeDto;

    switch (data.actionNeeded) {
      case 3: // ActionNeeded.RefreshByResponse:
        RealtimeService.store.dispatch({type : `[${data.reducer}] ${data.type || 'UPDATE_REDUCER'}`, payload: data.result});
        break;
      case 2: // ActionNeeded.RefreshReducer:
        RealtimeService.store.dispatch({type : `[${data.reducer}] ${data.type || 'NEED_REFRESH'}`, payload: data.result});
        break;
      case 1: // ActionNeeded.DoCallback:
        RealtimeService.DoCallback(data);
        break;
      case 4: // ActionNeeded.Init:
        localStorage.setItem('realtimeToken', data.result);
        break;
      default:
        break;
    }
    // data.Value is the response
    console.log('Realtime function found an message: ' + JSON.stringify(data));
    // RealtimeService.store.dispatch({type: ''});
  }

  private static OnErrorHandler(this: WebSocket, ev: Event) {
    console.error('Realtime function found an error: ' + ev);
  }

  private static OnCloseHandler(this: WebSocket, ev: CloseEvent) {
    console.log('Realtime function closed ' + ev.reason)
    RealtimeService.socket = null;
  }

  private static OnOpenHandler(this: WebSocket, ev: Event) {
    console.log('Realtime function started ');
  }

  private static DoCallback(response: Nicollas.Dto.Realtime.realtimeDto){
    this.api.get<Nicollas.Dto.baseEntityDto<number>[]>(`${response.reducer}\\${response.callback || 'Read'}`)
    .publishLast().refCount().subscribe(
      data => {
        const filter = new Filter<Nicollas.Dto.baseEntityDto<number>, number>(data)
        RealtimeService.store.
        dispatch({type : `[${response.reducer}] ${response.type || 'ReadComplete'}`, payload: filter});
      }
    )
  }

  public static Open() {
    if (!RealtimeService.socket) {
      RealtimeService.socket = new WebSocket(RealtimeService.path);
      RealtimeService.socket.onmessage = RealtimeService.OnMessageHandler;
      RealtimeService.socket.onerror = RealtimeService.OnErrorHandler;
      RealtimeService.socket.onclose = RealtimeService.OnCloseHandler;
      RealtimeService.socket.onopen = RealtimeService.OnOpenHandler;
    }
  }

  public static Close() {
    if (RealtimeService.socket) {
      RealtimeService.socket.close();
      localStorage.removeItem('realtimeToken');
    }
  }

  constructor(private _api: Api, private _store: Store<fromRoot.State>) {
    if (!RealtimeService.store) {
      localStorage.removeItem('realtimeToken');
      RealtimeService.store = _store;
      RealtimeService.api = _api;
    }
  }

  ngOnDestroy(): void {
    RealtimeService.Close();
  }
}
