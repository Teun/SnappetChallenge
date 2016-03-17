require([ "https://code.jquery.com/jquery-2.2.1.min.js", "https://www.gstatic.com/charts/loader.js"], function(w){
	//console.log($);
	$.getJSON("http://localhost:50154/Service1.svc/submittedanswer/today").success(function(data) {
		
		var model = data;
		model.forEach(function(x){
			if(x.SubmitDateTime)
			{
				x.SubmitDate = new Date(x.SubmitDateTime).setHours(0,0,0,0);
				x.SubmitDateString = new Date(x.SubmitDate).toDateString();
			}
		})
		createFilters(model);
	
		$(".filter").on("change", function(){
			generateResult(model);
		});
	});

})



var generateResult = function(model){
	var m = model.slice();
	
	var user = $(".filter.UserId").val()
	if(user != "all")
    	m = m.filter(function(x){ return (x.UserId == user)})

	var Domain = $(".filter.Domain").val();
	if(Domain != "all")
    	m = m.filter(function(x){ return (x.Domain == Domain)})
    
    var Subject = $(".filter.Subject").val();
	if(Subject != "all")
    	m = m.filter(function(x){ return (x.Subject == Subject)})
    
	var LearningObjective = $(".filter.LearningObjective").val();
	if(LearningObjective != "all")
    	m = m.filter(function(x){ return (x.LearningObjective == LearningObjective)})
    
    var SubmitDate = $(".filter.SubmitDateString").val();
    if($(".filter.SubmitDateString").val() != "all")
    	m = filterByDate(m, $(".filter.SubmitDateString").val());

	var ExerciseId = $(".filter.ExerciseId").val();
		if(ExerciseId != "all")
	    	m = m.filter(function(x){ return (x.ExerciseId == ExerciseId)})
    
	
	//var Progress = $(".filter.progress").val();
	//if(Progress != "all")
    //	m = m.filter(function(x){ if(x.Progress == Progress) return true})
    

	if(m.length>1000)
		m = m.slice(0,1000);
	displayResults(m);
	//return m;
}


var displayResults = function(model){
	var results = document.getElementById("results");
	results.innerHTML = "";
	var UL =document.createElement("table");
	
	model.forEach(function(x){
		var li = document.createElement("li");
		var userId = document.createElement("div");
		userId.classList.add("userId");
		userId.innerText = x.UserId;
		li.appendChild(userId);

		var sDate = document.createElement("div");
		sDate.innerText = x.SubmitDateString;
		sDate.classList.add("sDate");
		li.appendChild(sDate);

		var subject = document.createElement("div");
		subject.innerText = x.Subject;
		subject.classList.add("subject");
		li.appendChild(subject);

		var progress = document.createElement("div");
		progress.innerText = x.Progress;
		progress.classList.add("progress");
		li.appendChild(progress);

		var objective = document.createElement("div");
		objective.innerText = x.LearningObjective;
		objective.classList.add("objective")
		li.appendChild(objective);

		var domain = document.createElement("div");
		domain.innerText = x.Domain;
		domain.classList.add("domain");
		li.appendChild(domain);

		UL.appendChild(li);

	})
	results.appendChild(UL);
}




var createFilters = function(model){
	
	var filters = document.getElementById("filters");

	filters.appendChild(createFilter(model, "UserId"));
	filters.appendChild(createFilter(model, "Domain"));
	filters.appendChild(createFilter(model, "ExerciseId"));
	filters.appendChild(createFilter(model, "LearningObjective"));
	filters.appendChild(createFilter(model, "Subject"));
	filters.appendChild(createFilter(model, "SubmitDateString"));
	
}


var createFilter = function(model, filterName){

	var arrFilter = getUnique(model, filterName);

	var select = document.createElement("select");
	select.classList.add("filter");
	select.classList.add(filterName);

	var o = document.createElement("option");
	o.value = "all";
	o.innerText = "all " + filterName + "s";
	select.appendChild(o);

	//arrFilter.sort();
	arrFilter.sort(function(a,b){return a - b})
	
	arrFilter.forEach(function(x){
		var o = document.createElement("option");
		o.value = x;
		o.innerText = x;
		select.appendChild(o);
	})

	return select;
}

var getUnique = function(model, item){
	var uniqueItems = [];
	model.slice().groupBy(item).forEach(function(x){ uniqueItems.push(x[0][item]) });
	return uniqueItems;
}



var filterByDate = function(arr, dateStr){
	return arr.slice().filter(function(x){
		if( new Date(x.SubmitDateTime).setHours(0,0,0,0) - new Date(dateStr) === 0 )
			return true;
		return false;
	})
}

var draw = function(){
		var data = new google.visualization.DataTable();
		data.addColumn('string', 'Element');
		data.addColumn('number', 'Percentage');
		data.addRows([
			['2015-5-2', 0.78],
			['2015-5-3', 0.21],
			['2015-5-4', 0.01]
		]);

		var chart = new google.visualization.LineChart(document.getElementById('myLineChart'));
		chart.draw(data, null);
}

Array.prototype.groupBy = function(prop){
    var sortedThis = this.slice().sort(function(x,y){return (x[prop] === y[prop] ? 0 : +(x[prop] > y[prop]) || -1  )});
    this.splice(0, this.length);
    var group = [];
    var lastItem = null;
    var self = this;
    sortedThis.forEach(function(item){
        if(item[prop])
        {
            if(lastItem === null || item[prop] === lastItem[prop])
            {
                group.push(item);
            }
            else
            {
                self.push(group.slice());
                group = [item];
            }
            lastItem = item; 
        }
    })
    this.push(group.slice());
    return this;
}
