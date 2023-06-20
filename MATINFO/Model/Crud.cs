// File:    Crud.cs
// Author:  nmege
// Created: vendredi 20 décembre 2013 09:15:09
// Purpose: Definition of Interface Crud

using System.Collections.ObjectModel;

namespace MATINFO.Model
{
    /// <summary>
    /// Interface définissant les opérations CRUD (Create, Read, Update, Delete) pour une entité.
    /// </summary>
    /// <typeparam name="T">Le type d'entité.</typeparam>
    public interface Crud<T>
    {
        /// <summary>
        /// Crée une nouvelle entité.
        /// </summary>
        void Create();

        /// <summary>
        /// Lit les détails de l'entité.
        /// </summary>
        void Read();

        /// <summary>
        /// Met à jour les informations de l'entité.
        /// </summary>
        void Update();

        /// <summary>
        /// Supprime l'entité.
        /// </summary>
        void Delete();

        /// <summary>
        /// Retourne toutes les entités existantes.
        /// </summary>
        /// <returns>Une collection observable contenant toutes les entités.</returns>
        ObservableCollection<T> FindAll();

        /// <summary>
        /// Recherche les entités en fonction des critères spécifiés.
        /// </summary>
        /// <param name="criteres">Les critères de recherche.</param>
        /// <returns>Une collection observable contenant les entités correspondantes aux critères de recherche.</returns>
        ObservableCollection<T> FindBySelection(string criteres);
    }
}
