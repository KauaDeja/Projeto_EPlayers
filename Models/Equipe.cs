using System;
using System.Collections.Generic;
using System.IO;
using E_PlayersProjeto.Models;
using E_PlayersProjeto.Interfaces;

namespace E_PlayersProjeto.Models 
{
    public class Equipe : EPlayersBase, IEquipe
    {
        public int IdEquipe { get; set; }
        public string Nome { get; set; }
        public string Imagem { get; set; }

        private const string PATH = "Database/equipe.csv";
        /// <summary>
        /// Método construtor para Criar a pasta/arquivo
        /// </summary>
        public Equipe()
        {
            CreateFolderAndFile(PATH);
        }
        /// <summary>
        /// Criar equipe
        /// </summary>
        /// <param name="e">e</param>
        public void Create(Equipe e)
        {
            string[] linha = { PrepararLinha(e) };
            File.AppendAllLines(PATH, linha);
        }
        /// <summary>
        /// Preparar as linhas do CSV
        /// </summary>
        /// <param name="e">E</param>
        /// <returns>IdEquipe;Nome;Imagem</returns>

        private string PrepararLinha(Equipe e){
            return $"{e.IdEquipe};{e.Nome};{e.Imagem}";
        }
        /// <summary>
        /// Ler todas as linhas 
        /// </summary>
        /// <returns>Linhas lidas e adicionadas</returns>

        public List<Equipe> ReadAll()
        {
            List<Equipe> equipes = new List<Equipe>();
            string[] linhas = File.ReadAllLines(PATH);
            foreach (var item in linhas)
            {
                string[] linha = item.Split(";");
                Equipe equipe = new Equipe();
                equipe.IdEquipe = Int32.Parse(linha[0]);
                equipe.Nome = linha[1];
                equipe.Imagem = linha[2];

                equipes.Add(equipe);
            }
            return equipes;
        }
        /// <summary>
        /// Atulizar novas equipes
        /// </summary>
        /// <param name="e">E</param>

        public void Update(Equipe e)
        {
            List<String> linhas = ReadAllLinesCSV(PATH);
            // 2;FLA;flamengo.png
            linhas.RemoveAll(y => y.Split(";")[0] == e.IdEquipe.ToString() );
            linhas.Add( PrepararLinha(e) );
            RewriteCSV(PATH, linhas);
        }
        /// <summary>
        /// Apagar equipes
        /// </summary>
        /// <param name="IdEquipe">IdEquipe</param>

        public void Delete(int IdEquipe)
        {
            List<String> linhas = ReadAllLinesCSV(PATH);
            // 2;FLA;flamengo.png
            linhas.RemoveAll(y => y.Split(";")[0] == IdEquipe.ToString() );
            RewriteCSV(PATH, linhas);
        }
    }
}