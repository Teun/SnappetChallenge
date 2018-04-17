/*
* This template uses the TsT - Typewriter.
* Read more at :
* -- https://github.com/frhagn/Typewriter (Github)
* -- https://marketplace.visualstudio.com/items?itemName=frhagn.Typewriter  (Extension of Visual Studio 17)
* -- http://frhagn.github.io/Typewriter/ (Documentation)
*/

/* tslint:disable*/

declare namespace Nicollas.Dto {

	interface baseEntityDto<TKey>  { 
        id: TKey;
        createdAt: Date;
        updatedAt: Date;
        trash: boolean;
        disabled: boolean;
    }
}