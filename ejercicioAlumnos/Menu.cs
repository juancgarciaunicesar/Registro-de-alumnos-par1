using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ejercicioAlumnos
{
    class Menu
    {
        private Data data;
        private List<Alumno> alumnos;
        private Alumno a;
        private int opcion;

        public Menu() {
            data = new Data("alumnos.txt");
            alumnos = new List<Alumno>();
        }
        
        public void show() {
            if (data.existeArchivoDat()){
                alumnos = data.desSerializar();
            }
            do{
                do{
                    limpiarPantalla();

                    Console.WriteLine("====================================");
                    Console.WriteLine("           Menú principal           ");
                    Console.WriteLine("====================================");
                    Console.WriteLine("1.- Registrar alumno");
                    Console.WriteLine("2.- Buscar alumno por RUN");
                    Console.WriteLine("3.- Listar alumnos con promedios");
                    Console.WriteLine("4.- Eliminar alumno por RUN");
                    Console.WriteLine("5.- Ver promedio del curso");
                    Console.WriteLine("6.- Alumno con promedio más alto");
                    Console.WriteLine("7.- Alumno con promedio más bajo");
                    Console.WriteLine("8.- Salir");
                    Console.WriteLine("====================================");
                    Console.Write("Digite su opción: ");
                    opcion = Convert.ToInt32(Console.ReadLine());
                }while(opcion < 1 || opcion > 8);

                limpiarPantalla();
                switch (opcion){
                    case 1: {
                        a = new Alumno();

                        Console.WriteLine("Run: ");
                        a.Run = Console.ReadLine();

                        Console.WriteLine("Nombre: ");
                        a.Nombre = Console.ReadLine();

                        Console.WriteLine("Edad: ");
                        a.Edad = Convert.ToInt32(Console.ReadLine());

                        Console.WriteLine("Nota 1: ");
                        a.Nota1 = float.Parse(Console.ReadLine());
                        Console.WriteLine("Nota 2: ");
                        a.Nota2 = float.Parse(Console.ReadLine());
                        Console.WriteLine("Nota 3: ");
                        a.Nota3 = float.Parse(Console.ReadLine());

                        alumnos.Add(a);

                        Console.WriteLine("Alumno registrado");

                        break;
                    }

                    case 2:{
                        Console.Write("Run a buscar: ");
                        String runBuscar = Console.ReadLine();

                        foreach (Alumno a in alumnos){
                            if (a.Run == runBuscar){
                                a.desplegarInformacion();
                                break;
                            }
                        }
                        break;
                    }

                    case 3:{
                        Console.WriteLine();
                        Console.WriteLine("------------------");
                        Console.WriteLine("Listado de alumnos");
                        Console.WriteLine("------------------");
                        foreach (Alumno a in alumnos){
                            a.desplegarInformacion();
                        }
                        break;
                    }
                    case 4:{
                        Console.Write("Run a eliminar: ");
                        String runEliminar = Console.ReadLine();
                        bool encontrado = false;
                        String respuesta = "";

                        foreach (Alumno a in alumnos){
                            if (a.Run == runEliminar){
                                encontrado = true;

                                Console.WriteLine("¿Realmente desea eliminar a "+a.Nombre+"? [si/no]");
                                respuesta = Console.ReadLine();
                                respuesta = respuesta.ToLower();

                                break;
                            }
                        }

                        if (encontrado){
                            if(respuesta == "si"){
                                alumnos.RemoveAll(a => a.Run == runEliminar);
                                Console.WriteLine("Alumno eliminado");
                            }
                        }else {
                            Console.WriteLine("Alumno no encontrado");
                        }


                        break;
                    }

                    case 5:{
                        float suma = 0, promedio ;
                        int cantidadAlumnos = alumnos.Count;

                        foreach (Alumno a in alumnos){
                            suma = suma + a.getPromedio();
                        }

                        promedio = suma / cantidadAlumnos;

                        Console.WriteLine("Promedio del curso: "+promedio);

                        break;
                    }

                    case 6:{
                        Alumno alumPromedioAlto = null;
                        int i = 0;

                        foreach (Alumno a in alumnos){
                            if (i == 0){
                                alumPromedioAlto = a;
                            }else if(a.getPromedio() > alumPromedioAlto.getPromedio()) {
                                alumPromedioAlto = a;
                            }

                            i++;
                        }

                        Console.WriteLine("Alumno promedio más alto [" + alumPromedioAlto.getPromedio() + "]");
                        alumPromedioAlto.desplegarInformacion();

                        break;
                    }

                    case 7:{
                        Alumno alumPromedioBajo = null;
                        int i = 0;

                        foreach (Alumno a in alumnos){
                            if (i == 0)
                            {
                                alumPromedioBajo = a;
                            }
                            else if (a.getPromedio() < alumPromedioBajo.getPromedio())
                            {
                                alumPromedioBajo = a;
                            }

                            i++;
                        }

                        Console.WriteLine("Alumno promedio más bajo ["+alumPromedioBajo.getPromedio()+"]");
                        alumPromedioBajo.desplegarInformacion();
                        break;
                    }

                    case 8:{
                        data.serializar(alumnos);
                        Console.WriteLine("Gracias por utilizar la aplicación!");
                        break;
                    }
                }
                presioneUnaTeclaParaContinuar();
            }while(opcion != 8);
        }

        private void limpiarPantalla()
        {
            for (int i = 0; i < 40; i++ )
            {
                Console.WriteLine();
            }
        }

        private void presioneUnaTeclaParaContinuar()
        {
            Console.WriteLine("Presione una tecla para continuar...");
            Console.ReadLine();
        }
    }
}
