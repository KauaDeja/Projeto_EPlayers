using System.Collections.Generic;
using E_PlayersProjeto.Models;

namespace E_PlayersProjeto.Interfaces
{
    public interface IEquipe
    {
         /// <summary>
        /// Criar (Iterface)
        /// </summary>
        /// <param name="e"></param>   
         void Create(Equipe e);
         /// <summary>
         /// LerTudo interface
         /// </summary>
         /// <returns>Lertodas as linhas que serão retornadas</returns>
        List<Equipe> ReadAll();
        /// <summary>
        /// Atualizar interface
        /// </summary>
        /// <param name="e"></param>
        void Update(Equipe e);
        /// <summary>
        /// Deletar interface
        /// </summary>
        /// <param name="IdEquipe"></param>
        void Delete(int IdEquipe);
    }
}