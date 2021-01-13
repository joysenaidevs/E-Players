using System;
using System.Collections.Generic;
using System.IO;
using E_Players;
using E_Players.Interfaces;

namespace E_Players.Models
{
    public class Equipe : EplayersBase , IEquipe
    {
        public int IdEquipe { get; set; }
        
        public string Nome { get; set; }

        public string Imagem { get; set; }

        private const string PATH = "Database/Equipe.csv";

        //Metodo construtor de Equipe
        public Equipe(){
            CreateFolderAndFiler(PATH);
        }

        //Criamos o Método para preparar a linha do csv

        public string Prepare(Equipe e)
        {
            return $"{e.IdEquipe}; {e.Nome}; {e.Imagem}";
        }

        public void Create(Equipe e)
        {
            //Para criar o elemento preciso do método FILE
            
            //Preparamos um array de string para o método AppendAllLines
            string[] linhas = { Prepare(e) };

            //Acrescentar todas as linhas: AppendAllLines
            File.AppendAllLines(PATH, linhas );
        }

        public void Delete(int id)
        {
            //Linhas lidas
           List<string> linhas = ReadAllLinesCSV(PATH);

           //Remover
                                                                //transformar em string
           linhas.RemoveAll( x => x.Split(";")[0] == id.ToString() ); //consigo colocar uma expressao lambida

        
            //Reecreve o CSV com a lista alterada
            RewriteCSV(PATH, linhas); // passar a lista co
        }

        public List<Equipe> ReadAll()
        {
            List<Equipe> equipes = new List<Equipe>();

            //Ler as linhas com o método ReadAllLines
            //TODAS AS LINHAS DO CSV
            string[] linhas = File.ReadAllLines(PATH);

            foreach (string item in linhas)
            {
                //Imaginar um csv: 1;VivoKeyd;vivo.jpg

                string[] linha = item.Split(";");

                Equipe novaEquipe = new Equipe();
                novaEquipe.IdEquipe = Int32.Parse( linha[0] ); 
                novaEquipe.Nome = linha [1];
                novaEquipe.Imagem = linha [2];

                equipes.Add(novaEquipe);
            }

            return equipes;
        }

        public void Update(Equipe e)
        {
          //Ler todas as linhas do csv
          //Remover linha que tiver ID
          //Adicionar a linha alterada

           
          //Linhas lidas
           List<string> linhas = ReadAllLinesCSV(PATH);

           //Remover
                                                                //transformar em string
           linhas.RemoveAll( x => x.Split(";")[0] == e.IdEquipe.ToString() ); //consigo colocar uma expressao lambida


            //Chamar o arquivo - Adicionar Linha

           //Adicionamos na lsita a equipe alterada
            linhas.Add( Prepare(e) );

            //Reecreve o CSV com a lista alterada
            RewriteCSV(PATH, linhas); // passar a lista com elementos alterado
        }
    }
}