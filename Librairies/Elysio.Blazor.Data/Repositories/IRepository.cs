using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Elysio.Blazor.Data.Repositories
{
    public interface IRepository<TEntity>
        where TEntity : class
    {
        /// <summary>
        /// Ajoute une entité
        /// </summary>
        /// <param name="entity">Entité à ajouter</param>
        void Add(TEntity entity);
        /// <summary>
        /// Ajoute une liste d'entités
        /// </summary>
        /// <param name="entities">Entités</param>
        void AddRange(IEnumerable<TEntity> entities);
        /// <summary>
        /// Mise à jour d'une entité
        /// </summary>
        /// <param name="entity">Entité</param>
        void Update(TEntity entity);
        /// <summary>
        /// Mise à jour d'une liste d'entités
        /// </summary>
        /// <param name="entities">Entités</param>
        void UpdateRange(IEnumerable<TEntity> entities);
        /// <summary>
        /// Suppression d'une entité
        /// </summary>
        /// <param name="entity">ENtité</param>
        void Delete(TEntity entity);
        /// <summary>
        /// Suppression d'une liste d'entités
        /// </summary>
        /// <param name="entities">Entités</param>
        void DeleteRange(IEnumerable<TEntity> entities);

        /// <summary>
        /// Demande la sauvegarde des opérations en attente
        /// </summary>
        /// <returns></returns>
        Task SaveAsync();
    }
}
