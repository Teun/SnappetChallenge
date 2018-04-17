/* tslint:disable*/

declare namespace Nicollas.Dto.Identity {
	interface tokenDto{ 
        access_token: string;
        user_name: string;
        expires_in: number;
        roles_claims: Nicollas.Dto.Identity.roleClaimDto[];
        claims: Nicollas.Dto.Identity.userClaimDto[];
    }
}