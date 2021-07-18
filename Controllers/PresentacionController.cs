using SIstemaFarmaciaFinal.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;

namespace SIstemaFarmaciaFinal.Controllers
{
    public class PresentacionController : Controller
    {
        private readonly string CadenaConexion;

        public PresentacionController(IConfiguration configuration)
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
            PresentacionMedicamento Pre = new();


            if (Id == null)
            {
                return View(Pre);
            }
            else
            {
                using SqlConnection sql = new SqlConnection(CadenaConexion);
                using SqlCommand cmd = new SqlCommand("PresentacionxCodigo", sql);

                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@idPresentacion", Id)); //  se usa el id usado en el procedimiento de la base
                Pre = null;
                await sql.OpenAsync();

                using var reader = await cmd.ExecuteReaderAsync();
                while (await reader.ReadAsync())
                {
                    Pre = new PresentacionMedicamento()
                    {
                        IdPresentacionMed = (int)reader["id_PresentacionMed"],
                        UnidadEnvasado = reader["unidadEnvasado"].ToString(),
                        FormaPresentacion = reader["formaPresentacion"].ToString(), //  Se pone el nombre exacto que esta en la tabla de la bd                        
                        Concentracion = reader["concentracion"].ToString(),
                        UnidadMedidaPresentacion = reader["unidadMedidaPresentacion"].ToString(),
                        Unidades = reader["Unidades"].ToString(),
                        SubUnidades = reader["subUnidades"].ToString()
                        //Estado = (bool)reader["Estado"]
                    };
                }

                return View(Pre);

            }
        }

        [HttpPost]//implicitamente es get para que sea post al que agregarselo
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Crear(PresentacionMedicamento Pre)
        {
            if (ModelState.IsValid) //valida si el modelo es correcto
            {
                using SqlConnection sql = new SqlConnection(CadenaConexion);

                using SqlCommand cmd = new SqlCommand("PresentacionGuardar", sql);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@codigo", Pre.IdPresentacionMed));  //  estos son los nombres de los parametros del procedimiento almacenado
                cmd.Parameters.Add(new SqlParameter("@unidadEnvasado", Pre.UnidadEnvasado));
                cmd.Parameters.Add(new SqlParameter("@formaPresentacion", Pre.FormaPresentacion));
                cmd.Parameters.Add(new SqlParameter("@concentracion", Pre.Concentracion));
                cmd.Parameters.Add(new SqlParameter("@unidadMedida", Pre.UnidadMedidaPresentacion));
                cmd.Parameters.Add(new SqlParameter("@unidades", Pre.Unidades));
                cmd.Parameters.Add(new SqlParameter("@subUnidades", Pre.SubUnidades));
                //cmd.Parameters.Add(new SqlParameter("@estado", Pre.Estado));
                await sql.OpenAsync();
                await cmd.ExecuteNonQueryAsync();

                return RedirectToAction(nameof(Crear), new { Id = 0 });

            }
            return View(Pre);
        }


        [HttpGet]
        public async Task<IActionResult> Todas()
        {
            using SqlConnection sql = new SqlConnection(CadenaConexion);

            using SqlCommand cmd = new SqlCommand("spMostrarPresentaciones", sql);

            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            var response = new List<PresentacionMedicamento>();
            await sql.OpenAsync();

            using (var reader = await cmd.ExecuteReaderAsync())
            {
                while (await reader.ReadAsync())
                {
                    response.Add(new PresentacionMedicamento()
                    {
                        IdPresentacionMed = (int)reader["id_PresentacionMed"],
                        UnidadEnvasado = reader["unidadEnvasado"].ToString(), //  nombre exacto con el que sale en la tabla de la base de datos
                        FormaPresentacion = reader["formaPresentacion"].ToString(),
                        Concentracion = reader["concentracion"].ToString(),
                        UnidadMedidaPresentacion = reader["unidadMedidaPresentacion"].ToString(),
                        Unidades = reader["Unidades"].ToString(),
                        SubUnidades = reader["subUnidades"].ToString()
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
                using (SqlCommand cmd = new SqlCommand("EliminarPresentacionMed", sql))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@idPresentacion", Id));
                    await sql.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();
                    return View();
                }
            }
        }
    }
}
