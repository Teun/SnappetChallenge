/*
* This template uses the TsT - Typewriter.
* Read more at :
* -- https://github.com/frhagn/Typewriter (Github)
* -- https://marketplace.visualstudio.com/items?itemName=frhagn.Typewriter  (Extension of Visual Studio 17)
* -- http://frhagn.github.io/Typewriter/ (Documentation)
*/

/* tslint:disable*/

declare namespace Nicollas.Dto.Realtime {

	interface realtimeDto  { 
        actionNeeded: ActionNeeded;
        reducer: string;
        type: string;
        actionName: string;
        result: System.any;
        method: string;
        callback: string;
    }
}