using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using PROYECTO_2024.BD.DATA;
using PROYECTO_2024.BD.DATA.ENTITY;

namespace PROYECTO_2024.server.Controllers
{
    [ApiController]
    [Route("api/Localidad")]

    public class TdocumentoController : ControllerBase
    {
        private readonly Context context;

        public TdocumentoController(Context context)
        {
            this.context = context;
        }
        //
        [HttpGet]
        public async Task<ActionResult<List<Tdocumento>>> Get()
        {
            return await context.Tdocumentos.ToListAsync();
        }

        // Select con where que busca por ID 
        [HttpGet("{id:int}")]
        public async Task<ActionResult<Tdocumento>> Get(int id)
        {
           Tdocumento? pepe = await context.Tdocumentos.FirstOrDefaultAsync(x => x.ID == id);   
            
            if (pepe == null )
            {
                return NotFound();
            }
            return pepe;
        }

        // devuelve true o false
        [HttpGet("Existe/{id:int}")]  
        public async Task<ActionResult<bool>> Existe(int id)
        {
          
            var existe = await context.Tdocumentos.AnyAsync(x => x.ID  == id);
            return existe;
        }

        // select buscando por codigo
        [HttpGet("{cod}")]
        public async Task<ActionResult<Tdocumento>> GetByCod(string cod)
        {
            Tdocumento? pepe = await context.Tdocumentos.FirstOrDefaultAsync(x => x.codigo == cod);

            if (pepe == null)
            {
                return NotFound();
            }
            return pepe;
        }

        // get nomas
        /// //////////////////////////////////////////////////////////////////////////

        [HttpPost]
        public async Task<ActionResult<int>> Post(Tdocumento entidad)
        {
            try
            {
                context.Tdocumentos.Add(entidad);
                await context.SaveChangesAsync();
                return entidad.ID;
            }

            catch (Exception)
            {
                return BadRequest(entidad.Nombre);
            }
        }
        
        //
        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(int id, [FromBody] Tdocumento entidad)
        {
            if (id != entidad.ID)
            {
                return BadRequest("Datos Incorrectos");
            }
            var pepe = await context.Tdocumentos.Where(e => e.ID == id).FirstOrDefaultAsync();

            if (pepe == null)
            {
                return NotFound("No existe el tipo de documento buscado");
            }
            pepe.codigo = entidad.codigo;
            pepe.Nombre = entidad.Nombre;

            try
            {
                context.Tdocumentos.Update(pepe);
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
        public async Task<ActionResult> Delete (int id)
        {
            var existe = await context.Tdocumentos.AnyAsync(x => x.ID==id);
            if (!existe)
            {
                return NotFound($"El tipo de documento{id}no existe");  
            }
            Tdocumento entidadABorrar  = new Tdocumento();  
            entidadABorrar.ID = id; 

            context.Remove(entidadABorrar);
            await context.SaveChangesAsync();
            return Ok();
        }

    }
}