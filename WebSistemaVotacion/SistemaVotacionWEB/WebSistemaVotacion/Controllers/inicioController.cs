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
    public class inicioController : Controller
    {
        tdUsuario itdusuario;

        public ActionResult inicio(int? ivalorsesion, string valorlogin)
        {
            if (ivalorsesion != 1 || ivalorsesion == null)
            {
                ivalorsesion = 0;
            }
            else
            {

            }

            ViewBag.GIvalorError = valorlogin;
            ViewBag.GIvalorSesion = ivalorsesion;
            return View();
        }

        public ActionResult registro()
        {
            return View();
        }

        [ValidadorSesionVista]
        public ActionResult principal()
        {
            string Nombres = UtlAuditoria.ObtenerNombre();
            string Correo = UtlAuditoria.ObtenerEmail();
            int TipoUsuario = UtlAuditoria.ObtenerTipoUsuario();
            ViewBag.VBNombres = Nombres;
            ViewBag.VBCorreo = Correo;
            ViewBag.VBTipoUsuario = TipoUsuario;
            ViewBag.MenuMocion = "active";
            ViewBag.MenuPerfil = "";
            ViewBag.MenuUsuario = "";

            ViewBag.VBIDusuario = UtlAuditoria.ObtenerIdUsuario();
            ViewBag.VBDepartamentos = UtlAuditoria.ObtenerDepartamentos();
            ViewBag.VBProvincias = UtlAuditoria.ObtenerProvincias();
            ViewBag.VBDistritos = UtlAuditoria.ObtenerDistritos();
            return View();
        }

        [ValidadorSesionVista]
        public ActionResult perfil()
        {
            string Nombres = UtlAuditoria.ObtenerNombre();
            string Correo = UtlAuditoria.ObtenerEmail();
            string Dni = UtlAuditoria.ObtenerDocumento();
            int TipoUsuario = UtlAuditoria.ObtenerTipoUsuario();
            ViewBag.VBNombres = Nombres;
            ViewBag.VBCorreo = Correo;
            ViewBag.VBDni = Dni;
            ViewBag.VBTipoUsuario = TipoUsuario;
            ViewBag.MenuMocion = "";
            ViewBag.MenuPerfil = "active";
            ViewBag.MenuUsuario = "";
            
            ViewBag.VBIDusuario = UtlAuditoria.ObtenerIdUsuario();
            ViewBag.VBDepartamentos = UtlAuditoria.ObtenerDepartamentos();
            ViewBag.VBProvincias = UtlAuditoria.ObtenerProvincias();
            ViewBag.VBDistritos = UtlAuditoria.ObtenerDistritos();
            return View();
        }


        [ValidadorSesionVista]
        public ActionResult cuenta()
        {
            string Nombres = UtlAuditoria.ObtenerNombre();
            string Correo = UtlAuditoria.ObtenerEmail();
            int TipoUsuario = UtlAuditoria.ObtenerTipoUsuario();
            ViewBag.VBNombres = Nombres;
            ViewBag.VBCorreo = Correo;
            ViewBag.VBTipoUsuario = TipoUsuario;
            ViewBag.MenuMocion = "";
            ViewBag.MenuPerfil = "";
            ViewBag.MenuUsuario = "active";
            return View();
        }

        [ValidadorSesionVista]
        public ActionResult nuevaCuenta()
        {
            string Nombres = UtlAuditoria.ObtenerNombre();
            string Correo = UtlAuditoria.ObtenerEmail();
            int TipoUsuario = UtlAuditoria.ObtenerTipoUsuario();
            ViewBag.VBNombres = Nombres;
            ViewBag.VBCorreo = Correo;
            ViewBag.VBTipoUsuario = TipoUsuario;
            ViewBag.MenuMocion = "";
            ViewBag.MenuPerfil = "";
            ViewBag.MenuUsuario = "active";
            return View();
        }

        public ActionResult mocion()
        {
            ViewBag.MenuMocion = "active";
            ViewBag.MenuPerfil = "";
            ViewBag.MenuUsuario = "";
            return View();
        }

        public ActionResult error()
        {
            return View();
        }

        [HttpPost]
        public JsonResult IniciarSesion(string wusuario, string wclave)
        {
            try
            {
                var objResultado = new object();
                edUsuario oedusuario = new edUsuario();
                itdusuario = new tdUsuario();
                oedusuario = itdusuario.tdObtenerUsuario(wusuario, wclave);

                if (oedusuario._resultado == 0 || oedusuario.scorreo == "" || oedusuario.snombres == "" || oedusuario.snombres == "")
                {
                    objResultado = new
                    {
                        iResultado = -3,
                        iResultadoIns = "Usuario o clave incorrectos"
                    };
                    return Json(objResultado);
                }
                Dictionary<string, string> DVariables = new Dictionary<string, string>();
                DVariables["IDUSUARIO"] = oedusuario.idusuario.ToString();
                DVariables["SNOMBRE"] = oedusuario.snombres;
                DVariables["SAPELLIDO"] = oedusuario.sapellidos;
                DVariables["SEMAIL"] = oedusuario.scorreo;
                DVariables["IPAIS"] = oedusuario.idpais.ToString();
                DVariables["IREGION"] = oedusuario.idregion.ToString();
                DVariables["IPROVINCIA"] = oedusuario.idprovincia.ToString();
                DVariables["ICIUDAD"] = oedusuario.idciudad.ToString();
                DVariables["IDISTRITO"] = oedusuario.iddistrito.ToString();
                DVariables["SUBIGEO"] = oedusuario.subigeo;
                DVariables["ITIPOUSUARIO"] = oedusuario.itipousuario.ToString();
                DVariables["ITIPODOC"] = oedusuario.itipodoc.ToString();
                DVariables["SNUMDOC"] = oedusuario.snumdoc;
                DVariables["SDEPARTAMENTOS"] = oedusuario.sdepartamentos;
                DVariables["SPROVINCIAS"] = oedusuario.sprovincias;
                DVariables["SDISTRITOS"] = oedusuario.sdistritos;
                UtlAuditoria.SetSessionValues(DVariables);

                objResultado = new
                {
                    iResultado = oedusuario.itipousuario,
                    iResultadoIns = "Inicio/Principal"
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
        public JsonResult CrearUsuario(string nombres, string apellidos, int igenero, int idregion, int idprovincia,
            int idciudad, int iddistrito, string ubigeo, string simagenperfil, string simagenportada, string fecnac,
            int bestado, string fecharegistro, string horaregistro, int tipousuario, string correo, int itipodoc,
            string numdoc, string clave, string token, string sdepartamentos, string sprovincias, string sdistritos)
        {
            try
            {
                var objResultado = new object();
                int iresultado = 0;
                itdusuario = new tdUsuario();
                List<edUsuario> oedusuario = new List<edUsuario>();
                iresultado = itdusuario.tdInsertarUsuario(nombres, apellidos, igenero, idregion, idprovincia, idciudad, iddistrito,
                                    ubigeo, simagenperfil, simagenportada, fecnac, bestado, fecharegistro, horaregistro, tipousuario,
                                    correo, itipodoc, numdoc, clave, token, sdepartamentos, sprovincias, sdistritos);
                if (iresultado == 0 || iresultado == -1 || iresultado == -2)
                {
                    objResultado = new
                    {
                        iResultado = -3,
                        iResultadoIns = "Usuario o clave incorrecta"
                    };
                    return Json(objResultado);
                }
                objResultado = new
                {
                    iResultado = 1,
                    iResultadoIns = "Inicio/Principal"
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
        public JsonResult cerrarSesion()
        {
            var objResultado = new object();
            try
            {
                bool bResultado = UtlAuditoria.CerrarSession();
                if (bResultado)
                {
                    objResultado = new
                    {
                        iResultado = 1
                    };
                }
                else
                {
                    objResultado = new
                    {
                        iResultado = 2
                    };
                }
            }
            catch (Exception ex)
            {
                //UtlLog.toWrite(UtlConstantes.PizarraWEB, UtlConstantes.LogNamespace_PizarraWEB, this.GetType().Name.ToString(), MethodBase.GetCurrentMethod().Name, UtlConstantes.LogTipoError, "", ex.StackTrace.ToString(), ex.Message.ToString());
                throw ex;
            }
            return Json(objResultado);
        }

        [HttpPost]
        public JsonResult wActualizarAcceso(int wtipoactualizar, int widusuario, string wcorreo, string wclave)
        {
            try
            {
                var objResultado = new object();
                int iresultado = -1;
                itdusuario = new tdUsuario();
                iresultado = itdusuario.tdActualizarAcceso(wtipoactualizar, widusuario, wcorreo, wclave);

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
        public JsonResult wActualizarClave(int widusuario, string wnuevaclave)
        {
            try
            {
                var objResultado = new object();
                int iresultado = -1;
                itdusuario = new tdUsuario();
                iresultado = itdusuario.tdActualizarClave(widusuario, wnuevaclave);

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
        public JsonResult wActualizarCuenta(int widusuario, int widpais, int widprovincia, int widciudad, int widdistrito,
                            string wsubigeo, string wnombres, string wapellidos, string wsnombreusuario, string wsdireccion,
                            string wdireccion2, int wigenero, string wscorreo2, string wfacebook, string winstagram,
                            string wtwitter, string wimagenperfil, string wimagenportada, string wcelular1, string wfechanacimiento,
                            string wfechamodificacion, string whoramodificacion, int wbestado, int witipodoc, string wnumdoc,
                            string sdepartamentos, string sprovincias, string sdistritos)
        {
            try
            {
                var objResultado = new object();
                int iresultado = -1;
                itdusuario = new tdUsuario();
                iresultado = itdusuario.tdActualizarCuenta(widusuario, widpais, widprovincia, widciudad, widdistrito,
                                                        wsubigeo, wnombres, wapellidos, wsnombreusuario, wsdireccion,
                                                        wdireccion2, wigenero, wscorreo2, wfacebook, winstagram,
                                                        wtwitter, wimagenperfil, wimagenportada, wcelular1, wfechanacimiento,
                                                        wfechamodificacion, whoramodificacion, wbestado, witipodoc, wnumdoc,
                                                        sdepartamentos, sprovincias, sdistritos);

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
        public JsonResult wFiltrarUsuario(int wusuario, int wbestado, int wtipousuario)
        {
            try
            {
                var objResultado = new object();
                List<edUsuario> oedusuario = new List<edUsuario>();
                itdusuario = new tdUsuario();
                oedusuario = itdusuario.tdFiltrarUsuario(wusuario, wbestado, wtipousuario);

                if (oedusuario.Count > 0)
                {
                    objResultado = new
                    {
                        PageStart = 1,
                        pageSize = 100,
                        SearchText = string.Empty,
                        ShowChildren = UtlConstantes.bValorTrue,
                        iTotalRecords = oedusuario.Count,
                        iTotalDisplayRecords = 1,
                        aaData = oedusuario
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
        public JsonResult wListarMaestro(int widMaestro)
        {
            try
            {
                var objResultado = new object();
                List<edMaestro> lstmaestro = new List<edMaestro>();
                tdMaestro itdmaestro = new tdMaestro();
                lstmaestro = itdmaestro.tdListarMaestro(widMaestro);
                if (lstmaestro.Count > 0)
                {
                    objResultado = new
                    {
                        PageStart = 1,
                        pageSize = 100,
                        SearchText = string.Empty,
                        ShowChildren = UtlConstantes.bValorTrue,
                        iTotalRecords = lstmaestro.Count,
                        iTotalDisplayRecords = 1,
                        aaData = lstmaestro
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


    }
}