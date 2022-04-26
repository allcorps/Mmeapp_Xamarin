using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MMeApp.Droid;
using MMeApp.Data;
using MMeApp.Tabla;
using SQLite;
using System.IO;
using Xamarin.Forms;

[assembly: Dependency(typeof(ISQLite_Android))]
namespace MMeApp.Droid
{
    public class ISQLite_Android : ISQLite
    {
        SQLiteConnection con;

        //creacion de la tabla
        public SQLiteConnection GetSQLiteConnectionWithCreateDatabase()
        {
            string fileName = "BDRegistros.db3";
            string documentPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            string path = Path.Combine(documentPath, fileName);
            con = new SQLiteConnection(path);
            con.CreateTable<TBRegistros>();

            return con;
        }

        public bool SaveRegister(TBRegistros bDTBRegistros)
        {
            bool res = false;
            try
            {
                con.Insert(bDTBRegistros);
                res = true;
            }
            catch (Exception e)
            {
                Console.WriteLine("Error : " + e); 
            }
            return res;
        }

        public bool UpdateRegister(TBRegistros bDTBRegistros)
        {
            bool res = false;
            try 
            {
                string sql = $"UPDATE TBRegistros SET Oreference='{bDTBRegistros.Oreference}'," +
                             $"Abusto='{bDTBRegistros.Abusto}'," +
                             $"Tdelantero='{bDTBRegistros.Tdelantero}'," +
                             $"Cpecho='{bDTBRegistros.Cpecho}'," +
                             $"Dbusto='{bDTBRegistros.Dbusto}'," +
                             $"Ccintura='{bDTBRegistros.Ccintura}'," +
                             $"Ccadera='{bDTBRegistros.Ccadera}'," +
                             $"Ahombro='{bDTBRegistros.Ahombro}'," +
                             $"Ccuello='{bDTBRegistros.Ccuello}'," +
                             $"Cbrazo='{bDTBRegistros.Cbrazo}'," +
                             $"Cpuno='{bDTBRegistros.Cpuno}'," +
                             $"Ctiro='{bDTBRegistros.Ctiro}'," +
                             $"Lfp='{bDTBRegistros.Lfp}'," +
                             $"Aespalda='{bDTBRegistros.Aespalda}'," +
                             $"Tespalda='{bDTBRegistros.Tespalda}'," +
                             $"Lbrazo='{bDTBRegistros.Lbrazo}'," +
                             $"Lcadera='{bDTBRegistros.Lcadera}'," +
                             $"Lrodilla='{bDTBRegistros.Lrodilla}'," +
                             $"Extra='{bDTBRegistros.Extra}'," +
                             $"UbicacionImagen1='{bDTBRegistros.UbicacionImagen1}'," +
                             $"UbicacionImagen2='{bDTBRegistros.UbicacionImagen2}'," +
                             $"UbicacionImagen3='{bDTBRegistros.UbicacionImagen3}' WHERE Id_orden={bDTBRegistros.Id_orden}";

                con.Execute(sql);
                res = true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            return res;
        }

        public void DeleteRegister(int Id)
        {
            string sql = $"DELETE FROM TBRegistros WHERE Id_orden={Id}";
            con.Execute(sql);
        }

        public List<TBRegistros> ListaRegistros()
        {
            try
            {
                string command = "SELECT * FROM TBRegistros";
                return con.Query<TBRegistros>(command);
            }
            catch(Exception e)
            {
                Console.WriteLine("Error : " + e);
            }
            return null;
        }

        public bool UserExist(string registro)
        {
            string command = $"SELECT * FROM TBRegistros WHERE Oreference='{registro}'";
            List<TBRegistros> registros = con.Query<TBRegistros>(command);

            return registros.Count == 1;
        }


    }
}