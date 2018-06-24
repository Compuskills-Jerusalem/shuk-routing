using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Shuk_Routing
{
    class Program
    {
        static void Main(string[] args)
        {
            string conn_string = "data source = mi3-wsq2.a2hosting.com/; database = compuski_shuk_routing; Uid=compuski_shuk_routing_user; Pwd = compuskills-2018-mens-programming; ";

            using (SqlConnection conn = new SqlConnection(conn_string))
            {
                string create_commodities_table = "CREATE TABLE Commodities(Commodity_ID INT NOT NULL PRIMARY KEY IDENTITY(1, 1), CommodityName NVARCHAR(30) NOT NULL,);";
                string create_stalls_table = "CREATE TABLE Stalls(Stall_ID INT NOT NULL PRIMARY KEY IDENTITY(1, 1), StallName NVARCHAR(50) NOT NULL, FirstCoord INT, SecondCoord INT,); ";
                string create_commodities_stalls_table = "CREATE TABLE CommoditiesStalls(Commodities_Stalls_ID INT NOT NULL PRIMARY KEY IDENTITY(1, 1), CommoditiesID INT NOT NULL FOREIGN KEY REFERENCES Commodities(Commodity_ID), StallsID INT NOT NULL FOREIGN KEY REFERENCES Stalls(Stall_ID), Price SMALLMONEY NOT NULL CHECK(Price > 0), Rating INT CHECK(Rating >= 1 AND Rating <= 5), TimeRegistered DateTime NOT NULL DEFAULT(SYSDATETIME()), Notes NVARCHAR(140));";
                string insert_commodities = "INSERT INTO Commodities (CommodityName) VALUES('Grapes'), ('Bananas'), ('French Rolls');";
                string insert_stalls = "INSERT INTO Stalls(StallName, FirstCoord, SecondCoord) Values ('Chaim''s Stall', 32, 40), ('Roland''s Rolls', 50, 19), ('Shabbos Treats', 12, 31);";
                string insert_joined_data = "INSERT INTO CommoditiesStalls (CommoditiesID, StallsID, Price) VALUES (1, 3, 21.34), (3, 2, 12.12), (2, 1, 5.67);";

                SqlCommand cmd1 = new SqlCommand(create_commodities_table);
                SqlCommand cmd2 = new SqlCommand(create_stalls_table);
                SqlCommand cmd3 = new SqlCommand(create_commodities_stalls_table);
                SqlCommand cmd4 = new SqlCommand(insert_commodities);
                SqlCommand cmd5 = new SqlCommand(insert_stalls);
                SqlCommand cmd6 = new SqlCommand(insert_joined_data);

                conn.Open();
                cmd1.ExecuteNonQuery();
                cmd2.ExecuteNonQuery();
                cmd3.ExecuteNonQuery();
                cmd4.ExecuteNonQuery();
                cmd5.ExecuteNonQuery();
                cmd6.ExecuteNonQuery();
            }
        }
    }
}
