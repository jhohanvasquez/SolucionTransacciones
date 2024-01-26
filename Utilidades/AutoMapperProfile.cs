using AppTransacciones.DTOs;
using AppTransacciones.Models;
using AutoMapper;
using System.Globalization;

namespace AppTransacciones.Utilidades
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            #region Rol
            CreateMap<Rol, RolDTO>().ReverseMap();
            #endregion Rol

            #region Usuario
            CreateMap<Usuario, UsuarioDTO>()
                .ForMember(destino =>
                    destino.rolDescripcion,
                    opt => opt.MapFrom(origen => origen.idRolNavigation.descripcion ?? string.Empty)
                );

            CreateMap<UsuarioDTO, Usuario>()
            .ForMember(destino =>
                destino.idRolNavigation,
                opt => opt.Ignore()
            );
            #endregion Usuario           

        }

    }
}
