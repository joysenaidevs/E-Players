using System.Collections.Generic;
using System.IO;

namespace E_Players.Models
{
    public class EplayersBase
    {
        public void CreateFolderAndFiler (string _path)
        {
            //Database/equipe.csv
            string folder   = _path.Split("/")[0];
                   
            if (!Directory.Exists(folder))
            {
                Directory.CreateDirectory(folder);
            }

            if (!File.Exists(_path))
            {
                //Ele vai criar o arquivo, passando o caminho
                File.Create(_path);
            }
        }

        public List<string> ReadAllLinesCSV(string path)
        {
            //Criar uma lista de string, retorno
            List<string> linhas = new List<string>();

            //Vamos ler o csv utilizando novo método
            //Utilizamos uma biblioteca para abrir e fechar o arquivo automaticamente
            //Utilizamos a diretiva:

            //StreamReader = Ler dados de um Arquivo - SOMENTE PARA MANIPULAR ARQUIVOS
            using(StreamReader file = new StreamReader(path)) // Criando o objeto, dizendo o leitor vai se chamar file
            {
                string linha;

                //Percorrer as linhas com um laço while

                while ( (linha = file.ReadLine()) != null)
                {
                    linhas.Add(linha);
                }
            }


            return linhas;
        }

        //Criamos um método para Reler
        public void RewriteCSV(string path, List<string> linhas)
        {

            //StremWriter = Escrever dados em um arquivo - SOMENTE PARA MANIPULAR ARQUIVOS

            using(StreamWriter output = new StreamWriter(path))
            {
                foreach (var item in linhas)
                {
                    //chamar meu objeto criado : output

                    output.Write(item + "\n"); //nao esquecer
                }
            }

        }
        
        
    }
}