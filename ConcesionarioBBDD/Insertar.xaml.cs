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
    /// Lógica de interacción para Insertar.xaml
    /// </summary>
    public partial class Insertar : Window
    {
        SqlConnection miConexionSql;
        string miConexion;
        DataTable miTabla = new DataTable();

        ObservableCollection<Coche> listaCoches = new ObservableCollection<Coche>();

        public Insertar()
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


        private void btnInsertar_Click(object sender, RoutedEventArgs e)
        {
            string rutaP, rutaH, rutaK;

            rutaP = "/Imágenes/2008.jpg";
            rutaH = "/Imágenes/i30.jpg";
            rutaK = "/Imágenes/sorrento.jpg";

            string consulta = "INSERT INTO COCHES (MARCA, MODELO, VERSION, COMBUSTIBLE, PRECIO, FOTO, LLANTAS, CLIMATIZADOR, CAMBIO, PORTON) VALUES (@marca, @modelo," +
                " @version, @combustible, @precio, @foto,  @llantas, @climatizador, @cambio, @porton);";

            SqlCommand miComando = new SqlCommand(consulta, miConexionSql);
            miComando.Parameters.AddWithValue("@marca", tbMarca.Text);
            miComando.Parameters.AddWithValue("@modelo", tbModelo.Text);
            miComando.Parameters.AddWithValue("@version", tbVersion.Text);
            miComando.Parameters.AddWithValue("@combustible", tbCombustible.Text);
            miComando.Parameters.AddWithValue("@precio", tbPrecio.Text);

            if (tbMarca.Text.Equals("Peugeot"))
            {
                miComando.Parameters.AddWithValue("@foto", rutaP);
            }
            else if (tbMarca.Text.Equals("Hyundai"))
            {
                miComando.Parameters.AddWithValue("@foto", rutaH);
            }
            else
            {
                miComando.Parameters.AddWithValue("@foto", rutaK);
            }
            
            miComando.Parameters.AddWithValue("@llantas", tbLlantas.Text);
            miComando.Parameters.AddWithValue("@climatizador", tbClimatizador.Text);
            miComando.Parameters.AddWithValue("@cambio", tbCambio.Text);
            miComando.Parameters.AddWithValue("@porton", tbPorton.Text);
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
