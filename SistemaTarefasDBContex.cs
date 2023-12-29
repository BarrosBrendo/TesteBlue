using Microsoft.EntityFrameworkCore;

public class SitemaTarefasDBContex : DbContext
{
    public SitemaTarefasDBContex(DbContextOptions<SistemaTarefasDBContex> options)
        : base(options)
    {
    }

    public DbSet<UsuarioModel> Usuarios { get; set; }


}
