using Milestone350.Models;

namespace Milestone350.Services
{
    public class SecurityService
    {
        SecurityDAO securityDAO = new SecurityDAO();

        public bool IsValid(UserModel user)
        {
            return securityDAO.FindUserByNameAndPassword(user);
        }

        public bool IsAdded(UserModel user)
        {
            return securityDAO.addUserToDatabase(user);
        }
    }
}
