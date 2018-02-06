using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using snappet.core.Models.EF;
using snappet.core.Models.ViewModels;

namespace snappet.core.Contracts
{
    public interface IUserMethods
    {
        List<UserVM> GetAllUsers();
        UserVM GetSpecificUser(int UserID, int Weeks = 1);
    }

    
}
