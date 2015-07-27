/* Convert SubmitDateTime property to ISODate with the goal of optimized data retrieval.  */
var cursor = db.submitted_answers.find();
while (cursor.hasNext()) {
    var doc = cursor.next();
    db.submitted_answers.update({ _id: doc._id }, { $set: { SubmitDateTime: new Date(doc.SubmitDateTime) } });
};