using System.Collections.Generic;
using System.IO;
using System;
using E_PlayersProjeto.Interfaces;

namespace E_PlayersProjeto.Models
{
    public class Noticias : EPlayersBase , INoticias
    {
        public int IdNoticia { get; set; }
        public string Titulo { get; set; }
        public string Texto { get; set; }
        public string Imagem { get; set; }

        private const string  PATH = "Database/Noticias.csv";
        /// <summary>
        /// Método construtor para Criar a pasta/arquivo
        /// </summary>
        public Noticias()
        {
            CreateFolderAndFile(PATH);
        }
        /// <summary>
        /// Criar noticia
        /// </summary>
        /// <param name="n">n</param>
        public void Create(Noticias n)
        {
            string[] linha = { PrepararLinha(n) };
            File.AppendAllLines(PATH, linha);
        }
        /// <summary>
        /// ler e adicionar todas as linhas
        /// </summary>
        /// <returns>1;Titulo;Texto;Imagem</returns>
        public List<Noticias> ReadAll()
        {
            List<Noticias> noticias = new List<Noticias>();
            string[] linhas = File.ReadAllLines(PATH);
            foreach (var item in linhas)
            {
                string[] linha = item.Split(";");
                Noticias n = new Noticias();
                n.IdNoticia = Int32.Parse(linha[0]);
                n.Titulo = linha[1];
                n.Texto = linha[2];
                n.Imagem = linha[3];

                noticias.Add(n);
            }
            return noticias;
        }
        /// <summary>
        /// Atualizar linhas
        /// </summary>
        /// <param name="n">n</param>
        public void Update(Noticias n)
        {
            List<String> linhas = ReadAllLinesCSV(PATH);
            // 2;FLA;flamengo.png
            linhas.RemoveAll(y => y.Split(";")[0] == n.IdNoticia.ToString() );
            linhas.Add( PrepararLinha(n) );
            RewriteCSV(PATH, linhas);
        }
        /// <summary>
        /// Deletar noticia
        /// </summary>
        /// <param name="IdNoticia">IdNOTICIA</param>
        public void Delete(int IdNoticia)
        {
             List<String> linhas = ReadAllLinesCSV(PATH);
            // 2;FLA;flamengo.png
            linhas.RemoveAll(y => y.Split(";")[0] == IdNoticia.ToString() );
            RewriteCSV(PATH, linhas);
        }
        /// <summary>
        /// Preparar linha do cs
        /// </summary>
        /// <param name="n">N</param>
        /// <returns>IdNoticia;Titulo;Texto;Imagem</returns>
         private string PrepararLinha(Noticias n){
            return $"{n.IdNoticia};{n.Titulo};{n.Texto};{n.Imagem}";
        }
    }
}