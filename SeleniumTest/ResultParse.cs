using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;

namespace SeleniumTest
{
    struct ResultParse
    {
        public int CountPeoples;
        public double Cof;
        public double AllMoney;
        public double WinMoney;
        public double LoseMoney;
        public void PrintResult()
        {
            Console.WriteLine("________________________");
            Console.WriteLine($"Коэфициент {Cof}");
            Console.WriteLine($"Количество ставок {CountPeoples}");
            Console.WriteLine($"Сумма ставок {AllMoney}");
            Console.WriteLine($"Сумма выйгрыша {WinMoney}");
            Console.WriteLine($"Сумма проигрыша {LoseMoney}");
        }
        private static void InsertResult(ResultParse str)
        {
            using (SQLiteConnection conn = new SQLiteConnection(@"Data source=C:\Users\Павел\source\repos\SeleniumTest\SeleniumTest\DbResuktParse.db; version=3;"))
            {
                string commandText = "insert into result values(@cof,@count_peoples,@allmoney,@win_money,@lose_money,@time,@date)";
                SQLiteCommand comm = new SQLiteCommand(commandText, conn);
                comm.Parameters.AddWithValue("@cof", str.Cof);
                comm.Parameters.AddWithValue("@count_peoples", str.CountPeoples);
                comm.Parameters.AddWithValue("@allmoney", str.AllMoney);
                comm.Parameters.AddWithValue("@win_money", str.WinMoney);
                comm.Parameters.AddWithValue("@lose_money", str.LoseMoney);
                comm.Parameters.AddWithValue("@time", DateTime.Now.ToShortTimeString());
                comm.Parameters.AddWithValue("@date", DateTime.Now.ToShortDateString());
                conn.Open();
                comm.ExecuteNonQuery();
                conn.Close();
            }
        }
    }

}
