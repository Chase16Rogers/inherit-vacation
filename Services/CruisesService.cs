using System;
using System.Collections.Generic;
using Ivacation.Models;
using Ivacation.Repositories;

namespace Ivacation.Services
{
  public class CruisesService
  {
      private readonly CruiseRepository _cRepo;

    public CruisesService(CruiseRepository cRepo)
    {
      _cRepo = cRepo;
    }

    internal IEnumerable<Cruise> GetAll()
    {
      return _cRepo.GetAll();
    }

    internal Cruise GetOne(string id)
    {
      Cruise found = _cRepo.GetOne(id);
      if(found == null)
      {
          throw new Exception("Bad Id bossman");
      }
      return found;
    }

    internal Cruise Create(Cruise newCruise)
    {
      return _cRepo.Create(newCruise);
    }

    internal Cruise Edit(string id, Cruise editCruise)
    {
      Cruise found = GetOne(id);
      if(found == null)
      {
          throw new Exception("Bad Id bossman");
      }
      editCruise.id = found.id;
      return _cRepo.Edit(editCruise);
    }

    internal string Delete(string id)
    {
      Cruise found = GetOne(id);
      if(found == null)
      {
          throw new Exception("Bad Id bossman");
      }
      return _cRepo.Delete(id);
    }
  }
}