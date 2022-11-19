
namespace Tp09_Kuniewsky_Grimberg.Models;
using Dapper;
using System.Data.SqlClient;
using System;
using System.Collections.Generic;
public class BD
{

    private static string _connectionString = @"Server=LIAMKUNY\SQLEXPRESS;DataBase=TPBSAS;Trusted_Connection=True";

        public static List<Monumento> ObtenerMonumentos()
    {
        List<Monumento> lista = new List<Monumento>();
        string sql = "SELECT * FROM Monumentos";
        using (SqlConnection db = new SqlConnection(_connectionString))
        {

            lista = db.Query<Monumento>(sql).ToList();
        }
        return lista;
    }

    public static Monumento ObtenerMonumento(int Id)
    {
        Monumento? monumento = null;
        using (SqlConnection connection = new SqlConnection(_connectionString))
        {
            monumento = connection.QueryFirstOrDefault<Monumento>("SELECT * FROM Monumentos WHERE IdMonumento = @pId", new { pId = Id });
        }
        return monumento;
    }
     
    public static void AgregarMonumento(string Nombre, string Foto, string Barrio, DateTime FechaFundacion, string Info,int IdCategoria)
    {
        string sql = "INSERT INTO Monumentos(Nombre, Foto, Barrio, FechaFundacion, Info, IdCategoria) VALUES (@pNombre, @pFoto, @pBarrio, @pFechaFundacion, @pInfo, @pIdCategoria)";
        using (SqlConnection db = new SqlConnection(_connectionString))
        {
            db.Execute(sql, new
            {
                pNombre=Nombre,
                pFoto = Foto,
                pBarrio=Barrio,
                pFechaFundacion = FechaFundacion,
                pInfo = Info,
                pIdCategoria=IdCategoria,
            });
        }
    }

    public static void ModificarMonumento(int id, Monumento c)
    {
        using (SqlConnection connection = new SqlConnection(_connectionString))
        {
            connection.Execute("UPDATE Monumentos SET Nombre = @pNombre, Foto = @pFoto, Barrio = @pBarrio, FechaFundacion = @pFechaFundacion, Info = @pInfo WHERE IdMonumento = @pId", new { pId = id, pNombre = c.Nombre, pFoto = c.Foto, pBarrio= c.Barrio, pFechaFundacion = c.FechaFundacion, pInfo = c.Info });
        }
    }


    public static void EliminarMonumento(int IdMonumento)
    {
        string sql = "DELETE FROM Monumentos WHERE IdMonumento = @_IdMonumento";
        using (SqlConnection db = new SqlConnection(_connectionString))
        {
            db.Execute(sql, new { _IdMonumento = IdMonumento});
        }
    }
}