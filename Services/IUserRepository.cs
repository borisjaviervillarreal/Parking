using Parking.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Parking.Services
{
    public interface IUserRepository
    {
        UserDTO GetUser(UserModel userMode);
    }
}
