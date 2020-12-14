using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

using System.Data;
using MySql.Data.MySqlClient;
using System.Configuration;

namespace GET_WPF
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        MySqlConnection connection = new MySqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // 1. DataBinding - Propriétié d'Object métier
                connection.Open();
                MySqlCommand cmd = new MySqlCommand("Select * from Admin", connection);
                // Définit une instruction SQL ou une procédure stockée utilisée pour sélectionner des enregistrements dans la source de données.
                MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
                DataSet ds = new DataSet(); // Représente un cache en mémoire des données.

                adp.Fill(ds, "LoadDataBinding"); // Remplis le cache mémoire, Collection qui est utilisée pour générer le contenu de ItemSource
                dataGridUser.DataContext = ds;

                connection.Close();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
