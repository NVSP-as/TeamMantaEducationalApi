using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using TeamMantaEducationalApi.Models;

namespace TeamMantaEducationalApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OperationsController : ControllerBase
    {
        [HttpGet]
        public IEnumerable<Operation> GetAllOperations()
        {
            Random random = new Random();
            string[] operationTypes = ["Queue", "InProgress", "Done"];
            string[] priorities = ["Low", "Medium", "High", "Critical"];
            string[] users = ["John Doe", "Jane Smith", "Bob Johnson", "Alice Brown"];

            List<Operation> operations = Enumerable.Range(1, random.Next(10, 16))
                                       .Select(id => new Operation
                                       {
                                           OperationId = id,
                                           Name = $"Operation-{id}",
                                           Description = $"This is a detailed description of Operation-{id}.",
                                           Type = operationTypes[random.Next(operationTypes.Length)],
                                           Priority = priorities[random.Next(priorities.Length)],
                                           AssignedTo = users[random.Next(users.Length)],
                                           Status = operationTypes[random.Next(operationTypes.Length)],
                                           CreatedDate = DateTime.UtcNow.AddMinutes(-random.Next(1, 500)),
                                           EstimatedCompletionTime = DateTime.UtcNow.AddMinutes(random.Next(100, 1000)),
                                           ProgressPercentage = random.Next(0, 101),
                                           IsDelayed = random.Next(0, 2) == 1
                                       })
                                       .ToList();

            return operations;
        }
    }
}
