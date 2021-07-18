using SIstemaFarmaciaFinal.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;

namespace SIstemaFarmaciaFinal.Controllers
{
    public class MedicamentosController : Controller
    {
        private readonly string CadenaConexion;

        public MedicamentosController(IConfiguration configuration)
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
            Medicamento Med = new();


            if (Id == null)
            {
                return View(Med);
            }
            else
            {
                using SqlConnection sql = new SqlConnection(CadenaConexion);
                using SqlCommand cmd = new SqlCommand("MedicamentoxCodigo", sql);

                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@codMedicamento", Id)); //  se usa el id usado en el procedimiento de la base
                Med = null;
                await sql.OpenAsync();

                using var reader = await cmd.ExecuteReaderAsync();
                while (await reader.ReadAsync())
                {
                    Med = new Medicamento()
                    {
                        CodMedicamentos = (int)reader["cod_Medicamentos"],
                        NombreGenerico = reader["nombreGenerico"].ToString(),
                        Estado = reader["estado"].ToString(), //  Se pone el nombre exacto que esta en la tabla de la bd                        
                        ViaAdministracion = reader["viaAdministracion"].ToString(),
                        IdCategoria = (int)reader["id_Categoria"],
                        IdInventario = (int)reader["id_Inventario"]
                      
                        //Estado = (bool)reader["Estado"]
                    };
                }

                return View(Med);

            }
        }

        [HttpPost]//implicitamente es get para que sea post al que agregarselo
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Crear(Medicamento Med)
        {
            if (ModelState.IsValid) //valida si el modelo es correcto
            {
                using SqlConnection sql = new SqlConnection(CadenaConexion);

                using SqlCommand cmd = new SqlCommand("MedicamentosGuardar", sql);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@codigo", Med.CodMedicamentos));  //  estos son los nombres de los parametros del procedimiento almacenado
                cmd.Parameters.Add(new SqlParameter("@nombreGenerico", Med.NombreGenerico));
                cmd.Parameters.Add(new SqlParameter("@estado", Med.Estado));
                cmd.Parameters.Add(new SqlParameter("@viaAdministracion", Med.ViaAdministracion));
                cmd.Parameters.Add(new SqlParameter("@idCategoria", Med.IdCategoria));
                cmd.Parameters.Add(new SqlParameter("@idInventario", Med.IdInventario));
                
                //cmd.Parameters.Add(new SqlParameter("@estado", Med.Estado));
                await sql.OpenAsync();
                await cmd.ExecuteNonQueryAsync();

                return RedirectToAction(nameof(Crear), new { Id = 0 });

            }
            return View(Med);
        }


        [HttpGet]
        public async Task<IActionResult> Todas()
        {
            using SqlConnection sql = new SqlConnection(CadenaConexion);

            using SqlCommand cmd = new SqlCommand("spMostrarMedicamentos", sql);

            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            var response = new List<Medicamento>();
            await sql.OpenAsync();

            using (var reader = await cmd.ExecuteReaderAsync())
            {
                while (await reader.ReadAsync())
                {
                    response.Add(new Medicamento()
                    {
                        CodMedicamentos = (int)reader["cod_Medicamentos"],
                        NombreGenerico = reader["nombreGenerico"].ToString(),
                        Estado = reader["estado"].ToString(), //  Se pone el nombre exacto que esta en la tabla de la bd                        
                        ViaAdministracion = reader["viaAdministracion"].ToString(),
                        IdCategoria = (int)reader["id_Categoria"],
                        IdInventario = (int)reader["id_Inventario"]
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
                using (SqlCommand cmd = new SqlCommand("EliminarMedicamento", sql))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@codMedicamentos", Id));
                    await sql.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();
                    return View();
                }
            }
        }
    }
}
