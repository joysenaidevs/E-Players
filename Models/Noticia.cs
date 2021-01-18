using System.Collections.Generic;
using System.IO;
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
        

        //primeiro criamos o Metodo construtor PREPARE
        private string Prepare(Noticia e)
        {
            return $"{e.IdNoticia}; {e.Imagem}; {e.Texto}; {e.Titulo}";
        }
        public void Create(Noticia e)
        {
            string[] linha  = { Prepare(e) };
            File.AppendAllLines(PATH, linha);
        }


        public void Delete(int id)
        {
            List <string> linhas = ReadAllLinesCSV(PATH);
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