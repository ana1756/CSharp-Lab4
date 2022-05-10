using Lab4.Models;
using Lab4.Repositories;
using System.Threading.Tasks;

namespace Lab4.Services
{
    internal class AuthentificationService
    {
        private static FileRepository Repository = new FileRepository();

        public async Task<bool> RegisterUser(Person regUser)
        {
            DBPerson dbUser = new DBPerson(regUser.ID, regUser.FirstName, regUser.LastName, regUser.Age.ToString(),
            regUser.Email, regUser.SunSign, regUser.ChineseSign);
            await FileRepository.AddOrUpdateAsync(dbUser);
            return true;
        }
    }
}
