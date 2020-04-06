using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoTask.Models;

namespace TodoTask.BL
{
    public class EFTodo : ITodo
    {
        private readonly TodoTaskContext _context;
        public EFTodo(TodoTaskContext context)
        {
            _context = context;
        }


        public void CreateTodo(Todo todoModels)
        {
            _context.Add(todoModels);
            _context.SaveChanges();

        }

        public void DeleteTodo(Todo todoModels)
        {
            var todoModel = _context.Todo.Find(todoModels.TodoId);
            _context.Todo.Remove(todoModel);
            _context.SaveChanges();
        }

        public List<Todo> GetAllTodo()
        {
            return _context.Todo.Where(x=> DateTime.Now <= x.TodoExpDate ).ToList();
        }

        public List<Todo> GetIncomingTodo(string key)
        {
            List<Todo> list = new List<Todo>();
            switch(key)
            {
                case "today":
                    list = _context.Todo.Where(x => x.TodoDate == DateTime.Now && DateTime.Now <= x.TodoExpDate).ToList();
                    break;
                case "tommorow":
                    list = _context.Todo.Where(x => x.TodoDate == DateTime.Now.AddDays(1) && DateTime.Now <= x.TodoExpDate).ToList();
                    break;
                case "week":
                    
                    list = _context.Todo.Where(x => x.TodoDate >= getCurrentWeek()[0] && x.TodoDate <= getCurrentWeek()[1] && DateTime.Now <= x.TodoExpDate).ToList();
                    break;

            }
            return list;
        }

        public List<Todo> GetSpecificTodo(string key)
        {
            return _context.Todo.Where(x => x.Description.Contains(key) || x.Title.Contains(key)).ToList() ;
        }

        public Todo GetTodoByID(int id)
        {
            return _context.Todo.Where(x => x.TodoId == id).FirstOrDefault();
        }

        public void SetMarkTodo(Todo todoModels)
        {
            UpdateTodo(todoModels);
        }

        public void SetPercentCompleteTodo(Todo todoModels)
        {
            UpdateTodo(todoModels);
        }

        public void UpdateTodo(Todo todoModels)
        {
            _context.Update(todoModels);
            _context.SaveChangesAsync();
        }

        private String asda()
        {
            return "";
        }

        private DateTime[] getCurrentWeek()
        {
            DateTime date = DateTime.Now;
            DateTime[] range = new DateTime[2];
            switch(date.DayOfWeek.ToString().ToLower())
            {
                case "monday":
                    range[0] = date;
                    range[1] = date;
                    break;
                case "tuesday":
                    range[0] = date.AddDays(-1);
                    range[1] = date.AddDays(5);
                    break;
                case "wednesday":
                    range[0] = date.AddDays(-2);
                    range[1] = date.AddDays(4);
                    break;
                case "thursday":
                    range[0] = date.AddDays(-3);
                    range[1] = date.AddDays(3);
                    break;
                case "friday":
                    range[0] = date.AddDays(-4);
                    range[1] = date.AddDays(2);
                    break;
                case "saturday":
                    range[0] = date.AddDays(-5);
                    range[1] = date.AddDays(1);
                    break;
                case "sunday":
                    range[0] = date.AddDays(-6);
                    range[1] = date;
                    break;
            }
            return range;
                
        }
    }
}
