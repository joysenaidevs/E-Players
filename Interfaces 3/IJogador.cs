using System.Collections.Generic;
using E_Players.Models;

namespace E_Players.Interfaces_3
{
    public interface IJogador
    {
        //CRIAR

        void Create(Jogador j );

        //LER - LISTAR
        List<Jogador> ReadAll();   

        //Alterar
        void Uptade(Jogador j);

        //Excluir
        void Delete(int id);

    }
}