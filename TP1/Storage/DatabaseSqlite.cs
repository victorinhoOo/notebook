using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Storage
{
    /// <summary>
    /// Fournit des méthodes pour interagir avec une base de données SQLite.
    /// </summary>
    public class DatabaseSqlite
    {
        private SQLiteConnection connection;

        /// <summary>
        /// Initialise une nouvelle instance de la classe et ouvre la connexion à la base de données
        /// </summary>
        public DatabaseSqlite(string fileName)
        {
            connection = new SQLiteConnection(@"DataSource=" + fileName);
            connection.Open();
        }

        // <summary>
        /// Exécute une requête SQL qui retourne des résultats 
        /// </summary>
        /// <param name="req">requête SQL à exécuter</param>
        /// <returns>résultats de la requête.</returns>
        public SQLiteDataReader ExecuteQuery(string req)
        {
            using (var command = new SQLiteCommand(req, connection))
            {
                return command.ExecuteReader();
            }
        }

        /// <summary>
        /// Exécute une requête SQL qui ne retourne pas de résultats
        /// </summary>
        /// <param name="req">requête SQL à exécuter.</param>
        public void ExecuteNonQuery(string req)
        {
            using (var command = new SQLiteCommand(req, connection))
            {
                command.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// Exécute une commande SQL avec des paramètres, qui ne retourne pas de résultats.
        /// </summary>
        /// <param name="req">La requête SQL à exécuter.</param>
        /// <param name="param">paramètres SQL</param>
        public void ExecuteNonQuery(string req, SQLiteParameter[] param)
        {
            using (var command = new SQLiteCommand(req, connection))
            {
                command.Parameters.AddRange(param);
                command.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// Exécute une requête SQL avec des paramètres et retourne les résultats.
        /// </summary>
        /// <param name="req">requête SQL à exécuter.</param>
        /// <param name="param">paramètres SQL.</param>
        /// <returns>les résultats de la requête</returns>
        public SQLiteDataReader ExecuteQuery(string req, SQLiteParameter[] param)
        {
            using (var command = new SQLiteCommand(req, connection))
            {
                command.Parameters.AddRange(param);
                return command.ExecuteReader();
            }
        }
    }
}
