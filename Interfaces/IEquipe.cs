namespace E_Players.Interfaces
{
    public class IEquipe
    {
        void Create(Equipe e);

        List<Equipe> ReadAll(); 

        void Update(Equipe e);

        void Delete(int id);


    }
}