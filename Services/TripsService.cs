using System;
using System.Collections.Generic;
using Ivacation.Models;
using Ivacation.Repositories;

namespace Ivacation.Services
{
  public class TripsService
  {
      private readonly TripRepository _tRepo;

    public TripsService(TripRepository tRepo)
    {
      _tRepo = tRepo;
    }

    internal IEnumerable<Trip> GetAll()
    {
      return _tRepo.GetAll();
    }

    internal Trip GetOne(string id)
    {
      Trip found = _tRepo.GetOne(id);
      if (found == null)
      {
          throw new Exception("BAD ID");
      }
      return found;
    }

    internal Trip Create(Trip newTrip)
    {
      return _tRepo.Create(newTrip);
    }

    internal Trip Edit(string id, Trip editTrip)
    {
      Trip found = GetOne(id);
       if (found == null)
      {
          throw new Exception("BAD ID");
      }
      editTrip.id = found.id;
      return _tRepo.Edit(editTrip);
    }

    internal object Delete(string id)
    {
      Trip found = GetOne(id);
       if (found == null)
      {
          throw new Exception("BAD ID");
      }
      return _tRepo.Delete(id);
    }
  }
}