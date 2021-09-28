using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace ejercicioAlumnos
{
    class Data
    {
        private String ruta;

        public Data(String ruta)
        {
            this.ruta = ruta;
        }

        public bool existeArchivoDat() {
            return File.Exists(ruta);
        }

        public void serializar(List<Alumno> lista) {
            Stream flujo = File.Open(ruta, FileMode.Create);
            BinaryFormatter bin = new BinaryFormatter();
            bin.Serialize(flujo, lista);
            flujo.Close();
        }

        public List<Alumno> desSerializar()
        {
            List<Alumno> lista;
            Stream flujo = File.Open(ruta, FileMode.Open);
            BinaryFormatter bin = new BinaryFormatter();
            lista = (List<Alumno>)bin.Deserialize(flujo);
            flujo.Close();
            return lista;
        }
    }
}
