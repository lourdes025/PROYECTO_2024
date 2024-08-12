using AutoMapper;
using PROYECTO_2024.BD.DATA.ENTITY;
using PROYECTO_2024.Shared.DTO;

namespace PROYECTO_2024.server.Util
{
    public class AutoMapperProfiles: Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<CrearLocalidadDTO, Localidad>();
            CreateMap<CrearPersonaDTO, Persona>();
            
        }
    }
}
