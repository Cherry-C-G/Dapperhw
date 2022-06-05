using Dapper;
using DapperTutorial.Core.Entities;
using DapperTutorial.Core.Interfaces;
using DapperTutorial.Infrastructure.Data;
using System.Data;

namespace DapperTutorial.Infrastructure.Repositories
{
    public class DepartmentRepository : IRepository<Department>
    {
        DapperDbContext dbContext;

        public DepartmentRepository()
        {
            dbContext = new DapperDbContext();
        }
        public int DeleteById(int id)
        {
            IDbConnection conn = dbContext.GetConnection();
            return conn.Execute("Delete From Department Where Id = @Id", new {Id = id});
        }

        public IEnumerable<Department> GetAll()
        {

            IDbConnection conn = dbContext.GetConnection();
            return conn.Query<Department>("Select Id, DName, Loc From Department");
        }

        public Department GetById(int id)
        {
            IDbConnection conn = dbContext.GetConnection();
            return conn.QuerySingleOrDefault<Department>("Select Id, DName, Loc From Department Where id = @Id", 
                new {Id = id});
        }

        public int Insert(Department obj)
        {

            IDbConnection conn = dbContext.GetConnection();
            return conn.Execute("Insert Into Department Values(@DName, @Loc)", obj);
           
        }

        public int Update(Department obj)
        {
            IDbConnection conn = dbContext.GetConnection();
            return conn.Execute("Update Department Set DName = @DName, Loc = @Loc Where id = @Id", obj);
        }
    }
}
