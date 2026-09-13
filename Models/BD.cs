using Microsoft.Data.SqlClient;
using Dapper;

namespace TP06.Models;

public class BD
{
   private string _connectionString = @"Server=localHost\SQLEXPRESS;DataBase=TP06;Integrated Security=true;TrustServerCertificate=true;";

    public void Registrarse(Jugador jugador)
    {
       using(SqlConnection connection = new SqlConnection(_connectionString))
       {            
            string query = "INSERT INTO Jugadores (nombreUsuario, contraseña, Estado, salaActual) VALUES (@PnombreUsuario, @Pcontraseña, @Pestado, @PsalaActual)";
            connection.Execute(query, new {PnombreUsuario = jugador.nombreUsuario, Pcontraseña = jugador.contraseña, Pestado = "En progreso", PsalaActual = "1" });
       }
    }
    public Jugador loguearse(string nombreUsuario, string contraseña)
    {
       Jugador jugador = new Jugador();
      using(SqlConnection connection = new SqlConnection(_connectionString))
         {
            string query = "SELECT * FROM Jugadores WHERE NombreUsuario = @PnombreUsuario AND Contraseña = @Pcontraseña";
            jugador = connection.QueryFirstOrDefault<Jugador>(query, new {PnombreUsuario = nombreUsuario, Pcontraseña = contraseña});
         } 
         return jugador;
    }
    // metodo para guardar el estado de la partida en la base de datos
    public void GuardarPartida(Jugador jugador)
    {
        using(SqlConnection connection = new SqlConnection(_connectionString))
        {
            string query = "UPDATE Jugadores SET Estado = @Pestado, salaActual = @PsalaActual WHERE NombreUsuario = @PnombreUsuario AND Contraseña = @Pcontraseña";
            connection.Execute(query, new {Pestado = jugador.estado, PsalaActual = jugador.salaActual, PnombreUsuario = jugador.nombreUsuario, Pcontraseña = jugador.contraseña});
        }
    }
    public string buscarSalaActual(string nombreUsuario, string contraseña)
    {
       Jugador jugador = new Jugador();
       string salaActual = "";
      using(SqlConnection connection = new SqlConnection(_connectionString))
         {
            string query = "SELECT salaActual FROM Jugadores WHERE Jugadores.NombreUsuario = @PnombreUsuario AND Jugadores.Contraseña = @Pcontraseña";
            salaActual = connection.QueryFirstOrDefault<string>(query, new {PsalaActual = salaActual, PnombreUsuario = nombreUsuario, Pcontraseña = contraseña});
         } 
         return salaActual;
    }
    // metodo que compruebe si el jugador ya existe en la base de datos
    public bool ExisteJugador(string nombreUsuario)
    {
        using(SqlConnection connection = new SqlConnection(_connectionString))
        {
            string query = "SELECT COUNT(*) FROM Jugadores WHERE NombreUsuario = @PnombreUsuario";
            int count = connection.ExecuteScalar<int>(query, new {PnombreUsuario = nombreUsuario});
            return count > 0;
        }
    }
}   