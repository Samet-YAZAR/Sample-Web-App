using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleWebApi.Services
{
    using SampleWebApi.Models;
    interface IDatabaseService
    {
        IEnumerable<Animal> GetAnimals();
    }
}
