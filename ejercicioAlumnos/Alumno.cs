using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ejercicioAlumnos
{
    [Serializable()]
    class Alumno
    {
        private String run;

        public String Run
        {
            get { return run; }
            set { run = value; }
        }
        private String nombre;

        public String Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }
        private int edad;

        public int Edad
        {
            get { return edad; }
            set { edad = value; }
        }
        private float nota1;

        public float Nota1
        {
            get { return nota1; }
            set { nota1 = value; }
        }
        private float nota2;

        public float Nota2
        {
            get { return nota2; }
            set { nota2 = value; }
        }
        private float nota3;

        public float Nota3
        {
            get { return nota3; }
            set { nota3 = value; }
        }

        public float getPromedio() {
            return (nota1 + nota2 + nota3) / 3;
        }

        public void desplegarInformacion() {
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("==================================");
            Console.WriteLine("RUN: "+run);
            Console.WriteLine("NOMBRE: "+nombre);
            Console.WriteLine("EDAD: "+edad);
            Console.WriteLine("----------------------------------");
            Console.Write("NOTAS --> ");
            Console.Write(nota1 +" - ");
            Console.Write(nota2 + " - ");
            Console.WriteLine(nota3);
            Console.WriteLine("PROMEDIO --> "+getPromedio());
            Console.WriteLine("==================================");
            Console.WriteLine();
            Console.WriteLine();
        }
    }
}
