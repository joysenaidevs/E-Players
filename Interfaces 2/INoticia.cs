using System.Collections.Generic;
using E_Players.Models;

namespace E_Players.Interfaces_2
{
    public interface INoticia
    {
        void Create(Equipe e);
        List<Equipe> ReadAll();
        void Update(Equipe e);
        void Delete(int id);
    }
}