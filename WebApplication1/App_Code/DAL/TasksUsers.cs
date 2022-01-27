using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace WebApplication1.App_Code.DAL
{
    public class TasksUsers
    {
        public int RowNumb { get; set; }
        public int IdUserTask { get; set; }
        public int IdTask { get; set; }
        public int IdUser { get; set; }
        public TasksUsers()
        {
            RowNumb = 0;
            IdUserTask = 0;
            IdTask = 0;
            IdUser = 0;
        }
        public static TasksUsers Map(DataRow dataRow)
        {
            TasksUsers result = new TasksUsers();
            result.IdUserTask = (int)dataRow["IdUserTask"];
            result.IdTask = (int)dataRow["IdTask"];
            result.IdUser = (int)dataRow["IdUser"];
            return result;
        }
        public static TasksUsers Map(DataRow dataRow, int index)
        {
            //Метод для подсчета строк в таблице
            TasksUsers result = Map(dataRow);
            result.RowNumb = index;
            return result;
        }
    }
}