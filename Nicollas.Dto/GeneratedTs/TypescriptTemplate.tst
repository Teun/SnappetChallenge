/*
* This template uses the TsT - Typewriter.
* Read more at :
* -- https://github.com/frhagn/Typewriter (Github)
* -- https://marketplace.visualstudio.com/items?itemName=frhagn.Typewriter  (Extension of Visual Studio 17)
* -- http://frhagn.github.io/Typewriter/ (Documentation)
*/

/* tslint:disable*/
${
    string StrongNameType(Type t)
    {
		if(t.IsEnumerable){
			return t.TypeArguments[0].Namespace + "." + t.name;
		}
        else if(!t.IsPrimitive){
			if(t.Name == "TKey"){
				return t.Name;
			}
			return t.Namespace + "." + t.name;
		}
		else{			
			return t.Name;
		}
    }
}
declare namespace $Classes(*Dto)[$Namespace {

	interface $name$TypeParameters $BaseClass[extends $Namespace.$name$TypeArguments] { $Properties[
        $name: $Type[$StrongNameType];]
    }]
}