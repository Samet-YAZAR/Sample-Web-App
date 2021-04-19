
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleWebApi.Services.AnimalServiceAsync
{
    using SampleWebApi.Models;
    public interface IDatabaseService2
    {
        Task<IEnumerable<Animal>> GetAnimalsByStoredProcedureAsync();
        Task<IEnumerable<Animal>> GetAnimalsAsync();
        Task<int> ChangeAnimalAsync();
    }
}
