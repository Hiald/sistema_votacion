using MySql.Data.MySqlClient;
using SistemaVotacionAD;
using SistemaVotacionED;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaVotacionTD
{
    public class tdVotacion : td_aglobal
    {
        adVotacion iadVotacion;

        public int tdInsertarVotacion(int tditipoactualizar, int tdidvotacion, int tdidusuario, int tdidpais, string tdidregion,
            string tdidprovincia, string tdidciudad, string tdiddistrito, string tdubigeo, string tdsnombre, string tddescripcion,
            int tditipovotacion, int tditipotiempo, int tditiempo, int tdbtiempofechahora, string tdtiempofecha, string tdtiempohora,
            int tdirespuesta, string tdsrespuesta, int tdivariasopc, int tdicantidadopc, int tdivotcant, int tdipreg1, string tdspreg1,
            int tdipreg2, string tdspreg2, int tdipreg3, string tdspreg3, int tdipreg4, string tdspreg4, int tdipreg5, string tdspreg5,
            int tdipreg6, string tdspreg6, int tdipreg7, string tdspreg7, int tdipreg8, string tdspreg8, int tdipreg9, string tdspreg9,
            int tdipreg10, string tdspreg10, string tdobs, int tdiestado, string tdsfechareg, string tdshorareg, string tdsfechamod,
            string tdshoramod, string adfechaini, string horaini, string horafin, string adfechafin)
        {
            int iRespuesta = -1;
            try
            {
                using (MySqlConnection con = new MySqlConnection(mysqlConexion))
                {
                    con.Open();
                    using (MySqlTransaction scope = con.BeginTransaction())
                    {
                        iadVotacion = new adVotacion(con);
                        iRespuesta = iadVotacion.adInsertarVotacion(tditipoactualizar, tdidvotacion, tdidusuario, tdidpais, tdidregion,
                                    tdidprovincia, tdidciudad, tdiddistrito, tdubigeo, tdsnombre, tddescripcion, tditipovotacion,
                                    tditipotiempo, tditiempo, tdbtiempofechahora, tdtiempofecha, tdtiempohora, tdirespuesta, tdsrespuesta,
                                    tdivariasopc, tdicantidadopc, tdivotcant, tdipreg1, tdspreg1, tdipreg2, tdspreg2, tdipreg3, tdspreg3,
                                    tdipreg4, tdspreg4, tdipreg5, tdspreg5, tdipreg6, tdspreg6, tdipreg7, tdspreg7, tdipreg8, tdspreg8,
                                    tdipreg9, tdspreg9, tdipreg10, tdspreg10, tdobs, tdiestado, tdsfechareg, tdshorareg, tdsfechamod, tdshoramod,
                                    adfechaini, horaini, horafin, adfechafin);
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

        public List<edVotacion> tdListarVotacion(int tdidusuario, int tdidvotacion, int tdidpais, string tdidregion, string tdidprovincia,
                                                string tdidciudad, string tdiddistrito, string tdsubigeo, string adfechaini, 
                                                string adfechafin ,int tdtipolistado)
        {
            List<edVotacion> renUsuario = new List<edVotacion>();
            try
            {
                using (MySqlConnection con = new MySqlConnection(mysqlConexion))
                {
                    con.Open();
                    using (MySqlTransaction scope = con.BeginTransaction())
                    {
                        iadVotacion = new adVotacion(con);
                        renUsuario = iadVotacion.adListarVotacion(tdidusuario, tdidvotacion, tdidpais, tdidregion, tdidprovincia,
                                                                    tdidciudad, tdiddistrito, tdsubigeo, adfechaini, adfechafin,
                                                                    tdtipolistado);
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

        public int tdInsertarVotacionUsuario(int tditipoactualizar, int tdidvotacionusuario, int tdidvotacion, int tdidusuario,
            string tdsrepuesta, int tdicantopc, int tdipregunta1, int tdipregunta2, int tdipregunta3, int tdipregunta4, int tdipregunta5,
            int tdipregunta6, int tdipregunta7, int tdipregunta8, int tdipregunta9, int tdipregunta10, string tdobservacion,
            int tdiestado, string tdsfechareg, string tdshorareg, string tdsfechamod, string tdshoramod)
        {
            int iRespuesta = -1;
            try
            {
                using (MySqlConnection con = new MySqlConnection(mysqlConexion))
                {
                    con.Open();
                    using (MySqlTransaction scope = con.BeginTransaction())
                    {
                        iadVotacion = new adVotacion(con);
                        iRespuesta = iadVotacion.adInsertarVotacionUsuario(tditipoactualizar, tdidvotacionusuario, tdidvotacion,
                                                tdidusuario, tdsrepuesta, tdicantopc, tdipregunta1, tdipregunta2, tdipregunta3,
                                                tdipregunta4, tdipregunta5, tdipregunta6, tdipregunta7, tdipregunta8, tdipregunta9,
                                                tdipregunta10, tdobservacion, tdiestado, tdsfechareg, tdshorareg, tdsfechamod, tdshoramod);
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

        public List<edVotacionUsuario> tdListarVotacionUsuario(int tdidusuario, int tdidvotacionusuario)
        {
            List<edVotacionUsuario> renUsuario = new List<edVotacionUsuario>();
            try
            {
                using (MySqlConnection con = new MySqlConnection(mysqlConexion))
                {
                    con.Open();
                    using (MySqlTransaction scope = con.BeginTransaction())
                    {
                        iadVotacion = new adVotacion(con);
                        renUsuario = iadVotacion.adListarVotacionUsuario(tdidusuario, tdidvotacionusuario);
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
