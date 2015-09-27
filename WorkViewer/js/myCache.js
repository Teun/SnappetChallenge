var MyCache = function()
{
    var self = this,
        add = function (key, value) {
        self.data.key = value;
    },
    remove = function (key) {
        if (key) {
            self.data.key = undefined;
        }
        else {
            self.data = {};
        }
    },
    get = function (key) {
        return self.data.key;
    };

    self.data = {};
    self.add = add;
    self.evic = remove;
    self.get = get;
    self.exists = function (key) { return get(key) != undefined; }
}