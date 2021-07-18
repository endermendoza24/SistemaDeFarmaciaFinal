using SIstemaFarmaciaFinal.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;


namespace SIstemaFarmaciaFinal.Controllers
{
    public class CategoriasController : Controller
    {
        private readonly string CadenaConexion;

        public CategoriasController(IConfiguration configuration)
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
            CategoriaMedicamento Cat = new();


            if (Id == null)
            {
                return View(Cat);
            }
            else
            {
                using SqlConnection sql = new SqlConnection(CadenaConexion);
                using SqlCommand cmd = new SqlCommand("spCategoriaxCodigo", sql);

                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@idCategoria", Id)); //  se usa el id usado en el procedimiento de la base
                Cat = null;
                await sql.OpenAsync();

                using var reader = await cmd.ExecuteReaderAsync();
                while (await reader.ReadAsync())
                {
                    Cat = new CategoriaMedicamento()
                    {
                        IdCategoria = (int)reader["id_Categoria"],
                        NombreCategoria = reader["nombre_Categoria"].ToString(),
                        DescripcionCategoria = reader["descripcion_Categoria"].ToString() //  Se pone el nombre exacto que esta en la tabla de la bd
                        //Estado = (bool)reader["Estado"]
                    };
                }

                return View(Cat);

            }
        }

        [HttpPost]//implicitamente es get para que sea post al que agregarselo
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Crear(CategoriaMedicamento Cat)
        {
            if (ModelState.IsValid) //valida si el modelo es correcto
            {
                using SqlConnection sql = new SqlConnection(CadenaConexion);

                using SqlCommand cmd = new SqlCommand("CategoriaGuardar", sql);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@codigo", Cat.IdCategoria));  //  estos son los nombres de los parametros del procedimiento almacenado
                cmd.Parameters.Add(new SqlParameter("@nombre", Cat.NombreCategoria));
                cmd.Parameters.Add(new SqlParameter("@descripcion", Cat.DescripcionCategoria));
                //cmd.Parameters.Add(new SqlParameter("@estado", Cat.Estado));
                await sql.OpenAsync();
                await cmd.ExecuteNonQueryAsync();

                return RedirectToAction(nameof(Crear), new { Id = 0 });

            }
            return View(Cat);
        }


        [HttpGet]
        public async Task<IActionResult> Todas()
        {
            using SqlConnection sql = new SqlConnection(CadenaConexion);

            using SqlCommand cmd = new SqlCommand("spMostrarTodasLasCategorias", sql);

            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            var response = new List<CategoriaMedicamento>();
            await sql.OpenAsync();

            using (var reader = await cmd.ExecuteReaderAsync())
            {
                while (await reader.ReadAsync())
                {
                    response.Add(new CategoriaMedicamento()
                    {
                        IdCategoria = (int)reader["id_Categoria"],
                        NombreCategoria = reader["nombre_Categoria"].ToString(),
                        DescripcionCategoria = reader["descripcion_Categoria"].ToString(),
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
                using (SqlCommand cmd = new SqlCommand("EliminarCategoria", sql))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@id_Categoria", Id));
                    await sql.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();
                    return View();
                }
            }
        }
    }
}
