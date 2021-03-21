using AutoMapper;

namespace Snappet.Logic.CommonOperations
{
    public class Mapper : Profile
    {
        /// <summary>
        /// How to convert objects
        /// </summary>
        public Mapper()
        {
            //Map Teacher to User and set the Role as Teacher.
            CreateMap<Models.Database.StoredProcedures.dbo.SP_Teacher_Login.Outputs, Logic.Security.User>()
                    .AfterMap((s, d) => d.Role = Security.Roles.Teacher);
        }
    }
}
