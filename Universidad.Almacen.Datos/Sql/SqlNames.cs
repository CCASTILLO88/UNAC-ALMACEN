using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace Universidad.Almacen.Datos.Sql
{
    public class SqlNames
    {
        public static class MAE
        {
            //PENDIENTE CREACION DE STORED PROCEDURES EN SQL SERVER
            public const string Articulo_Listar = "MAE.USP_LISTAR_ARTICULO";
            public const string Articulo_Obtener = "MAE.USP_OBTENER_ARTICULO";
            public const string Articulo_Registrar = "MAE.USP_REGISTRAR_ARTICULO";
            public const string Articulo_Eliminar = "MAE.USP_ELIMINAR_ARTICULO";
            public const string Articulo_Modificar = "MAE.USP_MODIFICAR_ARTICULO";

            public const string Proveedor_Listar = "MAE.USP_LISTAR_PROVEEDOR";
            public const string Proveedor_Obtener = "MAE.USP_OBTENER_PROVEEDOR";
            public const string Proveedor_Eliminar = "MAE.USP_ELIMINAR_PROVEEDOR";
            public const string Proveedor_Modificar = "MAE.USP_MODIFICAR_PROVEEDOR";

            public const string Servicio_Listar = "MAE.USP_LISTAR_SERVICIO";
            public const string Servicio_Obtener = "MAE.USP_OBTENER_SERVICIO";
            public const string Servicio_Registrar = "MAE.USP_REGISTRAR_SERVICIO";
            public const string Servicio_Eliminar = "MAE.USP_ELIMINAR_SERVICIO";
            public const string Servicio_Modificar = "MAE.USP_MODIFICAR_SERVICIO";

            //YA ESTAN EN EL SQL SERVER
            public const string UnidadMedida_Listar = "MAE.USP_LISTAR_UM";
            public const string UnidadMedida_Obtener = "MAE.USP_OBTENER_UM";
            public const string UnidadMedida_Registar = "MAE.USP_REGISTRAR_UM";
            public const string UnidadMedida_Eliminar = "MAE.USP_ELIMINAR_UM";
            public const string UnidadMedida_Modificar = "MAE.USP_MODIFICAR_UM";
            public const string UnidadMedida_ListarxDescripcion = "MAE.USP_LISTAR_UM_X_DSC";

            public const string Categoria_Listar = "MAE.USP_LISTAR_CATEGORIA";
            public const string Categoria_Eliminar = "MAE.USP_ELIMINAR_CATEGORIA";
            public const string Categoria_Registrar = "MAE.USP_REGISTRAR_CATEGORIA";
            public const string Categoria_Modificar = "MAE.USP_MODIFICAR_CATEGORIA";
            public const string Categoria_Obtener = "MAE.USP_OBTENER_CATEGORIA";

            public const string Persona_Registrar = "MAE.USP_REGISTRAR_PERSONA";
            public const string Persona_Eliminar = "MAE.USP_ELIMINAR_PERSONA";
            public const string Persona_Listar = "MAE.USP_LISTAR_PERSONA";
            public const string Persona_ListarxDoc = "MAE.USP_LISTAR_PERSONA_X_DOC";
            public const string Persona_Modificar = "MAE.USP_MODIFICAR_PERSONA";
            public const string Persona_Obtener = "MAE.USP_OBTENER_PERSONA";

            //YA ESTAN EN EL SQL SERVER , PERO NO IMPLEMENTADAS
            public const string Proveedor_Registrar = "MAE.USP_REGISTRAR_PROVEEDOR";

        }

        public static class  ALM
        {
            //PENDIENTE CREACION DE STORED PROCEDURES EN SQL SERVER
            public const string Almacen_Listar = "ALM.USP_LISTAR_ALMACEN";
            public const string Almacen_Obtener = "ALM.USP_OBTENER_ALMACEN";
            public const string Almacen_Registrar = "ALM.USP_REGISTRAR_ALMACEN";
            public const string Almacen_Eliminar = "ALM.USP_ELIMINAR_ALMACEN";
            public const string Almacen_Modificar = "ALM.USP_MODIFICAR_ALMACEN";

            public const string AlmacenVirtual_Listar = "ALM.USP_LISTAR_ALMACEN_VIRTUAL";
            public const string AlmacenVirtual_Obtener = "ALM.USP_OBTENER_ALMACEN_VIRTUAL";
            public const string AlmacenVirtual_Registrar = "ALM.USP_REGISTRAR_ALMACEN_VIRTUAL";
            public const string AlmacenVirtual_Eliminar = "ALM.USP_ELIMINAR_ALMACEN_VIRTUAL";
            public const string AlmacenVirtual_Modificar = "ALM.USP_MODIFICAR_ALMACEN_VIRTUAL";

            public const string Kardex_Listar_Movimientos_Por_RangoFechas = "ALM.USP_LISTAR_KARDEX_POR_RANGOFECHAS";
            public const string Kardex_Listar_Movimientos_Por_AlmacenYArticulo_X_RangoFechas = "ALM.USP_LISTAR_KARDEX_POR_ALMACENYARTICULO_X_RANGOFECHAS";
            public const string Kardex_Listar_Movimientos_Por_UnidadOrganicaYArticulo_X_RangoFechas = "ALM.USP_LISTAR_KARDEX_POR_UNIDADORGANICAYARTICULO_X_RANGOFECHAS";
            public const string Kardex_Registrar_Movimiento = "ALM.USP_REGISTRAR_KARDEX_MOVIMIENTO";
            public const string Kardex_Obtener_Saldo_Actual = "ALM.USP_OBTENER_SALDO_ACTUAL_KARDEX";
            public const string Kardex_Listar_Movimientos_Por_Articulo = "ALM.USP_LISTAR_MOVIMIENTOS_POR_ARTICULO";
            public const string Kardex_Listar_Movimientos_Por_Almacen = "ALM.USP_LISTAR_MOVIMIENTOS_POR_ALMACEN";
            public const string Kardex_Listar_Movimientos_Por_TipoMovimiento = "ALM.USP_LISTAR_MOVIMIENTOS_POR_TIPOMOVIMIENTO";
            public const string Kardex_Listar_Movimientos_Por_Usuario = "ALM.USP_LISTAR_MOVIMIENTOS_POR_USUARIO";
            public const string Kardex_Listar_Movimientos_Por_Proveedor = "ALM.USP_LISTAR_MOVIMIENTOS_POR_PROVEEDOR";
            public const string kardex_Listar_Movimientos_Por_SerieNumero = "ALM.USP_LISTAR_MOVIMIENTOS_POR_SERIE_NUMERO";
            public const string Kardex_Anular_Movimiento = "ALM.USP_ANULAR_KARDEX_MOVIMIENTO";

            public const string Lote_Listar = "ALM.USP_LISTAR_LOTE";
            public const string Lote_Obtener = "ALM.USP_OBTENER_LOTE";
            public const string Lote_Registrar = "ALM.USP_REGISTRAR_LOTE";
            public const string Lote_Eliminar = "ALM.USP_ELIMINAR_LOTE";
            public const string Lote_Modificar = "ALM.USP_MODIFICAR_LOTE";

            public const string Stock_Listar = "ALM.USP_LISTAR_STOCK";
            public const string Stock_Obtener = "ALM.USP_OBTENER_STOCK";
            public const string Stock_Registrar = "ALM.USP_REGISTRAR_STOCK";
            public const string Stock_Eliminar = "ALM.USP_ELIMINAR_STOCK";
            public const string Stock_Modificar = "ALM.USP_MODIFICAR_STOCK";

        }

        public static class OP
        {
            //PENDIENTE CREACION DE STORED PROCEDURES EN SQL SERVER
            public const string OrdenInternaIngresoC_Registrar = "OP.USP_REGISTRAR_ORDEN_INTERNA_INGRESOC";
            public const string OrdenInternaIngresoD_Registrar = "OP.USP_REGISTRAR_ORDEN_INTERNA_INGRESOD";
            public const string OrdenInternaIngreso_Anular = "OP.USP_ANULAR_ORDEN_INTERNA_INGRESO";

            public const string OrdenInternaSalidaC_Registrar = "OP.USP_REGISTRAR_ORDEN_INTERNA_SALIDAC";
            public const string OrdenInternaSalidaD_Registrar = "OP.USP_REGISTRAR_ORDEN_INTERNA_SALIDAD";
            public const string OrdenInternaSalida_Anular = "OP.USP_ANULAR_ORDEN_INTERNA_SALIDA";

            public const string OrdenTransferenciaC_Registrar = "OP.USP_REGISTRAR_ORDEN_TRANSFERENCIAC";
            public const string OrdenTransferenciaD_Registrar = "OP.USP_REGISTRAR_ORDEN_TRANSFERENCIAD";
            public const string OrdenTransferencia_Anular = "OP.USP_ANULAR_ORDEN_TRANSFERENCIA";

            public const string RequerimientoC_Registrar = "OP.USP_REGISTRAR_REQUERIMIENTOC";
            public const string RequerimientoD_Registrar = "OP.USP_REGISTRAR_REQUERIMIENTOD";
            public const string Requerimiento_Anular = "OP.USP_ANULAR_REQUERIMIENTO";

            public const string InventarioC_Registrar = "OP.USP_REGISTRAR_INVENTARIO_FISICOC";
            public const string InventarioD_REgistrar = "OP.USP_REGISTRAR_INVENTARIO_FISICOD";
            public const string Inventario_Anular = "OP.USP_ANULAR_INVENTARIO_FISICO";

            public const string InventarioAjuste_Registrar = "OP.USP_REGISTRAR_INVENTARIO_AJUSTE";

        }

        public static class SEG
        { 
            //YA ESTAN EN EL SQL SERVER
            //YA ESTAN IMPLEMENTADAS
            public const string Rol_Listar = "SEG.USP_LISTAR_ROL";
            public const string Rol_Obtener = "SEG.USP_OBTENER_ROL";
            public const string Rol_Registrar = "SEG.USP_REGISTRAR_ROL";
            public const string Rol_Eliminar = "SEG.USP_ELIMINAR_ROL";
            public const string Rol_Modificar = "SEG.USP_MODIFICAR_ROL";
            
            public const string Usuario_Listar = "SEG.USP_LISTAR_USUARIO";
            public const string Usuario_Obtener = "SEG.USP_OBTENER_USUARIO";
            public const string Usuario_Registrar = "SEG.USP_REGISTRAR_USUARIO";
            public const string Usuario_Modificar = "SEG.USP_MODIFICAR_USUARIO";
            public const string Usuario_Eliminar = "SEG.USP_ELIMINAR_USUARIO";

            public const string Usuario_CambiarClave = "SEG.USP_CAMBIAR_CLAVE_USUARIO";
            public const string Usuario_ValidarAcceso = "SEG.USP_VALIDAR_ACCESO_USUARIO";
            
            public const string Usuario_Rol_Asignar = "SEG.USP_ASIGNAR_ROL_USUARIO";
            public const string Usuario_Rol_Remover = "SEG.USP_REMOVER_ROL_USUARIO";
            
            public const string Usuario_Rol_ListarRolesPorUsuario = "SEG.USP_LISTAR_ROLES_POR_USUARIO";
            public const string Usuario_Rol_ListarUsuariosPorRol = "SEG.USP_LISTAR_USUARIOS_POR_ROL";
        }

        public static class GEO
        {
            //PENDIENTE CREACION DE STORED PROCEDURES EN SQL SERVER
            public const string Facultad_Listar = "GEO.USP_LISTAR_FACULTAD";
            public const string Facultad_Obtener = "GEO.USP_OBTENER_FACULTAD";
            public const string Facultad_Registrar = "GEO.USP_REGISTRAR_FACULTAD";
            public const string Facultad_Eliminar = "GEO.USP_ELIMINAR_FACULTAD";
            public const string Facultad_Modificar = "GEO.USP_MODIFICAR_FACULTAD";

            public const string Sede_Listar = "GEO.USP_LISTAR_SEDE";
            public const string Sede_Obtener = "GEO.USP_OBTENER_SEDE";
            public const string Sede_Registrar = "GEO.USP_REGISTRAR_SEDE";
            public const string Sede_Eliminar = "GEO.USP_ELIMINAR_SEDE";
            public const string Sede_Modificar = "GEO.USP_MODIFICAR_SEDE";

            public const string Ubicacion_Listar = "GEO.USP_LISTAR_UBICACION";
            public const string Ubicacion_Obtener = "GEO.USP_OBTENER_UBICACION";
            public const string Ubicacion_Eliminar = "GEO.USP_ELIMINAR_UBICACION";
            public const string Ubicacion_Registrar = "GEO.USP_REGISTRAR_UBICACION";
            public const string Ubicacion_Modificar = "GEO.USP_MODIFICAR_UBICACION";

            public const string UnidadOrganica_Listar = "GEO.USP_LISTAR_UNIDAD_ORGANICA";
            public const string UnidadOrganica_Obtener = "GEO.USP_OBTENER_UNIDAD_ORGANICA";
            public const string UnidadOrganica_Eliminar = "GEO.USP_ELIMINAR_UNIDAD_ORGANICA";
            public const string UnidadOrganica_Registrar = "GEO.USP_REGISTRAR_UNIDAD_ORGANICA";
            public const string UnidadOrganica_Modificar = "GEO.USP_MODIFICAR_UNIDAD_ORGANICA";
        }
    }
}
