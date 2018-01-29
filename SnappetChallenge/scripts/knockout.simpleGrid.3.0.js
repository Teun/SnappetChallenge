(function () {
    // Private function
    function getColumnsForScaffolding(data) {
        if ((typeof data.length !== 'number') || data.length === 0) {
            return [];
        }
        var columns = [];
        for (var propertyName in data[0]) {
            columns.push({ headerText: propertyName, rowText: propertyName });
        }
        return columns;
    }

    ko.simpleGrid = {
        // Defines a view model class you can use to populate a grid
        viewModel: function (configuration) {
            var self = this;
            self.data = configuration.data;
            self.currentPageIndex = ko.observable(0);
            var pageSize = configuration.pageSize == -1 ? ko.unwrap(this.data).length : configuration.pageSize || 5;
            self.pageSize = ko.observable(pageSize);
            self.pageSize.subscribe(function () {
                self.currentPageIndex(0);
            });
            // If you don't specify columns configuration, we'll use scaffolding
            self.columns = ko.observableArray(configuration.columns || getColumnsForScaffolding(ko.unwrap(this.data))); 

            self.maxPageIndex = ko.computed(function () {
                return Math.ceil(ko.unwrap(this.data).length / ko.unwrap(this.pageSize)) - 1;
            }, self);

            self.itemsOnCurrentPage = ko.computed(function () {
                var startIndex = ko.unwrap(self.pageSize) * Math.min(self.currentPageIndex(), self.maxPageIndex());
                return ko.unwrap(this.data).slice(startIndex, startIndex + ko.unwrap(self.pageSize));
            }, self);

            

            //custom
            self.rootModel = configuration.rootModel || self;
            self.tooltipText = configuration.tooltipText || function (text, tooltipCutLength) {
                text = ko.unwrap(text);
                if (!text)
                    text = '';
                return {
                    mainText: text.length > tooltipCutLength && tooltipCutLength ? text.substring(0, tooltipCutLength).trim() + '..' : text,
                    tooltipText: text.length > tooltipCutLength && tooltipCutLength ? text : ''
                }
            };
            
            if (configuration.currentPageIndexSubscribe) {
                self.currentPageIndex.subscribe(function () {
                    configuration.currentPageIndexSubscribe();
                });
            }
            if (configuration.dataSubscribe) {
                self.data.subscribe(function () {
                    configuration.dataSubscribe();
                });
            }

            self.sortProp = configuration.sortProp || ko.observable({});
            self.sortProp.subscribe(function (newSortProp) {
               self.data.sort(function (a, b) {
                    var aVal = ko.utils.unwrapObservable(a[newSortProp.field]) || '';
                    var bVal = ko.utils.unwrapObservable(b[newSortProp.field]) || '';


                    var col = jQuery.grep(ko.unwrap(self.columns), function (col1) {
                        return col1.dataField == newSortProp.field;
                    });
                    if (col[0].sortType == "numeric") {
                        aVal = parseInt(aVal || '0');
                        bVal = parseInt(bVal || '0');
                    } else if (col[0].sortType == "date") {
                        aVal = aVal.parseDateHeb();
                        bVal = bVal.parseDateHeb();
                    }

                    if (newSortProp.direction == 'asc') {
                        return aVal <= bVal ? -1 : 1;
                    }
                    else {
                        return aVal > bVal ? -1 : 1;
                    }
                });
            });


            self.defSortProp = configuration.defSortProp || ko.observable({});
            self.initSort = function () { self.sortProp(self.defSortProp()); };

            self.pagerClassSize = configuration.pagerClassSize;
            self.gridClass = configuration.gridClass;
            self.loading = ko.observable(configuration.loading || false);

        }
    };

    // Templates used to render the grid
    var templateEngine = new ko.nativeTemplateEngine();

    templateEngine.addTemplate = function (templateName, templateMarkup) {
        document.write("<script type='text/html' id='" + templateName + "'>" + templateMarkup + "<" + "/script>");
    };

    templateEngine.addTemplate("ko_simpleGrid_grid", "\
                    <table class=\"ko-grid\" cellspacing=\"0\">\
                        <thead>\
                            <tr data-bind=\"foreach: columns\">\
                               <th data-bind=\"text: headerText\"></th>\
                            </tr>\
                        </thead>\
                        <tbody data-bind=\"foreach: itemsOnCurrentPage\">\
                           <tr data-bind=\"foreach: $parent.columns\">\
                               <td data-bind=\"html: typeof rowText == 'function' ? rowText($parent, $root) : $parent[dataField] \"></td>\
                            </tr>\
                        </tbody>\
                    </table>");
    templateEngine.addTemplate("ko_simpleGrid_pageLinks", "\
                    <div class=\"ko-grid-pageLinks\" data-bind='visible: $root.data().length > 0 && ko.unwrap($root.maxPageIndex) > 0'>\
                        <span>Page:</span>\
                        <!-- ko foreach: ko.utils.range(0, maxPageIndex) -->\
                               <a href=\"#\" data-bind=\"text: $data + 1, click: function() { $root.currentPageIndex($data) }, css: { selected: $data == $root.currentPageIndex() }\">\
                            </a>\
                        <!-- /ko -->\
                    </div>");

    templateEngine.addTemplate("ko_simpleGrid_fullPager", "\
                    <nav class=\"ko-grid-pageLinks\" style='text-align:center' data-bind='visible: $root.data().length > 0 && ko.unwrap($root.pageSize) > -1 && ko.unwrap($root.maxPageIndex) > 0'>\
                        <ul data-bind='attr: { class: \"pagination pagination-\" + ($root.pagerClassSize ? $root.pagerClassSize : \"sm\") }'>\
                        <!-- ko if: $root.currentPageIndex() > 0 -->\
                            <li><a title='First Page' href=\"#\" data-bind=\"text: '<<', click: function () { $root.currentPageIndex(0); } \"></a></li>\
                            <li><a title='Previous Page' href=\"#\" data-bind=\"text: '<', click: function () { $root.currentPageIndex($root.currentPageIndex() - 1); } \"></a></li>\
                        <!-- /ko -->\
                        <!-- ko if: $root.currentPageIndex() ==  0 -->\
                            <li><span title='First Page'><<</span></li>\
                            <li><span title='Previous Page'><</span></li>\
                        <!-- /ko -->\
                        <!-- ko foreach: ko.utils.range(0, maxPageIndex) -->\
                                <li data-bind=\"css: { active: $data == $root.currentPageIndex() }\"><a href=\"#\" data-bind=\"    text: $data + 1, click: function () { $root.currentPageIndex($data) }, css: { selected: $data == $root.currentPageIndex() }\"></a></li>\
                        <!-- /ko -->\
                        <!-- ko if: $root.currentPageIndex() < $root.maxPageIndex() -->\
                            <li><a title='Next Page' href=\"#\" data-bind=\"text: '>', click: function () { $root.currentPageIndex($root.currentPageIndex() + 1); } \"></a></li>\
                            <li><a title='Last Page' href=\"#\" data-bind=\"text: '>>', click: function () { $root.currentPageIndex($root.maxPageIndex()); } \"></a></li>\
                        <!-- /ko -->\
                        <!-- ko if: $root.currentPageIndex() ==  $root.maxPageIndex()  -->\
                            <li><span title='Next Page'>></span></li>\
                            <li><span title='Last Page'>>></span></li>\
                        <!-- /ko -->\
                        </ul>\
                    </nav>");

    // The "simpleGrid" binding
    ko.bindingHandlers.simpleGrid = {
        init: function () {
            return { 'controlsDescendantBindings': true };
        },
        // This method is called to initialize the node, and will also be called again if you change what the grid is bound to
        update: function (element, viewModelAccessor, allBindings) {
            var viewModel = viewModelAccessor();

            // Empty the element
            while (element.firstChild)
                ko.removeNode(element.firstChild);

            // Allow the default templates to be overridden
            var gridTemplateName = allBindings.get('simpleGridTemplate') || "ko_simpleGrid_grid",
                pageLinksTemplateName = allBindings.get('simpleGridPagerTemplate') || "ko_simpleGrid_fullPager";

            // Render the main grid
            var gridContainer = element.appendChild(document.createElement("DIV"));
            ko.renderTemplate(gridTemplateName, viewModel, { templateEngine: templateEngine }, gridContainer, "replaceNode");

            // Render the page links
            var pageLinksContainer = element.appendChild(document.createElement("DIV"));
            ko.renderTemplate(pageLinksTemplateName, viewModel, { templateEngine: templateEngine }, pageLinksContainer, "replaceNode");
        }
    };
})();