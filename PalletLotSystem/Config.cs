using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace PalletLotSystem{
    public static class Config{

        public static string ConnectionString{

            get{
                string[] lines = File.ReadAllLines("dbConfig.ini");

                string server = "";
                string port = "";
                string database = "";
                string user = "";
                string password = "";

                foreach (string line in lines){
                    if (line.StartsWith("Server="))
                        server = line.Substring(7);

                    if (line.StartsWith("Port="))
                        port = line.Substring(5);

                    if (line.StartsWith("Database="))
                        database = line.Substring(9);

                    if (line.StartsWith("User="))
                        user = line.Substring(5);

                    if (line.StartsWith("Password="))
                        password = line.Substring(9);
                }

                return string.Format("server={0};user={1};password={2};database={3};port={4};", server, user, password, database, port);
            }
        }
    }
}
