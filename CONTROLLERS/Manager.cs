using System.Collections.Generic;
using System.Linq;

public class Manager
{
    private List<Concert> _concerts = new List<Concert>();

    public Manager()
    {
        // Example initial data for concerts
        _concerts.Add(new Concert { ConcertId = 1, Name = "Rock Concert", ConcertDate = DateTime.Now.AddDays(10), Address = "123 Main St", City = "New York" });
        _concerts.Add(new Concert { ConcertId = 2, Name = "Jazz Festival", ConcertDate = DateTime.Now.AddDays(20), Address = "456 Park Ave", City = "Chicago" });
    }

    // Get all concerts
    public IEnumerable<ConcertBaseViewModel> ConcertGetAll()
    {
        return _concerts.Select(c => new ConcertBaseViewModel
        {
            ConcertId = c.ConcertId,
            Name = c.Name,
            ConcertDate = c.ConcertDate,
            Address = c.Address,
            City = c.City
        });
    }

    // Get one concert by ID
    public ConcertBaseViewModel ConcertGetById(int id)
    {
        var concert = _concerts.FirstOrDefault(c => c.ConcertId == id);
        if (concert == null) return null;
        return new ConcertBaseViewModel
        {
            ConcertId = concert.ConcertId,
            Name = concert.Name,
            ConcertDate = concert.ConcertDate,
            Address = concert.Address,
            City = concert.City
        };
    }

    // Add a new concert
    public ConcertBaseViewModel ConcertAdd(ConcertAddViewModel newConcert)
    {
        var concert = new Concert
        {
            ConcertId = _concerts.Count + 1,
            Name = newConcert.Name,
            ConcertDate = newConcert.ConcertDate,
            Address = newConcert.Address,
            City = newConcert.City
        };
        _concerts.Add(concert);
        return new ConcertBaseViewModel
        {
            ConcertId = concert.ConcertId,
            Name = concert.Name,
            ConcertDate = concert.ConcertDate,
            Address = concert.Address,
            City = concert.City
        };
    }

    // Edit an existing concert
    public ConcertBaseViewModel ConcertEdit(ConcertEditViewModel concertToEdit)
    {
        var concert = _concerts.FirstOrDefault(c => c.ConcertId == concertToEdit.ConcertId);
        if (concert == null) return null;

        concert.Name = concertToEdit.Name;
        concert.ConcertDate = concertToEdit.ConcertDate;
        concert.Address = concertToEdit.Address;
        concert.City = concertToEdit.City;

        return new ConcertBaseViewModel
        {
            ConcertId = concert.ConcertId,
            Name = concert.Name,
            ConcertDate = concert.ConcertDate,
            Address = concert.Address,
            City = concert.City
        };
    }

    // Delete a concert
    public bool ConcertDelete(int id)
    {
        var concert = _concerts.FirstOrDefault(c => c.ConcertId == id);
        if (concert == null) return false;
        _concerts.Remove(concert);
        return true;
    }
}
