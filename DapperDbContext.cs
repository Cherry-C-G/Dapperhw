using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DapperTutorial.Infrastructure.Data
{
    public class DapperDbContext
    {
        IDbConnection dbConnection;
        public DapperDbContext()
        {
            dbConnection = new SqlConnection("Data Source=.;Initial Catalog=sqlConnection;Integrated Security=True");
        }
        public IDbConnection GetConnection()
        {
            return dbConnection;
        }
    }
}
