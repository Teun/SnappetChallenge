module SnappetChallenge.Models {
    export class UserCard {
        constructor(
            public userId: number,
            public name: string,
            public progress: number,
            public imageUrl: string) {
        }
    }
}