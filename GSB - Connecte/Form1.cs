using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Data.OracleClient;
using MySql.Data.MySqlClient;

namespace Connecté
{
    public partial class Form1 : Form
    {

        private string provider = "localhost";

        private string dataBase = "gsb";

        private string uid = "root";

        private string mdp = "";



        private ConnexionSql maConnexionSql;


        private MySqlCommand Ocom;

        private DataTable dt;





        public Form1()
        {
            InitializeComponent();
        }






        private void Form1_Load(object sender, EventArgs e)
        {
            maConnexionSql = ConnexionSql.getInstance(provider, dataBase, uid, mdp);


            maConnexionSql.OpenConnection();

        }






        private void Timer_Tick(object sender, EventArgs e)
        {
            Timer.Stop();
        }






        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            maConnexionSql.CloseConnection();
        }

    }
}
