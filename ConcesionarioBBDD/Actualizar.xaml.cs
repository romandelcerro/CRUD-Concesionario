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
    /// Lógica de interacción para Actualizar.xaml
    /// </summary>
    public partial class Actualizar : Window
    {
        SqlConnection miConexionSql;
        string miConexion;
        DataTable miTabla = new DataTable();

        ObservableCollection<Coche> listaCoches = new ObservableCollection<Coche>();

        public Actualizar()
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


        private void btnActualizar_Click(object sender, RoutedEventArgs e)
        {
            string id="";

            Coche modeloVehiculo = (Coche)lvVehiculos.SelectedItem;

            string consultaId = "SELECT ID FROM COCHES WHERE MARCA=@marca AND MODELO=@modelo AND VERSION=@version AND COMBUSTIBLE=@combustible AND PRECIO=@precio AND" +
                " LLANTAS=@llantas AND CLIMATIZADOR=@climatizador AND CAMBIO=@cambio AND PORTON=@porton;";

            SqlCommand miComando2 = new SqlCommand(consultaId, miConexionSql);
            miComando2.Parameters.AddWithValue("@marca", modeloVehiculo.Marca);
            miComando2.Parameters.AddWithValue("@modelo", modeloVehiculo.Modelo);
            miComando2.Parameters.AddWithValue("@version", modeloVehiculo.Version);
            miComando2.Parameters.AddWithValue("@combustible", modeloVehiculo.Combustible);
            miComando2.Parameters.AddWithValue("@precio", modeloVehiculo.Precio);
            miComando2.Parameters.AddWithValue("@llantas", modeloVehiculo.Llantas);
            miComando2.Parameters.AddWithValue("@climatizador", modeloVehiculo.Climatizador);
            miComando2.Parameters.AddWithValue("@cambio", modeloVehiculo.Cambio);
            miComando2.Parameters.AddWithValue("@porton", modeloVehiculo.Porton);

            miConexionSql.Open();
            miComando2.ExecuteNonQuery();
            SqlDataReader reader = miComando2.ExecuteReader();
            while (reader.Read())
            {
                id = reader["Id"].ToString();
            }
                
            miConexionSql.Close();

            string consulta = "UPDATE COCHES SET MARCA=@marca, MODELO=@modelo, VERSION=@version, COMBUSTIBLE=@combustible, PRECIO=@precio, LLANTAS=@llantas," +
                " CLIMATIZADOR=@climatizador, CAMBIO=@cambio, PORTON=@porton WHERE ID=@id;";
                
            SqlCommand miComando = new SqlCommand(consulta, miConexionSql);
            miComando.Parameters.AddWithValue("@marca", tbMarca.Text);
            miComando.Parameters.AddWithValue("@modelo", tbModelo.Text);
            miComando.Parameters.AddWithValue("@version", tbVersion.Text);
            miComando.Parameters.AddWithValue("@combustible", tbCombustible.Text);
            miComando.Parameters.AddWithValue("@precio", tbPrecio.Text);
            miComando.Parameters.AddWithValue("@llantas", tbLlantas.Text);
            miComando.Parameters.AddWithValue("@climatizador", tbClimatizador.Text);
            miComando.Parameters.AddWithValue("@cambio", tbCambio.Text);
            miComando.Parameters.AddWithValue("@porton", tbPorton.Text);
            miComando.Parameters.AddWithValue("@id", id);
            miConexionSql.Open();
            miComando.ExecuteNonQuery();
            miConexionSql.Close();

            tbMarca.Text = "";
            tbModelo.Text = "";
            tbVersion.Text = "";
            tbCombustible.Text = "";
            tbPrecio.Text = "";
            tbLlantas.Text = "";
            tbClimatizador.Text = "";
            tbCambio.Text = "";
            tbPorton.Text = "";

            actualizarLvVehiculos();
        }

        private void lvVehiculos_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (lvVehiculos.SelectedItem != null)
            {
                Coche modeloVehiculo = (Coche)lvVehiculos.SelectedItem;

                tbMarca.Text = modeloVehiculo.Marca;
                tbModelo.Text = modeloVehiculo.Modelo;
                tbVersion.Text = modeloVehiculo.Version;
                tbCombustible.Text = modeloVehiculo.Combustible;
                tbPrecio.Text =  modeloVehiculo.Precio.ToString();
                tbLlantas.Text = modeloVehiculo.Llantas;
                tbClimatizador.Text = modeloVehiculo.Climatizador;
                tbCambio.Text = modeloVehiculo.Cambio;
                tbPorton.Text = modeloVehiculo.Porton;
            }
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

