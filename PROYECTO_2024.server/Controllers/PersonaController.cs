using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PROYECTO_2024.BD.DATA.ENTITY;
using PROYECTO_2024.BD.DATA;
using PROYECTO_2024.Shared.DTO;
using Microsoft.EntityFrameworkCore;

namespace PROYECTO_2024.server.Controllers
{
    [ApiController]
    [Route("api/PersonaController")]

    public class PersonaController: ControllerBase
    {
        private readonly Context context;
        private readonly IMapper mapper;

        public PersonaController(Context context,
                                       IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }
        //
        [HttpGet]
        public async Task<ActionResult<List<Persona>>> Get()
        {
            return await context.Personas.ToListAsync();
        }

        // Select con where que busca por ID 
        [HttpGet("{id:int}")]
        public async Task<ActionResult<Persona>> Get(int id)
        {
            Persona? pepe = await context.Personas.FirstOrDefaultAsync(x => x.ID == id);

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

            var existe = await context.Personas.AnyAsync(x => x.ID == id);
            return existe;
        }

        // select buscando por nombre
        [HttpGet("{nombre}")]
        public async Task<ActionResult<Persona>> GetByCod(string nombre)
        {
            Persona? pepe = await context.Personas.FirstOrDefaultAsync(x => x.Nombre == nombre);

            if (pepe == null)
            {
                return NotFound();
            }
            return pepe;
        }

        // get nomas
        /// //////////////////////////////////////////////////////////////////////////

        [HttpPost]
        public async Task<ActionResult<int>> Post([FromBody] CrearPersonaDTO entidadDTO)// Mapper mapper)
        {
            try
            {
                 
                //ESTO SUBE LAS ENTIDADES QUE PUSE EN EL DTO CREAR PERSONA
                Persona entidad = mapper.Map<Persona>(entidadDTO);

                context.Personas.Add(entidad);
                await context.SaveChangesAsync();
                return entidad.ID;
            }

            catch (Exception err)
            {
                return BadRequest(err.InnerException.Message);
            }
        }

        //
        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(int id, [FromBody] Persona entidad)
        {
            if (id != entidad.ID)
            {
                return BadRequest("Datos Incorrectos");
            }
            var pepe = await context.Personas.Where(e => e.ID == id).FirstOrDefaultAsync();
            if (pepe == null)
            {
                return NotFound("No existe el tipo de documento buscado");
            }
            pepe.Apellido = entidad.Apellido;
            pepe.Nombre = entidad.Nombre;
            pepe.Edad= entidad.Edad;    
            pepe.Localidad = entidad.Localidad; 
            pepe.Celular = entidad.Celular; 
            pepe.Correo = entidad.Correo;   
            pepe.Tdocumento = entidad.Tdocumento;

            try
            {
                context.Personas.Update(pepe);
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
            var existe = await context.Personas.AnyAsync(x => x.ID == id);
            if (!existe)
            {
                return NotFound($"El tipo de documento{id}no existe");
            }
            Persona entidadABorrar = new Persona();
            entidadABorrar.ID = id;

            context.Remove(entidadABorrar);
            await context.SaveChangesAsync();
            return Ok();
        }

    }

}

