/*
* This template uses the TsT - Typewriter.
* Read more at :
* -- https://github.com/frhagn/Typewriter (Github)
* -- https://marketplace.visualstudio.com/items?itemName=frhagn.Typewriter  (Extension of Visual Studio 17)
* -- http://frhagn.github.io/Typewriter/ (Documentation)
*/

/* tslint:disable*/

declare namespace Nicollas.Dto.Identity {

	interface userDto extends Nicollas.Dto.baseEntityDto<string> { 
        userName: string;
        email: string;
        firstName: string;
        lastName: string;
        password: string;
        roles: Nicollas.Dto.Identity.userRoleDto[];
        claims: Nicollas.Dto.Identity.userClaimDto[];
    }
}