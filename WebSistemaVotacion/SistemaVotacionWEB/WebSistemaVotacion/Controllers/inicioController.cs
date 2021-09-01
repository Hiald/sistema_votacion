using FrontendUtil;
using SistemaVotacionED;
using SistemaVotacionTD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebSistemaVotacion.Controllers
{
    public class inicioController : Controller
    {
        tdUsuario itdusuario;

        // GET: inicio
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult inicio()
        {
            return View();
        }

        public ActionResult registro()
        {
            return View();
        }

        public ActionResult principal()
        {
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

                if (oedusuario.scorreo == "0" || oedusuario.snombres == "0" || oedusuario.snombres == "0")
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
                DVariables["APELLIDO"] = oedusuario.sapellidos;
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
        public JsonResult CrearUsuario(string tdnombres, string tdapellidos, int tdigenero, int tdidregion, int tdidprovincia,
            int tdidciudad, int tdiddistrito, string tdubigeo, string tdsimagenperfil, string tdsimagenportada, string tdfecnac,
            int tdbestado, string tdfecharegistro, string tdhoraregistro, int tdtipousuario, string tdcorreo, int tditipodoc,
            string tdnumdoc, string tdclave, string tdtoken)
        {
            try
            {
                var objResultado = new object();
                int iresultado = 0;
                itdusuario = new tdUsuario();
                edUsuario oedusuario = new edUsuario();
                iresultado = itdusuario.tdInsertarUsuario(tdnombres, tdapellidos, tdigenero, tdidregion, tdidprovincia,
                                     tdidciudad, tdiddistrito, tdubigeo, tdsimagenperfil, tdsimagenportada, tdfecnac,
                                     tdbestado, tdfecharegistro, tdhoraregistro, tdtipousuario, tdcorreo, tditipodoc,
                                     tdnumdoc, tdclave, tdtoken);
                if (iresultado == 0 || iresultado == -1 || iresultado == -2)
                {
                    objResultado = new
                    {
                        iResultado = -3,
                        iResultadoIns = "Usuario o clave incorrecta"
                    };
                    return Json(objResultado);
                }
                oedusuario = itdusuario.tdFiltrarUsuario(iresultado, 1);
                Dictionary<string, string> DVariables = new Dictionary<string, string>();
                DVariables["IDUSUARIO"] = oedusuario.idusuario.ToString();
                DVariables["SNOMBRE"] = oedusuario.snombres;
                DVariables["APELLIDO"] = oedusuario.sapellidos;
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
                UtlAuditoria.SetSessionValues(DVariables);

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


    }
}