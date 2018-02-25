namespace Snappet.Core.Utils
{
    public class ApplicationConstants
    {
        #region -- Work File Path --

        public const string WorkItem = "work_item";
        public const string WorkFilePath = @"~/App_Data/work.csv";
        public const char FileDelimiter = ',';
        #endregion

        #region -- Application Logs --
        public const string SuccessfullyDeleted = "Log(s) has been successfully deleted.";
        public const string LogRefresh = "Log(s) has been successfully refreshed."; 
        public const string SuccessfullySaved = " record was successfully updated";
        public const string UnableToSave = "Unable to save record "; 

        #endregion
    }
}
