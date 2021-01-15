using System.Collections.Generic;
using System.IO;
using E_Players.Interfaces_3;

namespace E_Players.Models
{
    public class Jogador : EplayersBase, IJogador
    {
        public int IdJogador { get; set; }
        
        public string Nome { get; set; }
        
        public string IdEquipe { get; set; }

        //login
        public string Email { get; set; }
        public string Senha { get; set; }

        // Criar método construtor para gerar arquivo

        private const string PATH = "Database/Jogador.cvs";
        
         

        //METODO CONSTRUTOR
        public Jogador()
        {
            CreateFolderAndFiler(PATH);
        }

        //Prepara a linha para a estrutura objeto jogador
        //Retorna a linha em formato de .csv
        private string PrepararLinha(Jogador j)
        {
            return $"{j.IdJogador}; {j.Nome}; {j.Email}; {j.Senha}";
        }

        public void Create(Jogador j)
        {
            string [] linha = { PrepararLinha(j) };
            File.AppendAllLines(PATH, linha);
        }

        public List<Jogador> ReadAll()
        {
            //Vamos retorna a lista de jogadores
            //ler todas as linhas do csv
            List<Jogador> jogadores = new List<Jogador>();
            string [] linhas = File.ReadAllLines(PATH);

            foreach (var item in linhas)
            {
                string [] linha = item.Split(";");

                Jogador jogador = new Jogador();
                jogador.IdJogador = int.Parse(linha[0]);
                jogador.Nome = linha [1];
                jogador.Email = linha [2];
                jogador.Senha = linha [3];

                jogadores.Add(jogador);


            }

            return jogadores;
        }

        public void Uptade(Jogador j)
        {
            //Alterar
            List<string> linhas = ReadAllLinesCSV(PATH);
            linhas.RemoveAll(x => x.Split(";")[0] == j.IdJogador.ToString() );
            linhas.Add(PrepararLinha(j) );
            RewriteCSV(PATH, linhas);
        }

        public void Delete(int id)
        {
            List<string> linhas =  ReadAllLinesCSV(PATH);
            //O que vai retornar no csv
            // 1;FLA;fla.png
            linhas.RemoveAll(x => x.Split(";")[0] == IdJogador.ToString() );
            RewriteCSV(PATH, linhas);
        }
    }
}