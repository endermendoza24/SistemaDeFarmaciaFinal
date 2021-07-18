using SIstemaFarmaciaFinal.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;

namespace SIstemaFarmaciaFinal.Controllers
{
    public class PersonalController : Controller
    {
        private readonly string CadenaConexion;

        public PersonalController(IConfiguration configuration)
        {
            CadenaConexion = configuration.GetConnectionString("DefaultConnection");
        }
        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public async Task<IActionResult> Crear(int? Id) //puede o recibir parametro
        {
            Personal Per = new();


            if (Id == null)
            {
                return View(Per);
            }
            else
            {
                using SqlConnection sql = new SqlConnection(CadenaConexion);
                using SqlCommand cmd = new SqlCommand("PersonalxCodigo", sql);

                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@idPersonal", Id)); //  se usa el id usado en el procedimiento de la base
                Per = null;
                await sql.OpenAsync();

                using var reader = await cmd.ExecuteReaderAsync();
                while (await reader.ReadAsync())
                {
                    Per = new Personal()
                    {
                        IdPersonal = (int)reader["id_Personal"],
                        Nombre = reader["nombre"].ToString(),
                        PrimerApellido = reader["primerApellido"].ToString(), //  Se pone el nombre exacto que esta en la tabla de la bd
                        SegundoApellido = reader["segundoApellido"].ToString(),
                        Direccion = reader["direccion"].ToString(),
                        Telefono = reader["telefono"].ToString(),
                        Email = reader["email"].ToString()
                        //Estado = (bool)reader["Estado"]
                    };
                }

                return View(Per);

            }
        }

        [HttpPost]//implicitamente es get para que sea post al que agregarselo
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Crear(Personal Per)
        {
            if (ModelState.IsValid) //valida si el modelo es correcto
            {
                using SqlConnection sql = new SqlConnection(CadenaConexion);

                using SqlCommand cmd = new SqlCommand("PersonalGuardar", sql);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@codigo", Per.IdPersonal));  //  estos son los nombres de los parametros del procedimiento almacenado
                cmd.Parameters.Add(new SqlParameter("@nombre", Per.Nombre));
                cmd.Parameters.Add(new SqlParameter("@primerApellido", Per.PrimerApellido));
                cmd.Parameters.Add(new SqlParameter("@segundoApellido", Per.SegundoApellido));
                cmd.Parameters.Add(new SqlParameter("@direccion", Per.Direccion));
                cmd.Parameters.Add(new SqlParameter("@telefono", Per.Telefono));
                cmd.Parameters.Add(new SqlParameter("@email", Per.Email));
                //cmd.Parameters.Add(new SqlParameter("@estado", Per.Estado));
                await sql.OpenAsync();
                await cmd.ExecuteNonQueryAsync();

                return RedirectToAction(nameof(Crear), new { Id = 0 });

            }
            return View(Per);
        }


        [HttpGet]
        public async Task<IActionResult> Todas()
        {
            using SqlConnection sql = new SqlConnection(CadenaConexion);

            using SqlCommand cmd = new SqlCommand("spMostrarTodoElPersonal", sql);

            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            var response = new List<Personal>();
            await sql.OpenAsync();

            using (var reader = await cmd.ExecuteReaderAsync())
            {
                while (await reader.ReadAsync())
                {
                    response.Add(new Personal()
                    {
                        IdPersonal = (int)reader["id_Personal"],
                        Nombre = reader["nombre"].ToString(), //  nombre exacto con el que sale en la tabakla de la abse de datos
                        PrimerApellido = reader["primerApellido"].ToString(),
                        SegundoApellido = reader["segundoApellido"].ToString(),
                        Direccion = reader["direccion"].ToString(),
                        Telefono = reader["telefono"].ToString(),
                        Email = reader["email"].ToString()
                        //Estado = (bool)reader["Estado"]
                    });
                }
            }
            return Json(new { data = response });

        }

        public async Task<IActionResult> Eliminar(int Id)
        {
            using (SqlConnection sql = new SqlConnection(CadenaConexion))
            {
                using (SqlCommand cmd = new SqlCommand("EliminarPersonal", sql))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@idPersonal", Id));
                    await sql.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();
                    return View();
                }
            }
        }
    }
}
