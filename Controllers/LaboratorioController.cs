using SIstemaFarmaciaFinal.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;

namespace SIstemaFarmaciaFinal.Controllers
{
    public class LaboratorioController : Controller
    {
        private readonly string CadenaConexion;

        public LaboratorioController(IConfiguration configuration)
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
            Laboratorio Lab = new();


            if (Id == null)
            {
                return View(Lab);
            }
            else
            {
                using SqlConnection sql = new SqlConnection(CadenaConexion);
                using SqlCommand cmd = new SqlCommand("LaboratorioxCodigo", sql);

                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@idLaboratorio", Id)); //  se usa el id usado en el procedimiento de la base
                Lab = null;
                await sql.OpenAsync();

                using var reader = await cmd.ExecuteReaderAsync();
                while (await reader.ReadAsync())
                {
                    Lab = new Laboratorio()
                    {
                        IdLaboratorio = (int)reader["id_Laboratorio"],
                        NombreLaboratorio = reader["nombre_Laboratorio"].ToString(),
                        TelefonoLaboratorio = reader["telefono_Laboratorio"].ToString(), //  Se pone el nombre exacto que esta en la tabla de la bd                        
                        Direccion = reader["direccion"].ToString(),
                        EmailLab = reader["email_Lab"].ToString(),
                        PoliticasDeVencimiento = reader["politicasDeVencimiento"].ToString()
                        //Estado = (bool)reader["Estado"]
                    };
                }

                return View(Lab);

            }
        }

        [HttpPost]//implicitamente es get para que sea post al que agregarselo
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Crear(Laboratorio Lab)
        {
            if (ModelState.IsValid) //valida si el modelo es correcto
            {
                using SqlConnection sql = new SqlConnection(CadenaConexion);

                using SqlCommand cmd = new SqlCommand("LaboratorioGuardar", sql);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@codigo", Lab.IdLaboratorio));  //  estos son los nombres de los parametros del procedimiento almacenado
                cmd.Parameters.Add(new SqlParameter("@nombre", Lab.NombreLaboratorio));
                cmd.Parameters.Add(new SqlParameter("@telefono", Lab.TelefonoLaboratorio));
                cmd.Parameters.Add(new SqlParameter("@direccion", Lab.Direccion));              
                cmd.Parameters.Add(new SqlParameter("@email", Lab.EmailLab));
                cmd.Parameters.Add(new SqlParameter("@politicas", Lab.PoliticasDeVencimiento));
                //cmd.Parameters.Add(new SqlParameter("@estado", Lab.Estado));
                await sql.OpenAsync();
                await cmd.ExecuteNonQueryAsync();

                return RedirectToAction(nameof(Crear), new { Id = 0 });

            }
            return View(Lab);
        }


        [HttpGet]
        public async Task<IActionResult> Todas()
        {
            using SqlConnection sql = new SqlConnection(CadenaConexion);

            using SqlCommand cmd = new SqlCommand("spMostrarTodoLosLaboratorios", sql);

            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            var response = new List<Laboratorio>();
            await sql.OpenAsync();

            using (var reader = await cmd.ExecuteReaderAsync())
            {
                while (await reader.ReadAsync())
                {
                    response.Add(new Laboratorio()
                    {
                        IdLaboratorio = (int)reader["id_Laboratorio"],
                        NombreLaboratorio = reader["nombre_Laboratorio"].ToString(), //  nombre exacto con el que sale en la tabakla de la abse de datos
                        TelefonoLaboratorio = reader["telefono_Laboratorio"].ToString(),                   
                        Direccion = reader["direccion"].ToString(),
                        EmailLab = reader["email_Lab"].ToString(),
                        PoliticasDeVencimiento = reader["politicasDeVencimiento"].ToString()
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
                using (SqlCommand cmd = new SqlCommand("EliminarLaboratorio", sql))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@idLaboratorio", Id));
                    await sql.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();
                    return View();
                }
            }
        }
    }
}
