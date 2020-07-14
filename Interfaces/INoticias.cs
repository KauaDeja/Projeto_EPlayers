using System.Collections.Generic;
using E_PlayersProjeto.Models;

namespace E_PlayersProjeto.Models
{
    public interface INoticias
    {
         /// <summary>
        /// Criar (Iterface)
        /// </summary>
        /// <param name="e"></param>  
         void Create(Noticias n);
          /// <summary>
         /// LerTudo interface
         /// </summary>
         /// <returns>Lertodas as linhas que serão retornadas</returns>
         List<Noticias> ReadAll();
           /// <summary>
        /// Atualizar interface
        /// </summary>
        /// <param name="e"></param>
         void Update(Noticias n);
           /// <summary>
        /// Deletar interface
        /// </summary>
        /// <param name="IdEquipe"></param>

         void Delete(int IdNoticia);


    }
}