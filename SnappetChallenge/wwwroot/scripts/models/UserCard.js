var SnappetChallenge;
(function (SnappetChallenge) {
    var Models;
    (function (Models) {
        var UserCard = /** @class */ (function () {
            function UserCard(userId, name, progress, imageUrl) {
                this.userId = userId;
                this.name = name;
                this.progress = progress;
                this.imageUrl = imageUrl;
            }
            return UserCard;
        }());
        Models.UserCard = UserCard;
    })(Models = SnappetChallenge.Models || (SnappetChallenge.Models = {}));
})(SnappetChallenge || (SnappetChallenge = {}));
//# sourceMappingURL=userCard.js.map