using Ayra.Domain.Entities;
using Ayra.Infrastructure.Context;

public class UserService
{
    private readonly ApplicationDbContext _context;

    public UserService(ApplicationDbContext context)
    {
        _context = context;
    }

    public IEnumerable<User> GetAll()
    {
        return _context.Users.ToList();
    }

    public User GetById(int id)
    {
        return _context.Users.Find(id);
    }

    public User Create(User user)
    {
        _context.Users.Add(user);
        _context.SaveChanges();
        return user;
    }

    public bool Update(User user)
    {
        var existing = _context.Users.Find(user.Id);
        if (existing == null) return false;

        _context.Entry(existing).CurrentValues.SetValues(user);
        _context.SaveChanges();
        return true;
    }

    public bool Delete(int id)
    {
        var user = _context.Users.Find(id);
        if (user == null) return false;

        _context.Users.Remove(user);
        _context.SaveChanges();
        return true;
    }
}