using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace WebApplication1.App_Code.DAL
{
    public class Tasks
    {
        public int RowNumb { get; set; }
        public int idTask { get; set; }
        public string NameTask { get; set; }
        public Tasks()
        {
            RowNumb = 0;
            idTask = 0;
            NameTask = string.Empty;
        }
        public static Tasks Map(DataRow dataRow)
        {
            Tasks result = new Tasks();
            result.idTask = (int)dataRow["idTask"];
            result.NameTask = dataRow["NameTask"].ToString();
            return result;
        }
        public static Tasks Map(DataRow dataRow, int index)
        {
            //Метод для подсчета строк в таблице
            Tasks result = Map(dataRow);
            result.RowNumb = index;
            return result;
        }
    }
}