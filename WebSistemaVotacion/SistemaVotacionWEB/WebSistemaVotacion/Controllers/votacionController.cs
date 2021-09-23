using FrontendUtil;
using SistemaVotacionED;
using SistemaVotacionTD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebSistemaVotacion.Filters;

namespace WebSistemaVotacion.Controllers
{
    public class votacionController : Controller
    {
        tdVotacion itdVotacion;

        [HttpPost]
        public JsonResult wInsertarVotacion(int witipoact, int widvotacion, int widpais, string widregion,
            string widprovincia, string widciudad, string widdistrito, string wubigeo, string wsnombre, string wdesc,
            int witipovot, int witipotiempo, int witiempo, int wbtiempofechora, string wtiempofec, string wtiempohora,
            int wirespuesta, string wsrespuesta, int wivariasopc, int wicantidadopc, int wivotcant, int wipreg1, string wspreg1,
            int wipreg2, string wspreg2, int wipreg3, string wspreg3, int wipreg4, string wspreg4, int wipreg5, string wspreg5,
            int wipreg6, string wspreg6, int wipreg7, string wspreg7, int wipreg8, string wspreg8, int wipreg9, string wspreg9,
            int wipreg10, string wspreg10, string wobs, int wiestado, string wsfechareg, string wshorareg, string wsfechamod,
            string wshoramod, string fechaini, string horaini, string horafin, string fechafin)
        {
            try
            {
                int IDusuario = UtlAuditoria.ObtenerIdUsuario();
                var objResultado = new object();
                int iresultado = -1;
                itdVotacion = new tdVotacion();
                iresultado = itdVotacion.tdInsertarVotacion(witipoact, widvotacion, IDusuario, widpais, widregion, widprovincia,
                                        widciudad, widdistrito, wubigeo, wsnombre, wdesc, witipovot, witipotiempo, witiempo,
                                        wbtiempofechora, wtiempofec, wtiempohora, wirespuesta, wsrespuesta, wivariasopc,
                                        wicantidadopc, wivotcant, wipreg1, wspreg1, wipreg2, wspreg2, wipreg3, wspreg3, wipreg4,
                                        wspreg4, wipreg5, wspreg5, wipreg6, wspreg6, wipreg7, wspreg7, wipreg8, wspreg8, wipreg9,
                                        wspreg9, wipreg10, wspreg10, wobs, wiestado, wsfechareg, wshorareg, wsfechamod, wshoramod,
                                        fechaini, horaini, horafin, fechafin);

                objResultado = new
                {
                    iResultado = iresultado,
                    sResultado = "Completado"
                };
                return Json(objResultado);
            }
            catch (Exception ex)
            {
                //UtlLog.toWrite(UtlConstantes.PizarraWEB, UtlConstantes.LogNamespace_PizarraWEB, this.GetType().Name.ToString(), MethodBase.GetCurrentMethod().Name, UtlConstantes.LogTipoError, "", ex.StackTrace.ToString(), ex.Message.ToString());
                return Json(ex);
            }

        }

        [HttpPost]
        public JsonResult wListarVotacion(int widusuario, int widvotacion, int widpais, string widregion, string widprovincia,
                                                string widciudad, string widdistrito, string wsubigeo, string adfechaini, 
                                                string adfechafin, int wtipolistado)
        {
            try
            {
                var objResultado = new object();
                List<edVotacion> oedvotacion = new List<edVotacion>();
                itdVotacion = new tdVotacion();
                oedvotacion = itdVotacion.tdListarVotacion(widusuario, widvotacion, widpais, widregion, widprovincia, widciudad, widdistrito, wsubigeo, adfechaini, adfechafin, wtipolistado);
                if (oedvotacion.Count > 0)
                {
                    objResultado = new
                    {
                        PageStart = 1,
                        pageSize = 100,
                        SearchText = string.Empty,
                        ShowChildren = UtlConstantes.bValorTrue,
                        iTotalRecords = oedvotacion.Count,
                        iTotalDisplayRecords = 1,
                        aaData = oedvotacion
                    };
                    return Json(objResultado);
                }
                else
                {
                    objResultado = new
                    {
                        PageStart = 1,
                        pageSize = 100,
                        SearchText = string.Empty,
                        ShowChildren = UtlConstantes.bValorTrue,
                        iTotalRecords = 0,
                        iTotalDisplayRecords = 1,
                        aaData = ""
                    };
                    return Json(objResultado);
                }
            }
            catch (Exception ex)
            {
                //UtlLog.toWrite(UtlConstantes.PizarraWEB, UtlConstantes.LogNamespace_PizarraWEB, this.GetType().Name.ToString(), MethodBase.GetCurrentMethod().Name, UtlConstantes.LogTipoError, "", ex.StackTrace.ToString(), ex.Message.ToString());
                return Json(ex);
            }

        }

        [HttpPost]
        public JsonResult wInsertarVotacionUsuario(int witipoact, int idvotacionusu, int widvotacion, int widusuario,
            string wsrepuesta, int wicantopc, int wipregunta1, int wipregunta2, int wipregunta3, int wipregunta4, int wipregunta5,
            int wipregunta6, int wipregunta7, int wipregunta8, int wipregunta9, int wipregunta10, string wobservacion,
            int wiestado, string wsfechareg, string wshorareg, string wsfechamod, string wshoramod)
        {
            try
            {
                var objResultado = new object();
                int iresultado = -1;
                itdVotacion = new tdVotacion();
                iresultado = itdVotacion.tdInsertarVotacionUsuario(witipoact, idvotacionusu, widvotacion, widusuario,
                                    wsrepuesta, wicantopc, wipregunta1, wipregunta2, wipregunta3, wipregunta4, wipregunta5,
                                    wipregunta6, wipregunta7, wipregunta8, wipregunta9, wipregunta10, wobservacion,
                                    wiestado, wsfechareg, wshorareg, wsfechamod, wshoramod);

                objResultado = new
                {
                    iResultado = iresultado,
                    sResultado = "Completado"
                };
                return Json(objResultado);
            }
            catch (Exception ex)
            {
                //UtlLog.toWrite(UtlConstantes.PizarraWEB, UtlConstantes.LogNamespace_PizarraWEB, this.GetType().Name.ToString(), MethodBase.GetCurrentMethod().Name, UtlConstantes.LogTipoError, "", ex.StackTrace.ToString(), ex.Message.ToString());
                return Json(ex);
            }

        }

        [HttpPost]
        public JsonResult wListarVotacionUsuario(int widusuario, int widvotacionusuario)
        {
            try
            {
                var objResultado = new object();
                List<edVotacionUsuario> oedvotacion = new List<edVotacionUsuario>();
                itdVotacion = new tdVotacion();
                oedvotacion = itdVotacion.tdListarVotacionUsuario(widusuario, widvotacionusuario);
                if (oedvotacion.Count > 0)
                {
                    objResultado = new
                    {
                        PageStart = 1,
                        pageSize = 100,
                        SearchText = string.Empty,
                        ShowChildren = UtlConstantes.bValorTrue,
                        iTotalRecords = oedvotacion.Count,
                        iTotalDisplayRecords = 1,
                        aaData = oedvotacion
                    };
                    return Json(objResultado);
                }
                else
                {
                    objResultado = new
                    {
                        PageStart = 1,
                        pageSize = 100,
                        SearchText = string.Empty,
                        ShowChildren = UtlConstantes.bValorTrue,
                        iTotalRecords = 0,
                        iTotalDisplayRecords = 1,
                        aaData = ""
                    };
                    return Json(objResultado);
                }
            }
            catch (Exception ex)
            {
                //UtlLog.toWrite(UtlConstantes.PizarraWEB, UtlConstantes.LogNamespace_PizarraWEB, this.GetType().Name.ToString(), MethodBase.GetCurrentMethod().Name, UtlConstantes.LogTipoError, "", ex.StackTrace.ToString(), ex.Message.ToString());
                return Json(ex);
            }

        }

        [ValidadorSesionVista]
        public ActionResult nuevaMocion()
        {
            string Nombres = UtlAuditoria.ObtenerNombre();
            string Correo = UtlAuditoria.ObtenerEmail();
            int TipoUsuario = UtlAuditoria.ObtenerTipoUsuario();
            int IDusuario = UtlAuditoria.ObtenerIdUsuario();
            ViewBag.VBNombres = Nombres;
            ViewBag.VBCorreo = Correo;
            ViewBag.VBTipoUsuario = TipoUsuario;
            ViewBag.VBIDusuario = IDusuario;

            ViewBag.MenuMocion = "active";
            ViewBag.MenuPerfil = "";
            ViewBag.MenuUsuario = "";

            ViewBag.VBDepartamentos = UtlAuditoria.ObtenerDepartamentos();
            ViewBag.VBProvincias = UtlAuditoria.ObtenerProvincias();
            ViewBag.VBDistritos = UtlAuditoria.ObtenerDistritos();
            return View();
        }

        [ValidadorSesionVista]
        public ActionResult mocionUsuario()
        {
            string Nombres = UtlAuditoria.ObtenerNombre();
            string Correo = UtlAuditoria.ObtenerEmail();
            int TipoUsuario = UtlAuditoria.ObtenerTipoUsuario();
            int IDusuario = UtlAuditoria.ObtenerIdUsuario();
            ViewBag.VBNombres = Nombres;
            ViewBag.VBCorreo = Correo;
            ViewBag.VBTipoUsuario = TipoUsuario;
            ViewBag.VBIDusuario = IDusuario;

            ViewBag.MenuMocion = "active";
            ViewBag.MenuPerfil = "";
            ViewBag.MenuUsuario = "";

            ViewBag.VBDepartamentos = UtlAuditoria.ObtenerDepartamentos();
            ViewBag.VBProvincias = UtlAuditoria.ObtenerProvincias();
            ViewBag.VBDistritos = UtlAuditoria.ObtenerDistritos();
            return View();
        }

    }
}