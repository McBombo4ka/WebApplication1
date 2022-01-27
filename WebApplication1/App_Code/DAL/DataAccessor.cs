using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Odbc;
using System.Linq;
using System.Web;

namespace WebApplication1.App_Code.DAL
{
    public class DataAccessor
    {
        private static OdbcConnection conn = null;
        public static OdbcConnection Conn
        {
            get
            {
                if (conn == null)
                {
                    conn = new OdbcConnection(Config.ConnectionString);
                }
                return conn;
            }

        }
        public static void CreateConnection(string connectionString)
        {
            conn = new OdbcConnection(connectionString);
        }
        private static OdbcCommand cmd = null;
        private static OdbcDataAdapter dataAdapter = null;
        #region Users
        public static Users SelectUser(int id)
        {
            Users result = null;
            DataTable dataTable = new DataTable();
            using (cmd = Conn.CreateCommand())
            {
                Conn.Open();
                try
                {
                    cmd.CommandText = "Select [Users].[IdUser], [Users].* FROM [Users] WHERE [Users].[IdUser] = ?";
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("[Users].[IdUser]", id);
                    dataAdapter = new OdbcDataAdapter(cmd);
                    dataAdapter.Fill(dataTable); ;
                    dataAdapter.Dispose();
                    if (dataTable.Rows.Count > 0)
                    {
                        result = Users.Map(dataTable.Rows[0]);
                    }
                }
                catch
                {
                    throw;
                }
                finally
                {
                    conn.Close();
                }
            }
            return result;
        }
        public static List<Users> SelectUsers()
        {
            List<Users> result = new List<Users>();
            DataTable dataTable = new DataTable();
            using (cmd = Conn.CreateCommand())
            {
                Conn.Open();
                try
                {
                    cmd.CommandText =
                    "SELECT Users.* FROM Users";
                    dataAdapter = new OdbcDataAdapter(cmd);
                    dataAdapter.Fill(dataTable);
                    dataAdapter.Dispose();
                }
                catch
                {
                    throw;
                }
                finally
                {
                    conn.Close();
                }
                int i = 1;// счетчик строк в таблице
                foreach (DataRow row in dataTable.Rows)
                {
                    result.Add(Users.Map(row, i));
                    i++;
                }
            }
            return result;
        }

        public static int InsertUser(Users entity)
        {
            int result = 0;
            using (cmd = Conn.CreateCommand())
            {
                conn.Open();
                try
                {
                    cmd.CommandText = "INSERT INTO [Users] ([IdPosition], [NameUser], [BirthDateUser], [PhoneNumber],[Email],[GenderUser]) VALUES (?,?,?,?,?,?)";
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("[IdPosition]", entity.IdPosition);
                    cmd.Parameters.AddWithValue("[NameUser]", entity.NameUser);
                    cmd.Parameters.AddWithValue("[BirthDateUser]", entity.BirthDateUser);
                    cmd.Parameters.AddWithValue("[PhoneNumber]", entity.PhoneNumber);
                    cmd.Parameters.AddWithValue("[Email]", entity.Email);
                    cmd.Parameters.AddWithValue("[GenderUser]", entity.GenderUser);
                    cmd.ExecuteNonQuery();
                    cmd.CommandText = "SELECT @@IDENTITY";
                    object o = cmd.ExecuteScalar();
                    if (o != null)
                    {
                        result = int.Parse(o.ToString());
                    }
                }
                catch
                {
                    throw;
                }
                finally
                {
                    conn.Close();
                }
            }
            return result;
        }

        public static void UpdateUser(Users entity)
        {
            using (cmd = Conn.CreateCommand())
            {
                conn.Open();
                try
                {
                    cmd.CommandText = "UPDATE [Users] SET [IdPosition]=?, [NameUser]=?, [BirthDateUser]=?, [PhoneNumber]=?, [Email]=?,[GenderUser]=? WHERE [Users].[idUser]";
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("[IdPosition]", entity.IdPosition);
                    cmd.Parameters.AddWithValue("[NameUser]", entity.NameUser);
                    cmd.Parameters.AddWithValue("[BirthDateUser]", entity.BirthDateUser);
                    cmd.Parameters.AddWithValue("[PhoneNumber]", entity.PhoneNumber);
                    cmd.Parameters.AddWithValue("[Email]", entity.Email);
                    cmd.Parameters.AddWithValue("[GenderUser]", entity.GenderUser);
                    cmd.Parameters.AddWithValue("[idUser]", entity.idUser);
                    cmd.ExecuteNonQuery();
                }
                catch
                {
                    throw;
                }
                finally
                {
                    conn.Close();
                }
            }
        }

        public static void DeleteUser(int id)
        {
            using (cmd = Conn.CreateCommand())
            {
                conn.Open();
                try
                {
                    cmd.CommandText = "DELETE FROM [Users] WHERE [IdUser]=?";
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("[IdUser]", id);
                    cmd.ExecuteNonQuery();
                }
                catch
                {
                    throw;
                }
                finally
                {
                    conn.Close();
                }
            }
        }
        #endregion Users

        #region Position
        public static Position SelectPosition(int id)
        {
            Position result = null;
            DataTable dataTable = new DataTable();
            using (cmd = Conn.CreateCommand())
            {
                Conn.Open();
                try
                {
                    cmd.CommandText = "Select [Position].[idPosition], [Position].* FROM [Position] WHERE [Position].[idPosition] = ?";
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("[Position].[idPosition]", id);
                    dataAdapter = new OdbcDataAdapter(cmd);
                    dataAdapter.Fill(dataTable); ;
                    dataAdapter.Dispose();
                    if (dataTable.Rows.Count > 0)
                    {
                        result = Position.Map(dataTable.Rows[0]);
                    }
                }
                catch
                {
                    throw;
                }
                finally
                {
                    conn.Close();
                }
            }
            return result;
        }
        public static List<Position> SelectPositions()
        {
            List<Position> result = new List<Position>();
            DataTable dataTable = new DataTable();
            using (cmd = Conn.CreateCommand())
            {
                Conn.Open();
                try
                {
                    cmd.CommandText =
                    "SELECT Position.* FROM Position";
                    dataAdapter = new OdbcDataAdapter(cmd);
                    dataAdapter.Fill(dataTable);
                    dataAdapter.Dispose();
                }
                catch
                {
                    throw;
                }
                finally
                {
                    conn.Close();
                }
                int i = 1;// счетчик строк в таблице
                foreach (DataRow row in dataTable.Rows)
                {
                    result.Add(Position.Map(row, i));
                    i++;
                }
            }
            return result;
        }

        public static int InsertPosition(Position entity)
        {
            int result = 0;
            using (cmd = Conn.CreateCommand())
            {
                conn.Open();
                try
                {
                    cmd.CommandText = "INSERT INTO [Position] ([NamePosition]) VALUES (?)";
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("[NamePosition]", entity.NamePosition);
                    cmd.ExecuteNonQuery();
                    cmd.CommandText = "SELECT @@IDENTITY";
                    object o = cmd.ExecuteScalar();
                    if (o != null)
                    {
                        result = int.Parse(o.ToString());
                    }
                }
                catch
                {
                    throw;
                }
                finally
                {
                    conn.Close();
                }
            }
            return result;
        }

        public static void UpdatePosition(Position entity)
        {
            using (cmd = Conn.CreateCommand())
            {
                conn.Open();
                try
                {
                    cmd.CommandText = "UPDATE [Position] SET [NamePosition]=? WHERE [Position].[idPosition]";
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("[NamePosition]", entity.NamePosition);
                    cmd.Parameters.AddWithValue("[idPosition]", entity.idPosition);
                    cmd.ExecuteNonQuery();
                }
                catch
                {
                    throw;
                }
                finally
                {
                    conn.Close();
                }
            }
        }

        public static void DeletePosition(int id)
        {
            using (cmd = Conn.CreateCommand())
            {
                conn.Open();
                try
                {
                    cmd.CommandText = "DELETE FROM [Position] WHERE [idPosition]=?";
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("[idPosition]", id);
                    cmd.ExecuteNonQuery();
                }
                catch
                {
                    throw;
                }
                finally
                {
                    conn.Close();
                }
            }
        }
        #endregion Position

        #region Tasks
        public static Tasks SelectTask(int id)
        {
            Tasks result = null;
            DataTable dataTable = new DataTable();
            using (cmd = Conn.CreateCommand())
            {
                Conn.Open();
                try
                {
                    cmd.CommandText = "Select [Tasks].[idTask], [Tasks].* FROM [Tasks] WHERE [Tasks].[idTask] = ?";
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("[Tasks].[idTask]", id);
                    dataAdapter = new OdbcDataAdapter(cmd);
                    dataAdapter.Fill(dataTable); ;
                    dataAdapter.Dispose();
                    if (dataTable.Rows.Count > 0)
                    {
                        result = Tasks.Map(dataTable.Rows[0]);
                    }
                }
                catch
                {
                    throw;
                }
                finally
                {
                    conn.Close();
                }
            }
            return result;
        }
        public static List<Tasks> SelectTasks()
        {
            List<Tasks> result = new List<Tasks>();
            DataTable dataTable = new DataTable();
            using (cmd = Conn.CreateCommand())
            {
                Conn.Open();
                try
                {
                    cmd.CommandText =
                    "SELECT Tasks.* FROM Tasks";
                    dataAdapter = new OdbcDataAdapter(cmd);
                    dataAdapter.Fill(dataTable);
                    dataAdapter.Dispose();
                }
                catch
                {
                    throw;
                }
                finally
                {
                    conn.Close();
                }
                int i = 1;// счетчик строк в таблице
                foreach (DataRow row in dataTable.Rows)
                {
                    result.Add(Tasks.Map(row, i));
                    i++;
                }
            }
            return result;
        }

        public static int InsertTask(Tasks entity)
        {
            int result = 0;
            using (cmd = Conn.CreateCommand())
            {
                conn.Open();
                try
                {
                    cmd.CommandText = "INSERT INTO [Tasks] ([NameTask]) VALUES (?)";
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("[NameTask]", entity.NameTask);
                    cmd.ExecuteNonQuery();
                    cmd.CommandText = "SELECT @@IDENTITY";
                    object o = cmd.ExecuteScalar();
                    if (o != null)
                    {
                        result = int.Parse(o.ToString());
                    }
                }
                catch
                {
                    throw;
                }
                finally
                {
                    conn.Close();
                }
            }
            return result;
        }

        public static void UpdateTask(Tasks entity)
        {
            using (cmd = Conn.CreateCommand())
            {
                conn.Open();
                try
                {
                    cmd.CommandText = "UPDATE [Tasks] SET [NameTask]=? WHERE [Tasks].[idTask]";
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("[NameTask]", entity.NameTask);
                    cmd.Parameters.AddWithValue("[idTask]", entity.idTask);
                    cmd.ExecuteNonQuery();
                }
                catch
                {
                    throw;
                }
                finally
                {
                    conn.Close();
                }
            }
        }

        public static void DeleteTask(int id)
        {
            using (cmd = Conn.CreateCommand())
            {
                conn.Open();
                try
                {
                    cmd.CommandText = "DELETE FROM [Tasks] WHERE [idTask]=?";
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("[idTask]", id);
                    cmd.ExecuteNonQuery();
                }
                catch
                {
                    throw;
                }
                finally
                {
                    conn.Close();
                }
            }
        }
        #endregion Tasks

        #region TasksUsers
        public static TasksUsers SelectTaskUser(int id)
        {
            TasksUsers result = null;
            DataTable dataTable = new DataTable();
            using (cmd = Conn.CreateCommand())
            {
                Conn.Open();
                try
                {
                    cmd.CommandText = "Select [TasksUsers].[IdUserTask], [TasksUsers].* FROM [TasksUsers] WHERE [TasksUsers].[IdUserTask] = ?";
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("[TasksUsers].[IdUserTask]", id);
                    dataAdapter = new OdbcDataAdapter(cmd);
                    dataAdapter.Fill(dataTable); ;
                    dataAdapter.Dispose();
                    if (dataTable.Rows.Count > 0)
                    {
                        result = TasksUsers.Map(dataTable.Rows[0]);
                    }
                }
                catch
                {
                    throw;
                }
                finally
                {
                    conn.Close();
                }
            }
            return result;
        }
        public static List<TasksUsers> SelectTasksUserss()
        {
            List<TasksUsers> result = new List<TasksUsers>();
            DataTable dataTable = new DataTable();
            using (cmd = Conn.CreateCommand())
            {
                Conn.Open();
                try
                {
                    cmd.CommandText =
                    "SELECT TasksUsers.* FROM TasksUsers";
                    dataAdapter = new OdbcDataAdapter(cmd);
                    dataAdapter.Fill(dataTable);
                    dataAdapter.Dispose();
                }
                catch
                {
                    throw;
                }
                finally
                {
                    conn.Close();
                }
                int i = 1;// счетчик строк в таблице
                foreach (DataRow row in dataTable.Rows)
                {
                    result.Add(TasksUsers.Map(row, i));
                    i++;
                }
            }
            return result;
        }

        public static int InsertTaskUser(TasksUsers entity)
        {
            int result = 0;
            using (cmd = Conn.CreateCommand())
            {
                conn.Open();
                try
                {
                    cmd.CommandText = "INSERT INTO [TasksUsers] ([IdTask],[IdUser]) VALUES (?,?)";
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("[IdTask]", entity.IdTask);
                    cmd.Parameters.AddWithValue("[IdUser]", entity.IdUser);
                    cmd.ExecuteNonQuery();
                    cmd.CommandText = "SELECT @@IDENTITY";
                    object o = cmd.ExecuteScalar();
                    if (o != null)
                    {
                        result = int.Parse(o.ToString());
                    }
                }
                catch
                {
                    throw;
                }
                finally
                {
                    conn.Close();
                }
            }
            return result;
        }

        public static void UpdateTaskUser(TasksUsers entity)
        {
            using (cmd = Conn.CreateCommand())
            {
                conn.Open();
                try
                {
                    cmd.CommandText = "UPDATE [TasksUsers] SET [IdTask]=?, [IdUser]=? WHERE [TasksUsers].[IdUserTask]";
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("[IdTask]", entity.IdTask);
                    cmd.Parameters.AddWithValue("[IdUser]", entity.IdUser);
                    cmd.Parameters.AddWithValue("[IdUserTask]", entity.IdUserTask);
                    cmd.ExecuteNonQuery();
                }
                catch
                {
                    throw;
                }
                finally
                {
                    conn.Close();
                }
            }
        }

        public static void DeleteTaskUser(int id)
        {
            using (cmd = Conn.CreateCommand())
            {
                conn.Open();
                try
                {
                    cmd.CommandText = "DELETE FROM [TasksUsers] WHERE [IdUserTask]=?";
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("[IdUserTask]", id);
                    cmd.ExecuteNonQuery();
                }
                catch
                {
                    throw;
                }
                finally
                {
                    conn.Close();
                }
            }
        }
        #endregion TasksUsers
    }
}