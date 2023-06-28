using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConcesionarioBBDD
{
    internal class Coche
    {
        private String marca;
        private String modelo;
        private String version;
        private String combustible;
        private int precio;
        private String foto;
        private String llantas;
        private String climatizador;
        private String cambio;
        private String porton;

        public String Marca { get => marca; set => marca = value; }
        public String Modelo { get => modelo; set => modelo = value; }
        public String Version { get => version; set => version = value; }
        public String Combustible { get => combustible; set => combustible = value; }
        public int Precio { get => precio; set => precio = value; }
        public String Foto { get => foto; set => foto = value; }
        public String Llantas { get => llantas; set => llantas = value; }
        public String Climatizador { get => climatizador; set => climatizador = value; }
        public String Cambio { get => cambio; set => cambio = value; }
        public String Porton { get => porton; set => porton = value; }



        public Coche(String marca, String modelo, String version, String combustible, int precio, String foto, String llantas, String climatizador, String cambio, String porton)
        {
            this.marca = marca;
            this.modelo = modelo;
            this.version = version;
            this.combustible = combustible;
            this.precio = precio;
            this.foto = foto;
            this.llantas = llantas;
            this.climatizador = climatizador;
            this.cambio = cambio;
            this.porton = porton;
        }

    }
}
