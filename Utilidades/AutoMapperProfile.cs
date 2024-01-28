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
            //CreateMap<Transaccion, TransaccionDTO>()
            //    .ForMember(destino =>
            //        destino.TotalTexto,
            //        opt => opt.MapFrom(origen => Convert.ToString(origen.Total.Value, new CultureInfo("es-PE")))
            //    ).ForMember(destino =>
            //        destino.FechaRegistro,
            //        opt => opt.MapFrom(origen => origen.FechaRegistro.Value.ToString("dd/MM/yyyy"))
            //    );

            //CreateMap<TransaccionDTO, Transaccion>()
            //    .ForMember(destino =>
            //        destino.Total,
            //        opt => opt.MapFrom(origen => Convert.ToDecimal(origen.TotalTexto, new CultureInfo("es-PE")))
            //    );

            #endregion Transaccion


            //#region DetalleTransaccion
            //CreateMap<DetalleTransaccion, DetalleTransaccionDTO>()
            //    .ForMember(destino =>
            //        destino.DescripcionComercio,
            //        opt => opt.MapFrom(origen => origen.IdComercioNavigation.Nombre)
            //    )
            //    .ForMember(destino =>
            //        destino.PrecioTexto,
            //        opt => opt.MapFrom(origen => Convert.ToString(origen.Precio.Value, new CultureInfo("es-PE")))
            //    )
            //    .ForMember(destino =>
            //        destino.TotalTexto,
            //        opt => opt.MapFrom(origen => Convert.ToString(origen.Total.Value, new CultureInfo("es-PE")))
            //    );

            //CreateMap<DetalleTransaccionDTO, DetalleTransaccion>()
            //    .ForMember(destino =>
            //        destino.Precio,
            //        opt => opt.MapFrom(origen => Convert.ToDecimal(origen.PrecioTexto, new CultureInfo("es-PE")))
            //    )
            //    .ForMember(destino =>
            //        destino.Total,
            //        opt => opt.MapFrom(origen => Convert.ToDecimal(origen.TotalTexto, new CultureInfo("es-PE")))
            //    );
            //#endregion      

        }

    }
}
