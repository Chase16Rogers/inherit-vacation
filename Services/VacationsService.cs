using System;
using System.Collections.Generic;
using Ivacation.Models;
using Ivacation.Repositories;

namespace Ivacation.Services
{
  public class VacationsService
  {
      private readonly VacationRepository _vRepo;
    public VacationsService(VacationRepository vRepo)
    {
      _vRepo = vRepo;
    }

    internal IEnumerable<Vacation> GetAll()
    {
        return _vRepo.GetAll();
    }

    internal Vacation GetOne(string id)
    {
      Vacation found = _vRepo.GetOne(id);
      if (found == null)
      {
          throw new Exception("Bad Id buddy.");
      }
      return found;
    }
  }
}