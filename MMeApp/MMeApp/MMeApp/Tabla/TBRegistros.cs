using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace MMeApp.Tabla
{
    public class TBRegistros
    {
        // View 1
        [PrimaryKey, AutoIncrement]
        public int Id_orden { get; set; }
        [Unique, NotNull]
        public string Oreference { get; set; }
        public string Abusto { get; set; }
        public string Tdelantero { get; set; }
        public string Cpecho { get; set; }
        public string Dbusto { get; set; }
        public string Ccintura { get; set; }
        public string Ccadera { get; set; }

        //View 2
        public string Ahombro { get; set; }
        public string Ccuello { get; set; }
        public string Cbrazo { get; set; }
        public string Cpuno { get; set; }
        public string Ctiro { get; set; } // en algunas variables aparece como LTiro
        public string Lfp { get; set; }

        //View3
        public string Aespalda { get; set; }
        public string Tespalda { get; set; }
        public string Lbrazo { get; set; }
        public string Lcadera { get; set; }
        public string Lrodilla { get; set; }

        //FinalView

        public string Extra { get; set; }
        public string UbicacionImagen1 { get; set; }
        public string UbicacionImagen2 { get; set; }
        public string UbicacionImagen3 { get; set; }
    }
}
