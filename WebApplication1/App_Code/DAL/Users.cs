using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace WebApplication1.App_Code.DAL
{
    public class Users
    {
        public int RowNumb { get; set; }
        public int idUser { get; set; }
        public int IdPosition { get; set; }
        public string NameUser { get; set; }
        public DateTime? BirthDateUser { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public int AgeUser { get; set; }
        public string GenderUser { get; set; }
        public Users()
        {
            RowNumb = 0;
            idUser = 0;
            IdPosition = 0;
            NameUser = string.Empty;
            BirthDateUser = null;
            PhoneNumber = string.Empty;
            Email = string.Empty;
            AgeUser = 0;
            GenderUser = string.Empty;
        }
        public static Users Map(DataRow dataRow)
        {
            Users result = new Users();
            result.idUser = (int)dataRow["IdUser"];
            result.IdPosition = (int)dataRow["IdPosition"];
            result.NameUser = dataRow["NameUser"].ToString();
            result.BirthDateUser = dataRow["BirthDateUser"] != DBNull.Value ? (DateTime?)dataRow["BirthDateUser"] : null;
            result.PhoneNumber = dataRow["PhoneNumber"].ToString();
            result.Email = dataRow["Email"].ToString();
            result.AgeUser = int.Parse(dataRow["AgeUser"].ToString());
            result.GenderUser = dataRow["GenderUser"].ToString();
            return result;
        }
        public static Users Map(DataRow dataRow, int index)
        {
            //Метод для подсчета строк в таблице
            Users result = Map(dataRow);
            result.RowNumb = index;
            return result;
        }

    }
}