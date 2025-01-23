using Microsoft.AspNetCore.Mvc;
using System;
using System.Data.SqlClient;
using DAL;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DatabaseController : ControllerBase
    {
        private readonly DatabaseConnection _dbConnection;

        public DatabaseController(DatabaseConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        [HttpGet("check-connection")]
        public IActionResult CheckDatabaseConnection()
        {
            try
            {
                using (var connection = _dbConnection.GetConnection())
                {
                    connection.Open();

                    if (connection.State == System.Data.ConnectionState.Open)
                    {
                        return Ok("Conexión exitosa a la base de datos.");
                    }
                    else
                    {
                        return StatusCode(500, "No se pudo abrir la conexión a la base de datos.");
                    }
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al intentar conectarse a la base de datos: {ex.Message}");
            }
        }
    }
}
