using Ayra.Domain.Entities;
using Ayra.Infrastructure.Context;

public class CoordinateService
{
    private readonly ApplicationDbContext _context;

    public CoordinateService(ApplicationDbContext context)
    {
        _context = context;
    }

    public IEnumerable<Coordinate> GetAll() => _context.Coordinates.ToList();

    public Coordinate GetById(int id) => _context.Coordinates.Find(id);

    public Coordinate Create(Coordinate coordinate)
    {
        _context.Coordinates.Add(coordinate);
        _context.SaveChanges();
        return coordinate;
    }

    public bool Update(Coordinate coordinate)
    {
        var existing = _context.Coordinates.Find(coordinate.Id);
        if (existing == null) return false;

        _context.Entry(existing).CurrentValues.SetValues(coordinate);
        _context.SaveChanges();
        return true;
    }

    public bool Delete(int id)
    {
        var coordinate = _context.Coordinates.Find(id);
        if (coordinate == null) return false;

        _context.Coordinates.Remove(coordinate);
        _context.SaveChanges();
        return true;
    }
}