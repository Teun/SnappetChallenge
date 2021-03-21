using Snappet.Models.Database;
using Snappet.Models.Database.StoredProcedures.dbo;
using Snappet.Models.Database.StoredProcedures.Rep;

namespace Snappet.Logic.Database
{
    /// <summary>
    /// The database ORM interface
    /// </summary>
    public interface IDatabaseContext
    {
        /// <summary>
        /// Authenticate teachers by calling database Stored-Procedure
        /// </summary>
        /// <param name="inputs"></param>
        /// <returns></returns>
        DBResult SP_Teacher_Login(SP_Teacher_Login.Inputs inputs);

        /// <summary>
        /// What has my class been working on today?
        /// </summary>
        /// <param name="inputs"></param>
        /// <returns></returns>
        DBResult SP_Class_Progress(SP_Class_Progress.Inputs inputs);
    }
}
