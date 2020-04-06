using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TodoTask.Models;
using TodoTask.BL;

namespace TodoTask.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class TodoController : ControllerBase
    {
        private readonly ITodo toDo; 

        public TodoController(ITodo Todo)
        {
            toDo = Todo; //use itodo interface via .net core dependency injection
        }

       [HttpGet]
        public List<Todo> GetAllTodo()
        {
            return toDo.GetAllTodo(); //call getAllTodo method
        }


        [HttpGet]
        public Todo GetTodoByID( int id)
        {
            return toDo.GetTodoByID(id); //call GetTodayByID method with parameter id
        }


        [HttpGet]
        public List<Todo> GetIncomingTodo(string key) //the choice are just "today" ,"tommorow", "week"
        {
            return toDo.GetIncomingTodo(key); //call GetIncomingTodo method with parameter key
        }

        [HttpGet]
        public List<Todo> GetSpecificTodo(string key) //key is used to get spesific todo based on title and description
        {
            return toDo.GetSpecificTodo(key); //call GetSpecificTodo method with parameter key
        }

        [HttpPost]
        public void CreateTodo([FromBody]Todo todoModels)
        {
            toDo.CreateTodo(todoModels); //call CreateTodo method with Todo model parameter
        }

        [HttpPut]
        public void UpdateTodo([FromBody]Todo todoModels)
        {
            toDo.UpdateTodo(todoModels); //call UpdateTodo method with Todo model parameter
        }

        [HttpDelete]
        public void DeleteTodo([FromBody]Todo todoModels)
        {
            toDo.DeleteTodo(todoModels); //call DeleteTodo method with Todo model parameter
        }

        [HttpPost]
        public void SetPercentCompleteTodo([FromBody] Todo todoModels)
        {
            toDo.SetPercentCompleteTodo(todoModels); //call SetPercentCompleteTodo method with Todo model parameter
        }

        [HttpPost]
        public void SetMarkTodo([FromBody]Todo todoModels)
        {
            todoModels.IsDone = true; // set mark done
            toDo.SetMarkTodo(todoModels); //call SetMarkTodo method with Todo model parameter
        }
    }
}