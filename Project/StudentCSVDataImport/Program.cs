using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentCSVDataImport
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using (SqlConnection objconn = new SqlConnection())

            {
                objconn.ConnectionString = @"server=LPTIN-59TD453;Database=ImportDB;integrated security=true";
                objconn.Open();

                int linenum = 0;
                using (StreamReader reader = new StreamReader(@"C:\Users\RajiyabegamBetageri\OneDrive - Anthology Inc\Desktop\Importdata.csv"))
                {
                    while (!reader.EndOfStream)
                    {
                        string line = reader.ReadLine();
                        if (linenum != 0)
                        {
                            var values = line.Split('|');
                            SqlCommand cmd = new SqlCommand();
                            cmd.CommandText = "Insert into ImportDB.dbo.StudentData1 Values('" + values[0] + "','" + values[1] + "','" + values[2] + "','" + values[3] + "','" + values[4] + "','" + values[5] + "','" + values[6] + "','" + values[7] + "','" + values[8] + "','" + values[9] + "')"; ;
                            cmd.CommandType = System.Data.CommandType.Text;
                            cmd.Connection = objconn;
                            cmd.ExecuteNonQuery();
                        }
                        linenum++;
                    }
                }
                objconn.Close();
            
            }
            Console.WriteLine("Data imported successfull!!!");
        }
    }
}
