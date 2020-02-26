using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace FOODIARY
{
   
    public partial class Form1 : Form
    {
        private static List<Reteta> Incarca_Reteta()
        {
            MySqlConnection conn = new MySqlConnection("Datasource = localhost; UserID=root; database=foodiary");
            MySqlCommand retetaCommand = new MySqlCommand();
            retetaCommand.Connection = conn;
            retetaCommand.CommandText = "SELECT * FROM reteta";
            string Nume_DB;
            string Descriere_DB;
            List<Reteta> Reteta_List = new List<Reteta>();
            try
            {
                conn.Open();
                Console.WriteLine("Conexiunea la Baza de date DB FOODIARY a fost realizata!");
                MySqlDataReader readerReteta = retetaCommand.ExecuteReader();
                while (readerReteta.Read())
                {
                    Nume_DB = (readerReteta["Nume"].ToString());
                    Descriere_DB = (readerReteta["Descriere"].ToString());

                    Reteta Reteta_Actuala = new Reteta();
                    Reteta_Actuala.Nume = Nume_DB;
                    Reteta_Actuala.Descriere = Descriere_DB;

                    Reteta_List.Add(Reteta_Actuala);
                }
            }
           
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                conn.Close();
            }
            return Reteta_List;
        }

        public Form1()
        {
            InitializeComponent();
            List<Reteta> Retete_din_DB = Incarca_Reteta(); 
            textBox2.Text = (string.Join("\n",Retete_din_DB)); 
        }

       
    }
}
