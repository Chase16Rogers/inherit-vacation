using System;
using System.Collections.Generic;
using System.Data;
using Dapper;
using Ivacation.Models;

namespace Ivacation.Repositories
{
  public class CruiseRepository
  {
      public readonly IDbConnection _db;

    public CruiseRepository(IDbConnection db)
    {
      _db = db;
    }

    internal IEnumerable<Cruise> GetAll()
    {
      string sql = "SELECT * FROM cruises;";
      return _db.Query<Cruise>(sql);
    }

    internal Cruise GetOne(string id)
    {
      string sql = "SELECT * FROM cruises WHERE id = @id;";
      return _db.QueryFirstOrDefault<Cruise>(sql, new { id });
    }

    internal Cruise Create(Cruise newCruise)
    {
      string sql = @"
      INSERT INTO cruises (id, price, days, nights, destination, port, boat) VALUES (@id, @price, @days, @nights, @destination, @port, @boat);";
      _db.Execute(sql, newCruise);
      return newCruise;
    }

    internal Cruise Edit(Cruise editCruise)
    {
      string sql = @"
      UPDATE cruises SET price = @price, days = @days, nights = @nights, destination = @destination, port = @port, boat = @boat
      WHERE id = @id;";
      _db.Execute(sql, editCruise);
      return editCruise;
    }

    internal string Delete(string id)
    {
      string sql = "DELETE FROM cruises WHERE id = @id LIMIT 1;";
      _db.Execute(sql, new { id });
      return "Gone boss";
    }
  }
}