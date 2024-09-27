using Microsoft.AspNetCore.Mvc;

public class ConcertsController : Controller
{
    private Manager _manager = new Manager();

    public IActionResult Index()
    {
        var concerts = _manager.ConcertGetAll();
        return View(concerts);
    }

    public IActionResult Details(int id)
    {
        var concert = _manager.ConcertGetById(id);
        if (concert == null)
        {
            return NotFound();
        }
        return View(concert);
    }

    public IActionResult Create()
    {
        return View(new ConcertAddViewModel());
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create(ConcertAddViewModel newConcert)
    {
        if (!ModelState.IsValid)
        {
            return View(newConcert);
        }

        var addedConcert = _manager.ConcertAdd(newConcert);
        return RedirectToAction(nameof(Details), new { id = addedConcert.ConcertId });
    }

    public IActionResult Edit(int id)
    {
        var concert = _manager.ConcertGetById(id);
        if (concert == null)
        {
            return NotFound();
        }

        var editForm = new ConcertEditViewModel
        {
            ConcertId = concert.ConcertId,
            Name = concert.Name,
            ConcertDate = concert.ConcertDate,
            Address = concert.Address,
            City = concert.City
        };

        return View(editForm);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Edit(ConcertEditViewModel concertToEdit)
    {
        if (!ModelState.IsValid)
        {
            return View(concertToEdit);
        }

        var editedConcert = _manager.ConcertEdit(concertToEdit);
        return RedirectToAction(nameof(Details), new { id = editedConcert.ConcertId });
    }

    public IActionResult Delete(int id)
    {
        var concert = _manager.ConcertGetById(id);
        if (concert == null)
        {
            return NotFound();
        }

        return View(concert);
    }

    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public IActionResult DeleteConfirmed(int id)
    {
        var success = _manager.ConcertDelete(id);
        if (!success)
        {
            return NotFound();
        }

        return RedirectToAction(nameof(Index));
    }
}
