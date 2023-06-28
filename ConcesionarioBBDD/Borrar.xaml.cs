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

namespace ConcesionarioBBDD
{
    /// <summary>
    /// Lógica de interacción para Borrar.xaml
    /// </summary>
    public partial class Borrar : Window
    {
        SqlConnection miConexionSql;
        string miConexion;
        DataTable miTabla = new DataTable();

        ObservableCollection<Coche> listaCoches = new ObservableCollection<Coche>();

        public Borrar()
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

        private void rbPeugeot_Click(object sender, RoutedEventArgs e)
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
        }

        private void cbModelos_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            actualizarLvVehiculos();
        }

        private void Button_Borrar(object sender, RoutedEventArgs e)
        {
            Coche modeloVehiculo = (Coche)lvVehiculos.SelectedItem;

            string consulta = "DELETE FROM COCHES WHERE MARCA=@marca AND MODELO=@modelo AND VERSION=@version AND COMBUSTIBLE=@combustible AND PRECIO=@precio AND LLANTAS=@llantas AND" +
                " CLIMATIZADOR=@climatizador AND CAMBIO=@cambio AND PORTON=@porton;";

            SqlCommand miComando = new SqlCommand(consulta, miConexionSql);
            miComando.Parameters.AddWithValue("@marca", modeloVehiculo.Marca);
            miComando.Parameters.AddWithValue("@modelo", modeloVehiculo.Modelo);
            miComando.Parameters.AddWithValue("@version", modeloVehiculo.Version);
            miComando.Parameters.AddWithValue("@combustible", modeloVehiculo.Combustible);
            miComando.Parameters.AddWithValue("@precio", modeloVehiculo.Precio);
            miComando.Parameters.AddWithValue("@llantas", modeloVehiculo.Llantas);
            miComando.Parameters.AddWithValue("@climatizador", modeloVehiculo.Climatizador);
            miComando.Parameters.AddWithValue("@cambio", modeloVehiculo.Cambio);
            miComando.Parameters.AddWithValue("@porton", modeloVehiculo.Porton);
            miConexionSql.Open();
            miComando.ExecuteNonQuery();
            miConexionSql.Close();

            actualizarLvVehiculos();
        }

        public void actualizarLvVehiculos()
        {
            listaCoches.Clear();
            miTabla.Clear();

            String Modelo = (String)cbModelos.SelectedItem;

            string consulta2 = "SELECT * FROM COCHES WHERE MODELO='" + Modelo + "';";


            SqlDataAdapter misResultados = new SqlDataAdapter(consulta2, miConexionSql);
            misResultados.Fill(miTabla);

            foreach (DataRow fila in miTabla.Rows)
            {
                listaCoches.Add(new Coche((string)fila["Marca"], (string)fila["Modelo"], (string)fila["Version"], (string)fila["Combustible"], (int)fila["Precio"], (string)fila["Foto"], (string)fila["Llantas"], (string)fila["Climatizador"], (string)fila["Cambio"], (string)fila["Porton"]));
            }

            lvVehiculos.ItemsSource = null;
            lvVehiculos.ItemsSource = listaCoches;
        }
    }
}
