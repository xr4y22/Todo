using NUnit.Framework;
using TodoTask.Controllers;
using TodoTask.BL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.DependencyInjection;

namespace NUnitTest
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            var serviceProvider = new ServiceCollection()
         .AddScoped<ITodo, EFTodo>().BuildServiceProvider();
          
            var iTodo = serviceProvider.GetService<ITodo>();
            TodoController todo = new TodoController(iTodo);
            Assert.AreEqual("raymond", todo.GetTodoByID(3).Title);
        }
    }
}