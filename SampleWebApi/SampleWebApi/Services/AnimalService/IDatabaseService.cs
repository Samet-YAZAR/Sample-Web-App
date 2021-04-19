using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleWebApi.Services
{
    using SampleWebApi.Models;
    public interface IDatabaseService
    {
        IEnumerable<Animal> GetAnimals();
    }
}
