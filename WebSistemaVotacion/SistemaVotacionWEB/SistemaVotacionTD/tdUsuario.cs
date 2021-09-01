using MySql.Data.MySqlClient;
using SistemaVotacionAD;
using SistemaVotacionED;

namespace SistemaVotacionTD
{
    public class tdUsuario : td_aglobal
    {
        adUsuario iadUsuario;

        public edUsuario tdObtenerUsuario(string tdcorreo, string tdclave)
        {
            edUsuario renUsuario = new edUsuario();
            try
            {
                using (MySqlConnection con = new MySqlConnection(mysqlConexion))
                {
                    con.Open();
                    using (MySqlTransaction scope = con.BeginTransaction())
                    {
                        iadUsuario = new adUsuario(con);
                        renUsuario = iadUsuario.adObtenerUsuario(tdcorreo, tdclave);
                        scope.Commit();
                    }
                }
                return renUsuario;
            }
            catch (MySqlException ex)
            {
                //UtlLog.toWrite(UtlConstantes.TProcessRN, UtlConstantes.LogNamespace_TProcessRN, this.GetType().Name.ToString(), MethodBase.GetCurrentMethod().Name, UtlConstantes.LogTipoError, "", ex.StackTrace.ToString(), ex.Message.ToString());
                throw ex;
            }

        }

        public int tdInsertarUsuario(string tdnombres, string tdapellidos, int tdigenero, int tdidregion, int tdidprovincia,
            int tdidciudad, int tdiddistrito, string tdubigeo, string tdsimagenperfil, string tdsimagenportada, string tdfecnac,
            int tdbestado, string tdfecharegistro, string tdhoraregistro, int tdtipousuario, string tdcorreo, int tditipodoc, string tdnumdoc,
            string tdclave, string tdtoken)
        {
            int iRespuesta = -1;
            try
            {
                using (MySqlConnection con = new MySqlConnection(mysqlConexion))
                {
                    con.Open();
                    using (MySqlTransaction scope = con.BeginTransaction())
                    {
                        iadUsuario = new adUsuario(con);
                        iRespuesta = iadUsuario.adInsertarUsuario(tdnombres, tdapellidos, tdigenero, tdidregion, tdidprovincia,
                                        tdidciudad, tdiddistrito, tdubigeo, tdsimagenperfil, tdsimagenportada, tdfecnac, tdbestado,
                                        tdfecharegistro, tdhoraregistro, tdtipousuario, tdcorreo, tditipodoc, tdnumdoc, tdclave, tdtoken);
                        scope.Commit();
                    }
                }
                return (iRespuesta);
            }
            catch (MySqlException ex)
            {
                //UtlLog.toWrite(UtlConstantes.TProcessRN, UtlConstantes.LogNamespace_TProcessRN, this.GetType().Name.ToString(), MethodBase.GetCurrentMethod().Name, UtlConstantes.LogTipoError, "", ex.StackTrace.ToString(), ex.Message.ToString());
                throw ex;
            }

        }

        public int tdActualizarAcceso(int tdtipoactualizar, int tdidusuario, string tdcorreo, string tdclave)
        {
            int iRespuesta = -1;
            try
            {
                using (MySqlConnection con = new MySqlConnection(mysqlConexion))
                {
                    con.Open();
                    using (MySqlTransaction scope = con.BeginTransaction())
                    {
                        iadUsuario = new adUsuario(con);
                        iRespuesta = iadUsuario.adActualizarAcceso(tdtipoactualizar, tdidusuario, tdcorreo, tdclave);
                        scope.Commit();
                    }
                }
                return (iRespuesta);
            }
            catch (MySqlException ex)
            {
                //UtlLog.toWrite(UtlConstantes.TProcessRN, UtlConstantes.LogNamespace_TProcessRN, this.GetType().Name.ToString(), MethodBase.GetCurrentMethod().Name, UtlConstantes.LogTipoError, "", ex.StackTrace.ToString(), ex.Message.ToString());
                throw ex;
            }

        }

        public int tdActualizarClave(int tdidusuario, string tdnuevaclave)
        {
            int iRespuesta = -1;
            try
            {
                using (MySqlConnection con = new MySqlConnection(mysqlConexion))
                {
                    con.Open();
                    using (MySqlTransaction scope = con.BeginTransaction())
                    {
                        iadUsuario = new adUsuario(con);
                        iRespuesta = iadUsuario.adActualizarClave(tdidusuario, tdnuevaclave);
                        scope.Commit();
                    }
                }
                return (iRespuesta);
            }
            catch (MySqlException ex)
            {
                //UtlLog.toWrite(UtlConstantes.TProcessRN, UtlConstantes.LogNamespace_TProcessRN, this.GetType().Name.ToString(), MethodBase.GetCurrentMethod().Name, UtlConstantes.LogTipoError, "", ex.StackTrace.ToString(), ex.Message.ToString());
                throw ex;
            }

        }

        public int tdActualizarCuenta(int tdidusuario, int tdidpais, int tdidprovincia, int tdidciudad, int tdiddistrito,
            string tdsubigeo, string tdnombres, string tdapellidos, string tdsnombreusuario, string tdsdireccion,
            string tddireccion2, int tdigenero, string tdscorreo2, string tdfacebook, string tdinstagram, string tdtwitter,
            string tdimagenperfil, string tdimagenportada, string tdcelular1, string tdfechanacimiento, string tdfechamodificacion,
            string tdhoramodificacion, int tdbestado, int aditipodoc, string adnumdoc)
        {
            int iRespuesta = -1;
            try
            {
                using (MySqlConnection con = new MySqlConnection(mysqlConexion))
                {
                    con.Open();
                    using (MySqlTransaction scope = con.BeginTransaction())
                    {
                        iadUsuario = new adUsuario(con);
                        iRespuesta = iadUsuario.adActualizarCuenta(tdidusuario, tdidpais, tdidprovincia, tdidciudad, tdiddistrito,
                                    tdsubigeo, tdnombres, tdapellidos, tdsnombreusuario, tdsdireccion, tddireccion2, tdigenero,
                                    tdscorreo2, tdfacebook, tdinstagram, tdtwitter, tdimagenperfil, tdimagenportada, tdcelular1,
                                    tdfechanacimiento, tdfechamodificacion, tdhoramodificacion, tdbestado, aditipodoc, adnumdoc);
                        scope.Commit();
                    }
                }
                return (iRespuesta);
            }
            catch (MySqlException ex)
            {
                //UtlLog.toWrite(UtlConstantes.TProcessRN, UtlConstantes.LogNamespace_TProcessRN, this.GetType().Name.ToString(), MethodBase.GetCurrentMethod().Name, UtlConstantes.LogTipoError, "", ex.StackTrace.ToString(), ex.Message.ToString());
                throw ex;
            }

        }

        public edUsuario tdFiltrarUsuario(int tdusuario, int tdbestado)
        {
            edUsuario renUsuario = new edUsuario();
            try
            {
                using (MySqlConnection con = new MySqlConnection(mysqlConexion))
                {
                    con.Open();
                    using (MySqlTransaction scope = con.BeginTransaction())
                    {
                        iadUsuario = new adUsuario(con);
                        renUsuario = iadUsuario.adFiltrarUsuario(tdusuario, tdbestado);
                        scope.Commit();
                    }
                }
                return renUsuario;
            }
            catch (MySqlException ex)
            {
                //UtlLog.toWrite(UtlConstantes.TProcessRN, UtlConstantes.LogNamespace_TProcessRN, this.GetType().Name.ToString(), MethodBase.GetCurrentMethod().Name, UtlConstantes.LogTipoError, "", ex.StackTrace.ToString(), ex.Message.ToString());
                throw ex;
            }

        }

    }
}
