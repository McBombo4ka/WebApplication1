using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace WebApplication1.App_Code.DAL
{
    public class Position
    {
        public int RowNumb { get; set; }
        public int idPosition { get; set; }
        public string NamePosition {get; set;}
        public Position()
        {
            RowNumb = 0;
            idPosition = 0;
            NamePosition = string.Empty;
        }
        public static Position Map(DataRow dataRow)
        {
            Position result = new Position();
            result.idPosition = (int)dataRow["idPosition"];
            result.NamePosition = dataRow["NamePosition"].ToString();
            return result;
        }
        public static Position Map(DataRow dataRow, int index)
        {
            //Метод для подсчета строк в таблице
            Position result = Map(dataRow);
            result.RowNumb = index;
            return result;
        }
    }
}