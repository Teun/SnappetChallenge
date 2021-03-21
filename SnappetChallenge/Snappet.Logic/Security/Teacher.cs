namespace Snappet.Logic.Security
{
    public class Teacher : Models.Database.StoredProcedures.dbo.SP_Teacher_Login.Inputs
    {
        /// <summary>
        /// Validation username & password and generate JWT
        /// </summary>
        /// <param name="ctx">Database ORM</param>
        /// <param name="mapper">The object mapper</param>
        /// <param name="key">JWT key</param>
        /// <param name="issuer">JWT issuer</param>
        /// <returns></returns>
        public Models.Database.DBResult Login(
            Database.IDatabaseContext ctx,
            AutoMapper.IMapper mapper,
            string key,
            string issuer)
        {
            //Call DB
            var dbResult = ctx.SP_Teacher_Login(this);
            if (dbResult.StatusCode != 200)
                return dbResult;

            //Convert Teacher to User object
            var user = mapper.Map<User>(dbResult.Data);

            //Generate JWT and return as the result
            return user.GetJWT(key, issuer);
        }
    }
}