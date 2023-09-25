/*
This function is used to load the data from work.json file to the mongodb database. Whenever we want to load
the database this function is imported and called.
*/
modules.exports = async function dataImport(){
    const data = fs.readFileSync('./work.json', 'utf8');
    
        let fileData1= JSON.parse(data);
        fileData1.map(async(fileData)=>{
            let dateTemp = fileData.SubmitDateTime.replaceAll(/\s/g,''); //to avoid string to data conversion white spaces must be trimed
            let dateFor = new Date(dateTemp); //converting field to adte
              const data1 = new Studentsmodel(
                {
                  "SubmittedAnswerId":fileData.SubmittedAnswerId,
                  "SubmitDateTime":dateFor,
                  "Correct":fileData.Correct,
                  "Progress":fileData.Progress,
                  "UserId":fileData.UserId,
                  "ExerciseId":fileData.ExerciseId,
                  "Difficulty":fileData.Difficulty,
                  "Subject":fileData.Subject,
                  "Domain":fileData.Domain,
                  "LearningObjective":fileData.LearningObjective
                })
                
                mongoose.set('debug',true);
                let result =  await data1.save(); //Save data to database
    
                mongoose.set('debug',(cal,method,query,doc)=>{ //This is set so we can check the import process on console as this process is hidden from end user
                    console.log(JSON.stringify(query))
                        })
                console.log(result)
        })
    }