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

            #region MedioPago
            CreateMap<MedioPago, MedioPagoDTO>().ReverseMap();
            #endregion MedioPago

            #region Transaccion
            CreateMap<Transaccion, TransaccionDTO>()
                .ForMember(destino =>
                    destino.descripcionComercio,
                    opt => opt.MapFrom(origen => origen.idMedioNavigation.descripcion ?? string.Empty)
                );

            CreateMap<TransaccionDTO, Transaccion>()
            .ForMember(destino =>
                destino.idMedioNavigation,
                opt => opt.Ignore()
            );
            #endregion Transaccion

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

            #region Comercio
            CreateMap<Comercio, ComercioDTO>();

            CreateMap<ComercioDTO, Comercio>();
            #endregion Comercio


            #region Transaccion
            CreateMap<Transaccion, TransaccionDTO>()
                .ForMember(destino =>
                    destino.total,
                    opt => opt.MapFrom(origen => Convert.ToString(origen.total, new CultureInfo("es-PE")))
                ).ForMember(destino =>
                    destino.fecha,
                    opt => opt.MapFrom(origen => origen.fecha)
                );

            CreateMap<TransaccionDTO, Transaccion>()
                .ForMember(destino =>
                    destino.total,
                    opt => opt.MapFrom(origen => Convert.ToDecimal(origen.total, new CultureInfo("es-PE")))
                );

            #endregion Transaccion


        }

    }
}
