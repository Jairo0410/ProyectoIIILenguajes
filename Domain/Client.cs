using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Client
    {
        private String nombre;
        private int edad;
        private char genero;

        public Client(String nombre, int edad, char genero)
        {
            this.Nombre = nombre;
            this.Edad = edad;
            this.Genero = genero;
        }

        public string Nombre { get => nombre; set => nombre = value; }
        public int Edad { get => edad; set => edad = value; }
        public char Genero { get => genero; set => genero = value; }
    }
}
