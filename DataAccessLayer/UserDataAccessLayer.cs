using DataAccessLayer;
using Microsoft.EntityFrameworkCore;
using static DataAccessLayer.ApplicationUser;

public class UserDataAccessLayer 
{
    private readonly ApplicationDbContext _context;

    public UserDataAccessLayer(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<bool> RegisterUser(ApplicationUser user)
    {
        await _context.ApplicationUser.AddAsync(user);
        var result = await _context.SaveChangesAsync();
        return result > 0;
    }

    public async Task<ApplicationUser> LoginUser(string username, string password)
    {
        var user = await _context.ApplicationUser.FirstOrDefaultAsync(u => u.Username == username && u.Password == password);
        return user;
    }
}