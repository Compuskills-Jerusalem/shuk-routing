using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace shuk_routing
{
    class Build_Database
    {
        static void Main(string[] args)
        {
            string conn_string = "data source = mi3-wsq2.a2hosting.com; database = compuski_shuk_routing; Uid=compuski_shuk_routing_user; Pwd = compuskills-2018-mens-programming; ";

            using (SqlConnection conn = new SqlConnection(conn_string))
            {
                string drop_commodities_table = "DROP TABLE Commodities;";
                string drop_stalls_table = "DROP TABLE Stalls;";
                string drop_commodities_stalls_table = "DROP TABLE CommoditiesStalls;";

                string define_commodities_table = "CREATE dbo.TABLE Commodities(CommodityID INT NOT NULL PRIMARY KEY IDENTITY(1, 1), CommodityName NVARCHAR(30) NOT NULL);";
                string define_stalls_table = "CREATE TABLE dbo.Stalls(StallID INT NOT NULL PRIMARY KEY IDENTITY(1, 1), StallName NVARCHAR(50) NOT NULL, FirstCoord INT, SecondCoord INT); ";
                string define_commodities_stalls_table = "CREATE dbo.TABLE CommoditiesStalls(CommoditiesStallsID INT NOT NULL PRIMARY KEY IDENTITY(1, 1), CommoditiesID INT NOT NULL FOREIGN KEY REFERENCES Commodities(Commodity_ID), StallsID INT NOT NULL FOREIGN KEY REFERENCES Stalls(Stall_ID), Price SMALLMONEY NOT NULL CHECK(Price > 0), Rating INT CHECK(Rating >= 1 AND Rating <= 5), TimeRegistered DateTime NOT NULL DEFAULT(SYSDATETIME()), Notes NVARCHAR(140));";

                string data_for_commodities_table = "INSERT INTO Commodities (CommodityName) VALUES('Grapes'), ('Bananas'), ('French Rolls');";
                string data_for_stalls_table = "INSERT INTO Stalls(StallName, FirstCoord, SecondCoord) Values ('Chaim''s Stall', 32, 40), ('Roland''s Rolls', 50, 19), ('Shabbos Treats', 12, 31);";
                string data_for_comm_stalls_linking_table = "INSERT INTO CommoditiesStalls (CommoditiesID, StallsID, Price) VALUES (1, 3, 21.34), (3, 2, 12.12), (2, 1, 5.67);";

                SqlCommand dropping_commodities_table = new SqlCommand(drop_commodities_table, conn);
                SqlCommand dropping_stalls_table = new SqlCommand(drop_stalls_table, conn);
                SqlCommand dropping_commodities_stalls_table = new SqlCommand(drop_commodities_stalls_table, conn);

                SqlCommand make_commodities_table = new SqlCommand(define_commodities_table, conn);
                SqlCommand make_stalls_table = new SqlCommand(define_stalls_table, conn);
                SqlCommand make_comm_stalls_linking_table = new SqlCommand(define_commodities_stalls_table, conn);

                SqlCommand insert_into_commodities_table = new SqlCommand(data_for_commodities_table, conn);
                SqlCommand insert_into_stalls_table = new SqlCommand(data_for_stalls_table, conn);
                SqlCommand insert_into_comm_stalls_linking_table = new SqlCommand(data_for_comm_stalls_linking_table, conn);

                conn.Open();
                dropping_commodities_stalls_table.ExecuteNonQuery();
                dropping_stalls_table.ExecuteNonQuery();
                dropping_commodities_table.ExecuteNonQuery();
                make_commodities_table.ExecuteNonQuery();
                make_stalls_table.ExecuteNonQuery();
                make_comm_stalls_linking_table.ExecuteNonQuery();
                insert_into_commodities_table.ExecuteNonQuery();
                insert_into_stalls_table.ExecuteNonQuery();
                insert_into_comm_stalls_linking_table.ExecuteNonQuery();
            }
        }
    }
}