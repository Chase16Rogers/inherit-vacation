using System;
using System.Collections.Generic;
using System.Data;
using Dapper;
using Ivacation.Models;

namespace Ivacation.Repositories
{
  public class TripRepository
  {
      public readonly IDbConnection _db;

    public TripRepository(IDbConnection db)
    {
      _db = db;
    }
    internal IEnumerable<Trip> GetAll()
    {
      string sql = "SELECT * FROM trips;";
      return _db.Query<Trip>(sql);
    }

    internal Trip GetOne(string id)
    {
      string sql = "SELECT * FROM trips WHERE id = @id;";
      return _db.QueryFirstOrDefault<Trip>(sql, new { id });
    }

    internal Trip Create(Trip newTrip)
    {
      string sql = @"
      INSERT INTO trips (id, price, days, nights, destination, airport, hotel) VALUES (@id, @price, @days, @nights, @destination, @airport, @hotel)";
      _db.Execute(sql, newTrip);
      return newTrip;
    }

    internal Trip Edit(Trip editTrip)
    {
      string sql = @"
      UPDATE trips SET id = @id, price = @price, days = @days, nights = @nights, destination = @destination, airport = @airport, hotel = @hotel
      WHERE id = @id;";
      _db.Execute(sql, editTrip);
      return editTrip;
    }

    internal object Delete(string id)
    {
      string sql = "DELETE FROM trips WHERE id = @id LIMIT 1;";
      _db.Execute(sql, new { id });
      return "GONE BOSS";
    }
  }
}