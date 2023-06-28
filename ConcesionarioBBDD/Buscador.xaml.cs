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
using System.Windows.Shapes;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Collections.ObjectModel;
using System.Runtime.Remoting.Messaging;

namespace ConcesionarioBBDD
{
    /// <summary>
    /// Lógica de interacción para Buscador.xaml
    /// </summary>
    public partial class Buscador : Window
    {
        SqlConnection miConexionSql;
        string miConexion;
        DataTable miTabla = new DataTable();

        ObservableCollection<Coche> listaCoches = new ObservableCollection<Coche>();

        public Buscador()
        {
            InitializeComponent();

            miConexion = ConfigurationManager.ConnectionStrings["ConcesionarioBBDD.Properties.Settings.ConcesionarioDAM2ConnectionString"].ConnectionString;
            miConexionSql = new SqlConnection(miConexion);

            if (rbPeugeot.IsChecked == true)
            {
                string seleccionado = rbPeugeot.Content.ToString();
                string consulta = "SELECT DISTINCT MODELO FROM COCHES WHERE MARCA = @marca";
                SqlCommand miComando = new SqlCommand(consulta, miConexionSql);
                miComando.Parameters.AddWithValue("@marca", seleccionado);
                miConexionSql.Open();
                miComando.ExecuteNonQuery();

                SqlDataReader reader = miComando.ExecuteReader();

                List<string> listaModelos = new List<string>();
                while (reader.Read())
                {
                    listaModelos.Add(reader["Modelo"].ToString());
                }

                miConexionSql.Close();

                cbModelos.ItemsSource = listaModelos;
            }
        }

        private void Button_Home(object sender, RoutedEventArgs e)
        {
            MainWindow home = new MainWindow();
            home.Show();
            this.Close();
        }

        
        public void rbPeugeot_Click(object sender, RoutedEventArgs e)
        {
            string seleccionado = rbPeugeot.Content.ToString();
            string consulta = "SELECT DISTINCT MODELO FROM COCHES WHERE MARCA = @marca";
            SqlCommand miComando = new SqlCommand(consulta, miConexionSql);
            miComando.Parameters.AddWithValue("@marca", seleccionado);
            miConexionSql.Open();
            miComando.ExecuteNonQuery();

            SqlDataReader reader = miComando.ExecuteReader();

            List<string> listaModelos = new List<string>();
            while (reader.Read())
            {
                listaModelos.Add(reader["Modelo"].ToString());
            }

            miConexionSql.Close();

            cbModelos.ItemsSource = listaModelos;
            Uri resourceUri = new Uri("/Imágenes/logo-coche.jpg", UriKind.Relative);
            imagen.Source = new BitmapImage(resourceUri);
            tbExtras.Text = null;
        }

        private void rbHyundai_Click(object sender, RoutedEventArgs e)
        {
            string seleccionado = rbHyundai.Content.ToString();
            string consulta = "SELECT DISTINCT MODELO FROM COCHES WHERE MARCA = @marca";
            SqlCommand miComando = new SqlCommand(consulta, miConexionSql);
            miComando.Parameters.AddWithValue("@marca", seleccionado);
            miConexionSql.Open();
            miComando.ExecuteNonQuery();

            SqlDataReader reader = miComando.ExecuteReader();

            List<string> listaModelos = new List<string>();
            while (reader.Read())
            {
                listaModelos.Add(reader["Modelo"].ToString());
            }

            miConexionSql.Close();

            cbModelos.ItemsSource = listaModelos;
            Uri resourceUri = new Uri("/Imágenes/logo-coche.jpg", UriKind.Relative);
            imagen.Source = new BitmapImage(resourceUri);
            tbExtras.Text = null;
        }

        private void rbKia_Click(object sender, RoutedEventArgs e)
        {
            string seleccionado = rbKia.Content.ToString();
            string consulta = "SELECT DISTINCT MODELO FROM COCHES WHERE MARCA = @marca";
            SqlCommand miComando = new SqlCommand(consulta, miConexionSql);
            miComando.Parameters.AddWithValue("@marca", seleccionado);
            miConexionSql.Open();
            miComando.ExecuteNonQuery();

            SqlDataReader reader = miComando.ExecuteReader();

            List<string> listaModelos = new List<string>();
            while (reader.Read())
            {
                listaModelos.Add(reader["Modelo"].ToString());
            }

            miConexionSql.Close();

            cbModelos.ItemsSource = listaModelos;
            Uri resourceUri = new Uri("/Imágenes/logo-coche.jpg", UriKind.Relative);
            imagen.Source = new BitmapImage(resourceUri);
            tbExtras.Text = null;
        }

        private void cbModelos_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Uri resourceUri = new Uri("/Imágenes/logo-coche.jpg", UriKind.Relative);
            imagen.Source = new BitmapImage(resourceUri);
            tbExtras.Text = null;

            listaCoches.Clear();
            miTabla.Clear();

            String Modelo = (String)cbModelos.SelectedItem;
            
            string consulta = "SELECT * FROM COCHES WHERE MODELO='"+Modelo+"';";
            
            
            SqlDataAdapter misResultados = new SqlDataAdapter(consulta, miConexionSql);
            misResultados.Fill(miTabla);

            foreach (DataRow fila in miTabla.Rows)
            {
                listaCoches.Add(new Coche((string)fila["Marca"], (string)fila["Modelo"], (string)fila["Version"], (string)fila["Combustible"], (int)fila["Precio"], (string)fila["Foto"], (string)fila["Llantas"], (string)fila["Climatizador"], (string)fila["Cambio"], (string)fila["Porton"]));
            }

            lvVehiculos.ItemsSource = null;
            lvVehiculos.ItemsSource = listaCoches;
        }

        private void lvVehiculos_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string textoExtras = "";

            if (lvVehiculos.SelectedItem != null)
            {
                Coche modeloVehiculo = (Coche)lvVehiculos.SelectedItem;

                    if (modeloVehiculo.Modelo.Equals(modeloVehiculo.Modelo))
                    {
                        Uri resourceUri = new Uri(modeloVehiculo.Foto, UriKind.Relative);
                        imagen.Source = new BitmapImage(resourceUri);

                        textoExtras = "- "+modeloVehiculo.Llantas + "\n" + "- " + modeloVehiculo.Climatizador + "\n" + "- " + modeloVehiculo.Cambio + "\n" + "- " + modeloVehiculo.Porton;
                        
                        tbExtras.Text = textoExtras;
                    }
            }
        }
    }
}
