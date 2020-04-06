using System;
using System.Collections.Generic;

namespace TodoTask.Models
{
    public partial class Todo
    {
        public int TodoId { get; set; }
        public DateTime? TodoDate { get; set; }
        public DateTime? TodoExpDate { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int? Complete { get; set; }
        public bool? IsDone { get; set; }
    }
}
