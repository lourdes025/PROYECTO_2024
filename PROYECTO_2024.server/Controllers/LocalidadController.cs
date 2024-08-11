using Microsoft.AspNetCore.Mvc;
using PROYECTO_2024.BD.DATA.ENTITY;
using PROYECTO_2024.BD.DATA;
using Microsoft.EntityFrameworkCore;
using PROYECTO_2024.Shared.DTO;

namespace PROYECTO_2024.server.Controllers
{
    [ApiController]
    [Route("api/LocalidadController")]

    public class LocalidadController : ControllerBase
    {
        private readonly Context context;

        public LocalidadController(Context context)
        {
            this.context = context;
        }
        //
        [HttpGet]
        public async Task<ActionResult<List<Localidad>>> Get()
        {
            return await context.Localidades.ToListAsync();
        }

        // Select con where que busca por ID 
        [HttpGet("{id:int}")]
        public async Task<ActionResult<Localidad>> Get(int id)
        {
            Localidad? pepe = await context.Localidades.FirstOrDefaultAsync(x => x.ID == id);

            if (pepe == null)
            {
                return NotFound();
            }
            return pepe;
        }

        // devuelve true o false
        [HttpGet("Existe/{id:int}")]
        public async Task<ActionResult<bool>> Existe(int id)
        {

            var existe = await context.Localidades.AnyAsync(x => x.ID == id);
            return existe;
        }

        // select buscando por codigo
        [HttpGet("{cod}")]
        public async Task<ActionResult<Localidad>> GetByCod(string cod)
        {
            Localidad? pepe = await context.Localidades.FirstOrDefaultAsync(x => x.codigo == cod);

            if (pepe == null)
            {
                return NotFound();
            }
            return pepe;
        }

        // get nomas
        /// //////////////////////////////////////////////////////////////////////////

        [HttpPost]
        public async Task<ActionResult<int>> Post(CrearLocalidadDTO entidadDTO)
        {
            try
            {
                Localidad entidad = new Localidad();
                entidad.codigo= entidadDTO.codigo;
                entidad.Nombre= entidadDTO.Nombre;  


                context.Localidades.Add(entidad);
                await context.SaveChangesAsync();
                return entidad.ID;
            }

            catch (Exception err)
            {
                return BadRequest( err.InnerException.Message);
            }
        }

        //
        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(int id, [FromBody] Localidad entidad)
        {
            if (id != entidad.ID)
            {
                return BadRequest("Datos Incorrectos");
            }
            var pepe = await context.Localidades.Where(e => e.ID == id).FirstOrDefaultAsync();
            if (pepe == null)
            {
                return NotFound("No existe el tipo de documento buscado");
            }
            pepe.codigo = entidad.codigo;
            pepe.Nombre = entidad.Nombre;

            try
            {
                context.Localidades.Update(pepe);
                await context.SaveChangesAsync();
                return Ok();
            }
            catch (Exception)
            {

                return BadRequest(entidad.Nombre);
            }

        }

        //
        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var existe = await context.Localidades.AnyAsync(x => x.ID == id);
            if (!existe)
            {
                return NotFound($"El tipo de documento{id}no existe");
            }
            Localidad entidadABorrar = new Localidad();
            entidadABorrar.ID = id;

            context.Remove(entidadABorrar);
            await context.SaveChangesAsync();
            return Ok();
        }

    }
}

