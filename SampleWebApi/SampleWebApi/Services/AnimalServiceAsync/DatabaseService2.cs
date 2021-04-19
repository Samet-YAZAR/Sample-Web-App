using SampleWebApi.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace SampleWebApi.Services.AnimalServiceAsync
{
    class DatabaseService2 : IDatabaseService2
    {
        public async Task<int> ChangeAnimalAsync()
        {
            using var con = new SqlConnection("Data Source=db-mssql;Initial Catalog=s18378;Integrated Security=True");
            using var com = new SqlCommand("select * from animal", con);

            await con.OpenAsync();
            DbTransaction tran = await con.BeginTransactionAsync();
            com.Transaction = (SqlTransaction)tran;

            try
            {
                var list = new List<Animal>();
                using (var dr = await com.ExecuteReaderAsync())
                {
                    while (await dr.ReadAsync())
                    {
                        list.Add(new Animal
                        {
                            Name = dr["Name"].ToString(),
                            Description = dr["Description"].ToString()
                        });
                    }
                }

                com.Parameters.Clear();
                com.CommandText = "Update Animal Set Name= Name+ 'a' Where Name= @Name";
                com.Parameters.AddWithValue("@Name", list[0].Name);
                await com.ExecuteNonQueryAsync();

                throw new Exception("Error");

                com.Parameters.Clear();
                com.Parameters.AddWithValue("@Name", list[1].Name);
                await com.ExecuteNonQueryAsync();

                await tran.CommitAsync();
            }
            catch (SqlException exc)
            {
                await tran.RollbackAsync();
            }
            catch (Exception exc)
            {
                await tran.RollbackAsync();
            }
            return 1;
        }

        public async Task<IEnumerable<Animal>> GetAnimalsAsync()
        {
            using var con = new SqlConnection("Data Source=db-mssql;Initial Catalog=s18378;Integrated Security=True");
            using var com = new SqlCommand("select * from Animal", con);
            await con.OpenAsync();
            var dr = await com.ExecuteReaderAsync();
            var result = new List<Animal>();
            while (await dr.ReadAsync())
            {
                await Task.Delay(300);
                result.Add(new Animal
                {
                    Name = dr["Name"].ToString(),
                    Description = dr["Description"].ToString()
                });
            }
            return result;
        }

        public async Task<IEnumerable<Animal>> GetAnimalsByStoredProcedureAsync()
        {
            using var con = new SqlConnection("Data Source=db-mssql;Initial Catalog=s18378;Integrated Security=True");
            using var com = new SqlCommand("GetAnimals", con);
            com.CommandType = CommandType.StoredProcedure;

            await con.OpenAsync();
            var result = new List<Animal>();
            using (var dr = await com.ExecuteReaderAsync())
            {
                while(await dr.ReadAsync())
                {
                    result.Add(new Animal
                    {
                        Name = dr["Name"].ToString(),
                        Description = dr["Description"].ToString()
                    });
                }
            }
            return result;
        }
    }
}
