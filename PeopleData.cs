using DataAccessLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLibrary
{
    public class PeopleData : IPeopleData
    {
        private readonly ISqlDataAccess _db;

        public PeopleData(ISqlDataAccess db)
        {
            _db = db;
        }

        public Task<List<PersonModel>> GetPeople()
        {
            string sql = "select * from dbo.People";

            return _db.LoadData<PersonModel, dynamic>(sql, new { });


            //var list = new List<PersonModel>();

            //list.Add(new PersonModel { FirstName = "xuan", LastName = "wang", HeroName = "nana" });

            //return Task.FromResult(list);
        }


        public Task InsertPerson(PersonModel person)
        {
            string sql = @"insert into dbo.People (FirstName, LastName, HeroName)
                            values (@FirstName, @LastName, @HeroName);";
            return _db.SaveData(sql, person);

        }

        //public Task InsertPerson(PersonModel person)
        //{
        //    string sql = @"insert into dbo.SuperHeroes (FirstName, LastName, HeroName)
        //                    values (@FirstName, @LastName, @HeroName);";
        //    return _db.SaveData(sql, person);

        //}
    }
}
