using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleWebApi.Services
{
    using SampleWebApi.Models;
    using System.Data.SqlClient;
    using System.Threading;

    public class DatabaseService : IDatabaseService
    {
        public IEnumerable<Animal> GetAnimals()
        {
            using var con = new SqlConnection("Data Source=db-mssql;Initial Catalog=s18378;Integrated Security=True");
            using var com = new SqlCommand("select * from animal", con);
            con.Open();
            var dr = com.ExecuteReader();
            var result = new List<Animal>();
            while (dr.Read())
            {
                Thread.Sleep(300);
                result.Add(new Animal
                {
                    Name = dr["Name"].ToString(),
                    Description = dr["Description"].ToString()
                });
            }
            return result;
        }
    }
}
