using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoTask.Models;


namespace TodoTask.BL
{
    public interface ITodo
    {
        public List<Todo> GetAllTodo();
        public List<Todo> GetSpecificTodo(string key);
        public Todo GetTodoByID(int id);
        public List<Todo> GetIncomingTodo(string key);
        public void CreateTodo(Todo todoModels);
        public void UpdateTodo(Todo todoModels);
        public void DeleteTodo(Todo todoModels);
        public void SetPercentCompleteTodo(Todo todoModels);
        public void SetMarkTodo(Todo todoModels);
    }
}
