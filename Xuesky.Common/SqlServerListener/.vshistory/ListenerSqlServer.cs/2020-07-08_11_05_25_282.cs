using System;
using System.Data;
using System.Data.SqlClient;

namespace Xuesky.Common.SqlServerListener
{
    public class ListenerSqlServer
    {
        static string sqlConnection = "Data Source=132.232.11.181;Initial Catalog=CMSSMSDB;Persist Security Info=True;User ID=sa;Password=x320320x_0092;MultipleActiveResultSets=True";
        public ListenerSqlServer()
        {
            SqlDependency.Start(sqlConnection); //传入连接字符串,启动基于数据库的监听
            UpdateGrid();
            //SqlDependency.Stop(sqlConnection);//退出的时候程序结束数据库的监听
        }
        private static void UpdateGrid()
        {
            using (SqlConnection connection = new SqlConnection(sqlConnection))
            {
                connection.Open();
                //依赖是基于某一张表的,而且查询语句只能是简单查询语句,不能带top或*,同时必须指定所有者,即类似[dbo].[]
                using (SqlCommand command = new SqlCommand("SELECT [Send_ID],[Type_ID],[Mobile_SendState] FROM [dbo].[T_SendMobile]", connection))
                {
                    command.CommandType = CommandType.Text;
                    //connection.Open();
                    SqlDependency dependency = new SqlDependency(command);
                    dependency.OnChange += new OnChangeEventHandler(dependency_OnChange);
                    using (SqlDataReader sdr = command.ExecuteReader())
                    {
                        while (sdr.Read())
                        {
                            Console.WriteLine($"AssyAcc:{sdr["Send_ID"].ToString()}\tSnum:{sdr["Type_ID"].ToString()}\t发送状态:{sdr["Mobile_SendState"].ToString()}");
                        }
                    }
                }
            }
        }

        private static void dependency_OnChange(object sender, SqlNotificationEventArgs e)
        {
            if (e.Type == SqlNotificationType.Change) //只有数据发生变化时,才重新获取并数据
            {
                UpdateGrid();
            }
        }

    }
}
