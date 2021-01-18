using System.Collections.Generic;
using E_Players.Interfaces_2;

namespace E_Players.Models
{
    public class Noticia :  EplayersBase, INoticia
    {
        public int IdNoticia  { get; set; }

        public string Titulo { get; set; }
        
        public string Texto { get; set; }
        
        public string Imagem { get; set; }

        private const string PATH = "Database/noticia.cvs";

        public Noticia()
        {
            CreateFolderAndFiler(PATH);
        }

        public void Create(Noticia e)
        {
            string[] linha  = { Prepare(e) };
            File.AppendAllLines(PATH, linha);
        }

        private string Prepare(Noticia e)
        {
            return $"{e.IdNoticia}; {e.Imagem}; {e.Texto}; {e.Titulo}";
        }

        public void Delete(int id)
        {
            throw new System.NotImplementedException();
        }

        public List<Equipe> ReadAll()
        {
            throw new System.NotImplementedException();
        }

        public void Update(Noticia e)
        {
            throw new System.NotImplementedException();
        }
    }
}