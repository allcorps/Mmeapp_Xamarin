using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using MMeApp.Tabla;

namespace MMeApp.Data
{
    public interface ISQLite
    {
        // creacion de registro de tabla de datos
        SQLiteConnection GetSQLiteConnectionWithCreateDatabase();

        // guardar, actualizar, eliminar, y lista de registros
        bool SaveRegister(TBRegistros bDTBRegistros);
        bool UpdateRegister(TBRegistros bDTBRegistros);
        void DeleteRegister(int Id);
        List<TBRegistros> ListaRegistros();

        bool UserExist(string Registros);

    }
}
