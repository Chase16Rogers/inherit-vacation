using System;
using System.Collections.Generic;
using System.Data;
using Dapper;
using Ivacation.Models;

namespace Ivacation.Repositories
{
  public class VacationRepository
  {
      public readonly IDbConnection _db;

    public VacationRepository(IDbConnection db)
    {
      _db = db;
    }

    internal IEnumerable<Vacation> GetAll()
    {
      string sql = "SELECT * FROM cruises, trips;";
      return _db.Query<Vacation>(sql);
    }

    internal Vacation GetOne(string id)
    {
      string sql = "SELECT * FROM cruises, trips WHERE id = @id;";
      return _db.QueryFirstOrDefault<Vacation>(sql, new { id });
    }
  }
}