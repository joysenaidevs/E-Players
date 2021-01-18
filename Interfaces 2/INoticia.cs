using System.Collections.Generic;
using E_Players.Models;

namespace E_Players.Interfaces_2
{
    public interface INoticia
    {
        void Create(Noticia e);
        List<Equipe> ReadAll();
        void Update(Noticia e);
        void Delete(int id);
    }
}