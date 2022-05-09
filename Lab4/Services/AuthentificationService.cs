using Lab4.Models;
using Lab4.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4.Services
{
    internal class AuthentificationService
    {
        private static FileRepository Repository = new FileRepository();

        public async Task<bool> RegisterUser(Person regUser)
        {
            var dbUser = await Repository.GetAsync(regUser.ID);


            if (dbUser != null)
            {
               
            }

            // checks

            dbUser = new DBPerson(regUser.ID, regUser.FirstName, regUser.LastName, regUser.Age.ToString(),
                regUser.Email,  regUser.SunSign, regUser.ChineseSign);
           await FileRepository.AddOrUpdateAsync(dbUser);
            return true;
        }
    }
}
