using System.Linq;

namespace ja.training.csharp._05_Umkreissuche
{
    public interface IDbContext
    {
        IQueryable<Telefonzelle> Telefonzellen { get; set; }
    }
}
