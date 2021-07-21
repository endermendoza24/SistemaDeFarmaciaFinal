using SIstemaFarmaciaFinal.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;

namespace SIstemaFarmaciaFinal.Controllers
{
    public class InventarioController : Controller
    {
        private readonly string CadenaConexion;

        public InventarioController(IConfiguration configuration)
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
            Inventario Inv = new();


            if (Id == null)
            {
                return View(Inv);
            }
            else
            {
                using SqlConnection sql = new SqlConnection(CadenaConexion);
                using SqlCommand cmd = new SqlCommand("InventarioxCodigo", sql);

                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@idInventario", Id)); //  se usa el id usado en el procedimiento de la base
                Inv = null;
                await sql.OpenAsync();

                using var reader = await cmd.ExecuteReaderAsync();
                while (await reader.ReadAsync())
                {
                    Inv = new Inventario()
                    {
                        IdInventario = (int)reader["idInventario"],
                        FechaEntradaInventario = reader["fechaEntradaInventario"].ToString(),
                        NombreComercial = reader["nombreComercial"].ToString(), //  Se pone el nombre exacto que esta en la tabla de la bd                        
                        StockInicial = (int)reader["StockInicial"],
                        Entradas = (int)reader["Entradas"],
                        Salidas = (int)reader["Salidas"],
                        StockActual = (int)reader["StockActual"],
                        PrecioPreventa = (float)reader["PrecioPreventa"],
                        CostoPreventa = (float)reader["CostoPreventa"],
                        IdPresentacionMed = (int)reader["idPresentacion_Med"],
                        IdLaboratorio = (int)reader["idLaboratorio"],
                        IdCompra = (int)reader["idCompra"]
                        //Estado = (bool)reader["Estado"]
                    };
                }

                return View(Inv);

            }
        }

        [HttpPost]//implicitamente es get para que sea post al que agregarselo
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Crear(Inventario Inv)
        {
            if (ModelState.IsValid) //valida si el modelo es correcto
            {
                using SqlConnection sql = new SqlConnection(CadenaConexion);

                using SqlCommand cmd = new SqlCommand("InventarioGuardar", sql);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@codigo", Inv.IdInventario));  //  estos son los nombres de los parametros del procedimiento almacenado
                cmd.Parameters.Add(new SqlParameter("@fecha", Inv.FechaEntradaInventario));
                cmd.Parameters.Add(new SqlParameter("@nombreComercial", Inv.NombreComercial));
                cmd.Parameters.Add(new SqlParameter("@stockInicial", Inv.StockInicial));
                cmd.Parameters.Add(new SqlParameter("@entradas", Inv.Entradas));
                cmd.Parameters.Add(new SqlParameter("@salidas", Inv.Salidas));
                cmd.Parameters.Add(new SqlParameter("@stockActual", Inv.StockActual));
                cmd.Parameters.Add(new SqlParameter("@precio", Inv.PrecioPreventa));
                cmd.Parameters.Add(new SqlParameter("@costo", Inv.CostoPreventa));
                cmd.Parameters.Add(new SqlParameter("@idPresentacion", Inv.IdPresentacionMed));
                cmd.Parameters.Add(new SqlParameter("@idLaboratorio", Inv.IdLaboratorio));
                cmd.Parameters.Add(new SqlParameter("@idCompra", Inv.IdCompra));

                //cmd.Parameters.Add(new SqlParameter("@estado", Inv.Estado));
                await sql.OpenAsync();
                await cmd.ExecuteNonQueryAsync();

                return RedirectToAction(nameof(Crear), new { Id = 0 });

            }
            return View(Inv);
        }


        [HttpGet]
        public async Task<IActionResult> Todas()
        {
            using SqlConnection sql = new SqlConnection(CadenaConexion);

            using SqlCommand cmd = new SqlCommand("spMostrarInventario", sql);

            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            var response = new List<Inventario>();
            await sql.OpenAsync();

            using (var reader = await cmd.ExecuteReaderAsync())
            {
                while (await reader.ReadAsync())
                {
                    response.Add(new Inventario()
                    {
                        IdInventario = (int)reader["idInventario"],
                        FechaEntradaInventario = reader["fechaEntradaInventario"].ToString(),
                        NombreComercial = reader["nombreComercial"].ToString(), //  Se pone el nombre exacto que esta en la tabla de la bd                        
                        StockInicial = (int)reader["StockInicial"],
                        Entradas = (int)reader["Entradas"],
                        Salidas = (int)reader["Salidas"],
                        StockActual = (int)reader["StockActual"],
                        PrecioPreventa = (float)reader["PrecioPreventa"],
                        CostoPreventa = (float)reader["CostoPreventa"],
                        IdPresentacionMed = (int)reader["idPresentacionMed"],
                        IdLaboratorio = (int)reader["idLaboratorio"],
                        IdCompra = (int)reader["idCompra"]
                    });
                }
            }
            return Json(new { data = response });

        }

        public async Task<IActionResult> Eliminar(int Id)
        {
            using (SqlConnection sql = new SqlConnection(CadenaConexion))
            {
                using (SqlCommand cmd = new SqlCommand("EliminarInventario", sql))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@idInventario", Id));
                    await sql.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();
                    return View();
                }
            }
        }
    }
}
