using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.OleDb;
using System.Windows.Forms ;
using MySql.Data.MySqlClient;

namespace Connecté {

    /**
     * Classe de connexion à une base de données
     */
    public class ConnexionSql
    {
        private static ConnexionSql connection = null;

        private MySqlConnection oleCn;

        private static readonly object mylock = new object();

        private string connString;


        private ConnexionSql(string unProvider, string uneDataBase, string unUid, string unMdp)
        {


            try
            {
                connString = "SERVER=" + unProvider + ";" + "DATABASE=" +
                uneDataBase + ";" + "UID=" + unUid + ";" + "PASSWORD=" + unMdp + ";";
                try
                {
                    oleCn = new MySqlConnection(connString);
                }
                catch (Exception emp)
                {
                    MessageBox.Show(emp.Message);
                }
            }
            catch (Exception emp)
            {
                MessageBox.Show(emp.Message);
            }



        }



        /**
         * méthode de création d'une instance de connexion si elle n'existe pas (singleton)
         */
        public static ConnexionSql getInstance(string unProvider, string uneDataBase, string unUid, string unMdp)
        {

            lock ((mylock))
            {

                try
                {


                    if (null == connection)
                    { // Premier appel
                        connection = new ConnexionSql(unProvider, uneDataBase, unUid, unMdp);
                        
                    }

                }
                catch (Exception emp)
                {
                    MessageBox.Show(emp.Message);


                }
                return connection;

            }
        }





        /**
         * Ouverture de la connexion
         */
        public void OpenConnection()
        {
            try
            {
                oleCn.Open();
            }
            catch (Exception emp)
            {
                MessageBox.Show(emp.Message);
            }
        }

        /**
         * Fermeture de la connexion
         */
        public void CloseConnection()
        {
            oleCn.Close();
        }

        /**
         * Exécution d'une requête
         */
        public MySqlCommand reqExec(string req)
        {
            MySqlCommand mysqlCom = new MySqlCommand(req, this.oleCn);
            return (mysqlCom);
        }

    }

}