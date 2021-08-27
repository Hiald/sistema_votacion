using MySql.Data.MySqlClient;
using SistemaVotacionED;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaVotacionAD
{
    public class adVotacion : ad_aglobal
    {
        public adVotacion(MySqlConnection cn)
        {
            cnMysql = cn;
        }

        public int adInsertarVotacion(int aditipoactualizar, int adidvotacion, int adidusuario, int adidpais, int adidregion,
            int adidprovincia, int adidciudad, int adiddistrito, string adubigeo, string adsnombre, string addescripcion,
            int aditipovotacion, int aditipotiempo, int aditiempo, int adbtiempofechahora, string adtiempofecha, string adtiempohora,
            int adirespuesta, string adsrespuesta, int adivariasopc, int adicantidadopc, int adivotcant, int adipreg1, string adspreg1,
            int adipreg2, string adspreg2, int adipreg3, string adspreg3, int adipreg4, string adspreg4, int adipreg5, string adspreg5,
            int adipreg6, string adspreg6, int adipreg7, string adspreg7, int adipreg8, string adspreg8, int adipreg9, string adspreg9,
            int adipreg10, string adspreg10, string adobs, int adiestado, string adsfechareg, string adshorareg, string adsfechamod,
            string adshoramod)
        {
            try
            {
                int result = -2;
                MySqlCommand cmd = new MySqlCommand("sp_operacion_votacion", cnMysql);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("_tipoactualizar", MySqlDbType.Int32).Value = aditipoactualizar;
                cmd.Parameters.Add("_idvotacion", MySqlDbType.Int32).Value = adidvotacion;
                cmd.Parameters.Add("_idusuario", MySqlDbType.Int32).Value = adidusuario;
                cmd.Parameters.Add("_idpais", MySqlDbType.Int32).Value = adidpais;
                cmd.Parameters.Add("_idregion", MySqlDbType.Int32).Value = adidregion;
                cmd.Parameters.Add("_idprovincia", MySqlDbType.Int32).Value = adidprovincia;
                cmd.Parameters.Add("_idciudad", MySqlDbType.Int32).Value = adidciudad;
                cmd.Parameters.Add("_iddistrito", MySqlDbType.Int32).Value = adiddistrito;
                cmd.Parameters.Add("_v_ubigeo", MySqlDbType.VarChar, 10).Value = adubigeo;
                cmd.Parameters.Add("_v_nombre", MySqlDbType.VarChar, 150).Value = adsnombre;
                cmd.Parameters.Add("_v_descripcion", MySqlDbType.VarChar, 500).Value = addescripcion;
                cmd.Parameters.Add("_i_tipovotacion", MySqlDbType.Int32).Value = aditipovotacion;
                cmd.Parameters.Add("_i_tipotiempo", MySqlDbType.Int32).Value = aditipotiempo;
                cmd.Parameters.Add("_i_tiempo", MySqlDbType.Int32).Value = aditiempo;
                cmd.Parameters.Add("_b_tiempo_fecha_hora", MySqlDbType.Int32).Value = adbtiempofechahora;
                cmd.Parameters.Add("_dt_tiempo_fecha", MySqlDbType.VarChar, 25).Value = adtiempofecha;
                cmd.Parameters.Add("_dt_tiempo_hora", MySqlDbType.VarChar, 25).Value = adtiempohora;
                cmd.Parameters.Add("_b_respuesta", MySqlDbType.Int32).Value = adirespuesta;
                cmd.Parameters.Add("_v_respuesta", MySqlDbType.VarChar, 500).Value = adsrespuesta;
                cmd.Parameters.Add("_i_varias_opciones", MySqlDbType.Int32).Value = adivariasopc;
                cmd.Parameters.Add("_i_cantidad_opciones", MySqlDbType.Int32).Value = adicantidadopc;
                cmd.Parameters.Add("_i_votacion_cantidad", MySqlDbType.Int32).Value = adivotcant;
                cmd.Parameters.Add("_i_pregunta_1", MySqlDbType.Int32).Value = adipreg1;
                cmd.Parameters.Add("_v_pregunta_1", MySqlDbType.VarChar, 250).Value = adspreg1;
                cmd.Parameters.Add("_i_pregunta_2", MySqlDbType.Int32).Value = adipreg2;
                cmd.Parameters.Add("_v_pregunta_2", MySqlDbType.VarChar, 250).Value = adspreg2;
                cmd.Parameters.Add("_i_pregunta_3", MySqlDbType.Int32).Value = adipreg3;
                cmd.Parameters.Add("_v_pregunta_3", MySqlDbType.VarChar, 250).Value = adspreg3;
                cmd.Parameters.Add("_i_pregunta_4", MySqlDbType.Int32).Value = adipreg4;
                cmd.Parameters.Add("_v_pregunta_4", MySqlDbType.VarChar, 250).Value = adspreg4;
                cmd.Parameters.Add("_i_pregunta_5", MySqlDbType.Int32).Value = adipreg5;
                cmd.Parameters.Add("_v_pregunta_5", MySqlDbType.VarChar, 250).Value = adspreg5;
                cmd.Parameters.Add("_i_pregunta_6", MySqlDbType.Int32).Value = adipreg6;
                cmd.Parameters.Add("_v_pregunta_6", MySqlDbType.VarChar, 250).Value = adspreg6;
                cmd.Parameters.Add("_i_pregunta_7", MySqlDbType.Int32).Value = adipreg7;
                cmd.Parameters.Add("_v_pregunta_7", MySqlDbType.VarChar, 250).Value = adspreg7;
                cmd.Parameters.Add("_i_pregunta_8", MySqlDbType.Int32).Value = adipreg8;
                cmd.Parameters.Add("_v_pregunta_8", MySqlDbType.VarChar, 250).Value = adspreg8;
                cmd.Parameters.Add("_i_pregunta_9", MySqlDbType.Int32).Value = adipreg9;
                cmd.Parameters.Add("_v_pregunta_9", MySqlDbType.VarChar, 250).Value = adspreg9;
                cmd.Parameters.Add("_i_pregunta_10", MySqlDbType.Int32).Value = adipreg10;
                cmd.Parameters.Add("_v_pregunta_10", MySqlDbType.VarChar, 250).Value = adspreg10;
                cmd.Parameters.Add("_v_observacion", MySqlDbType.VarChar, 500).Value = adobs;
                cmd.Parameters.Add("_b_estado", MySqlDbType.Bit).Value = adiestado;
                cmd.Parameters.Add("_dt_fecharegistro", MySqlDbType.VarChar, 25).Value = adsfechareg;
                cmd.Parameters.Add("_v_horaregistro", MySqlDbType.VarChar, 25).Value = adshorareg;
                cmd.Parameters.Add("_v_fechamodificacion", MySqlDbType.VarChar, 25).Value = adsfechamod;
                cmd.Parameters.Add("_v_horamodificacion", MySqlDbType.VarChar, 25).Value = adshoramod;

                result = Convert.ToInt32(cmd.ExecuteScalar());
                return result;
            }
            catch (Exception ex)
            {
                //utllog.towrite(utlconstantes.tprocessad, utlconstantes.lognamespace_tprocessad, this.gettype().name.tostring(), methodbase.getcurrentmethod().name, utlconstantes.logtipoerror, "", ex.stacktrace.tostring(), ex.message.tostring());
                throw ex;
            }
        }

        public List<edVotacion> adListarVotacion(int adidusuario, int adidvotacion, int adidpais, int adidregion, int adidprovincia,
                int adidciudad, int adiddistrito, string adsubigeo)
        {
            try
            {
                List<edVotacion> lstmaestro = new List<edVotacion>();
                using (MySqlCommand cmd = new MySqlCommand("sp_listar_votacion", cnMysql))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("_idusuario", MySqlDbType.Int32).Value = adidusuario;
                    cmd.Parameters.Add("_idvotacion", MySqlDbType.Int32).Value = adidvotacion;
                    cmd.Parameters.Add("_idpais", MySqlDbType.Int32).Value = adidpais;
                    cmd.Parameters.Add("_idregion", MySqlDbType.Int32).Value = adidregion;
                    cmd.Parameters.Add("_idprovincia", MySqlDbType.Int32).Value = adidprovincia;
                    cmd.Parameters.Add("_idciudad", MySqlDbType.Int32).Value = adidciudad;
                    cmd.Parameters.Add("_iddistrito", MySqlDbType.Int32).Value = adiddistrito;
                    cmd.Parameters.Add("_v_ubigeo", MySqlDbType.VarChar, 10).Value = adsubigeo;
                    using (MySqlDataReader mdrd = cmd.ExecuteReader())
                    {
                        if (mdrd != null)
                        {
                            edVotacion senUsuario = null;
                            int pos_vnombres = mdrd.GetOrdinal("v_nombres");
                            int pos_vapellidos = mdrd.GetOrdinal("v_apellidos");
                            int pos_vnombreusuario = mdrd.GetOrdinal("v_nombre_usuario");
                            int pos_idvotacion = mdrd.GetOrdinal("idvotacion");
                            int pos_idusuario = mdrd.GetOrdinal("idusuario");
                            int pos_idpais = mdrd.GetOrdinal("idpais");
                            int pos_idregion = mdrd.GetOrdinal("idregion");
                            int pos_idprovincia = mdrd.GetOrdinal("idprovincia");
                            int pos_idciudad = mdrd.GetOrdinal("idciudad");
                            int pos_iddistrito = mdrd.GetOrdinal("iddistrito");
                            int pos_vubigeo = mdrd.GetOrdinal("v_ubigeo");
                            int pos_snombre = mdrd.GetOrdinal("v_nombre");
                            int pos_sdescripcion = mdrd.GetOrdinal("v_descripcion");
                            int pos_itipovotacion = mdrd.GetOrdinal("i_tipovotacion");
                            int pos_itipotiempo = mdrd.GetOrdinal("i_tipotiempo");
                            int pos_itiempo = mdrd.GetOrdinal("i_tiempo");
                            int pos_btiempofechahora = mdrd.GetOrdinal("b_tiempo_fecha_hora");
                            int pos_dttiempofecha = mdrd.GetOrdinal("dt_tiempo_fecha");
                            int pos_dttiempohora = mdrd.GetOrdinal("dt_tiempo_hora");
                            int pos_brespuesta = mdrd.GetOrdinal("b_respuesta");
                            int pos_vrespuesta = mdrd.GetOrdinal("v_respuesta");
                            int pos_ivariasopciones = mdrd.GetOrdinal("i_varias_opciones");
                            int pos_icantidadopciones = mdrd.GetOrdinal("i_cantidad_opciones");
                            int pos_votacion_cantidad = mdrd.GetOrdinal("i_votacion_cantidad");
                            int pos_ipregunta1 = mdrd.GetOrdinal("i_pregunta_1");
                            int pos_vpregunta1 = mdrd.GetOrdinal("v_pregunta_1");
                            int pos_ipregunta2 = mdrd.GetOrdinal("i_pregunta_2");
                            int pos_vpregunta2 = mdrd.GetOrdinal("v_pregunta_2");
                            int pos_ipregunta3 = mdrd.GetOrdinal("i_pregunta_3");
                            int pos_vpregunta3 = mdrd.GetOrdinal("v_pregunta_3");
                            int pos_ipregunta4 = mdrd.GetOrdinal("i_pregunta_4");
                            int pos_vpregunta4 = mdrd.GetOrdinal("v_pregunta_4");
                            int pos_ipregunta5 = mdrd.GetOrdinal("i_pregunta_5");
                            int pos_vpregunta5 = mdrd.GetOrdinal("v_pregunta_5");
                            int pos_ipregunta6 = mdrd.GetOrdinal("i_pregunta_6");
                            int pos_vpregunta6 = mdrd.GetOrdinal("v_pregunta_6");
                            int pos_ipregunta7 = mdrd.GetOrdinal("i_pregunta_7");
                            int pos_vpregunta7 = mdrd.GetOrdinal("v_pregunta_7");
                            int pos_ipregunta8 = mdrd.GetOrdinal("i_pregunta_8");
                            int pos_vpregunta8 = mdrd.GetOrdinal("v_pregunta_8");
                            int pos_ipregunta9 = mdrd.GetOrdinal("i_pregunta_9");
                            int pos_vpregunta9 = mdrd.GetOrdinal("v_pregunta_9");
                            int pos_ipregunta10 = mdrd.GetOrdinal("i_pregunta_10");
                            int pos_vpregunta10 = mdrd.GetOrdinal("v_pregunta_10");
                            int pos_vobservacion = mdrd.GetOrdinal("v_observacion");
                            int pos_bestado = mdrd.GetOrdinal("b_estado");
                            int pos_dtfecharegistro = mdrd.GetOrdinal("dt_fecharegistro");
                            int pos_vhoraregistro = mdrd.GetOrdinal("v_horaregistro");

                            while (mdrd.Read())
                            {
                                senUsuario = new edVotacion();
                                senUsuario.snombres = (mdrd.IsDBNull(pos_vnombres) ? "-" : mdrd.GetString(pos_vnombres));
                                senUsuario.sapellidos = (mdrd.IsDBNull(pos_vapellidos) ? "-" : mdrd.GetString(pos_vapellidos));
                                senUsuario.snombre_usuario = (mdrd.IsDBNull(pos_vnombreusuario) ? "-" : mdrd.GetString(pos_vnombreusuario));
                                senUsuario.idvotacion = (mdrd.IsDBNull(pos_idvotacion) ? 0 : mdrd.GetInt32(pos_idvotacion));
                                senUsuario.idusuario = (mdrd.IsDBNull(pos_idusuario) ? 0 : mdrd.GetInt32(pos_idusuario));
                                senUsuario.idpais = (mdrd.IsDBNull(pos_idpais) ? 0 : mdrd.GetInt32(pos_idpais));
                                senUsuario.idregion = (mdrd.IsDBNull(pos_idregion) ? 0 : mdrd.GetInt32(pos_idregion));
                                senUsuario.idprovincia = (mdrd.IsDBNull(pos_idprovincia) ? 0 : mdrd.GetInt32(pos_idprovincia));
                                senUsuario.idciudad = (mdrd.IsDBNull(pos_idciudad) ? 0 : mdrd.GetInt32(pos_idciudad));
                                senUsuario.iddistrito = (mdrd.IsDBNull(pos_iddistrito) ? 0 : mdrd.GetInt32(pos_iddistrito));
                                senUsuario.subigeo = (mdrd.IsDBNull(pos_vubigeo) ? "-" : mdrd.GetString(pos_vubigeo));
                                senUsuario.snombre = (mdrd.IsDBNull(pos_snombre) ? "-" : mdrd.GetString(pos_snombre));
                                senUsuario.sdescripcion = (mdrd.IsDBNull(pos_sdescripcion) ? "-" : mdrd.GetString(pos_sdescripcion));
                                senUsuario.itipovotacion = (mdrd.IsDBNull(pos_itipovotacion) ? 0 : mdrd.GetInt32(pos_itipovotacion));
                                senUsuario.itipotiempo = (mdrd.IsDBNull(pos_itipotiempo) ? 0 : mdrd.GetInt32(pos_itipotiempo));
                                senUsuario.itiempo = (mdrd.IsDBNull(pos_itiempo) ? 0 : mdrd.GetInt32(pos_itiempo));
                                senUsuario.itiempo_fecha_hora = (mdrd.IsDBNull(pos_btiempofechahora) ? 0 : mdrd.GetInt32(pos_btiempofechahora));
                                senUsuario.stiempo_fecha = (mdrd.IsDBNull(pos_dttiempofecha) ? "-" : mdrd.GetString(pos_dttiempofecha));
                                senUsuario.stiempo_hora = (mdrd.IsDBNull(pos_dttiempohora) ? "-" : mdrd.GetString(pos_dttiempohora));
                                senUsuario.irespuesta = (mdrd.IsDBNull(pos_brespuesta) ? 0 : mdrd.GetInt32(pos_brespuesta));
                                senUsuario.srespuesta = (mdrd.IsDBNull(pos_vrespuesta) ? "-" : mdrd.GetString(pos_vrespuesta));
                                senUsuario.ivarias_opciones = (mdrd.IsDBNull(pos_ivariasopciones) ? 0 : mdrd.GetInt32(pos_ivariasopciones));
                                senUsuario.icantidad_opciones = (mdrd.IsDBNull(pos_icantidadopciones) ? 0 : mdrd.GetInt32(pos_icantidadopciones));
                                senUsuario.ivotacion_cantidad = (mdrd.IsDBNull(pos_votacion_cantidad) ? 0 : mdrd.GetInt32(pos_votacion_cantidad));
                                senUsuario.ipregunta_1 = (mdrd.IsDBNull(pos_ipregunta1) ? 0 : mdrd.GetInt32(pos_ipregunta1));
                                senUsuario.spregunta_1 = (mdrd.IsDBNull(pos_vpregunta1) ? "-" : mdrd.GetString(pos_vpregunta1));
                                senUsuario.ipregunta_2 = (mdrd.IsDBNull(pos_ipregunta2) ? 0 : mdrd.GetInt32(pos_ipregunta2));
                                senUsuario.spregunta_2 = (mdrd.IsDBNull(pos_vpregunta2) ? "-" : mdrd.GetString(pos_vpregunta2));
                                senUsuario.ipregunta_3 = (mdrd.IsDBNull(pos_ipregunta3) ? 0 : mdrd.GetInt32(pos_ipregunta3));
                                senUsuario.spregunta_3 = (mdrd.IsDBNull(pos_vpregunta3) ? "-" : mdrd.GetString(pos_vpregunta3));
                                senUsuario.ipregunta_4 = (mdrd.IsDBNull(pos_ipregunta4) ? 0 : mdrd.GetInt32(pos_ipregunta4));
                                senUsuario.spregunta_4 = (mdrd.IsDBNull(pos_vpregunta4) ? "-" : mdrd.GetString(pos_vpregunta4));
                                senUsuario.ipregunta_5 = (mdrd.IsDBNull(pos_ipregunta5) ? 0 : mdrd.GetInt32(pos_ipregunta5));
                                senUsuario.spregunta_5 = (mdrd.IsDBNull(pos_vpregunta5) ? "-" : mdrd.GetString(pos_vpregunta5));
                                senUsuario.ipregunta_6 = (mdrd.IsDBNull(pos_ipregunta6) ? 0 : mdrd.GetInt32(pos_ipregunta6));
                                senUsuario.spregunta_6 = (mdrd.IsDBNull(pos_vpregunta6) ? "-" : mdrd.GetString(pos_vpregunta6));
                                senUsuario.ipregunta_7 = (mdrd.IsDBNull(pos_ipregunta7) ? 0 : mdrd.GetInt32(pos_ipregunta7));
                                senUsuario.spregunta_7 = (mdrd.IsDBNull(pos_vpregunta7) ? "-" : mdrd.GetString(pos_vpregunta7));
                                senUsuario.ipregunta_8 = (mdrd.IsDBNull(pos_ipregunta8) ? 0 : mdrd.GetInt32(pos_ipregunta8));
                                senUsuario.spregunta_8 = (mdrd.IsDBNull(pos_vpregunta8) ? "-" : mdrd.GetString(pos_vpregunta8));
                                senUsuario.ipregunta_9 = (mdrd.IsDBNull(pos_ipregunta9) ? 0 : mdrd.GetInt32(pos_ipregunta9));
                                senUsuario.spregunta_9 = (mdrd.IsDBNull(pos_vpregunta9) ? "-" : mdrd.GetString(pos_vpregunta9));
                                senUsuario.ipregunta_10 = (mdrd.IsDBNull(pos_ipregunta10) ? 0 : mdrd.GetInt32(pos_ipregunta10));
                                senUsuario.spregunta_10 = (mdrd.IsDBNull(pos_vpregunta10) ? "-" : mdrd.GetString(pos_vpregunta10));
                                senUsuario.sobservacion = (mdrd.IsDBNull(pos_vobservacion) ? "-" : mdrd.GetString(pos_vobservacion));
                                senUsuario.iestado = (mdrd.IsDBNull(pos_bestado) ? 0 : mdrd.GetInt32(pos_bestado));
                                senUsuario.sfecharegistro = (mdrd.IsDBNull(pos_dtfecharegistro) ? "-" : mdrd.GetString(pos_dtfecharegistro));
                                senUsuario.shoraregistro = (mdrd.IsDBNull(pos_vhoraregistro) ? "-" : mdrd.GetString(pos_vhoraregistro));

                                lstmaestro.Add(senUsuario);
                            }
                        }
                    }
                    return lstmaestro;
                }
            }
            catch (Exception ex)
            {
                //UtlLog.toWrite(UtlConstantes.TProcessAD, UtlConstantes.LogNamespace_TProcessAD, this.GetType().Name.ToString(), MethodBase.GetCurrentMethod().Name, UtlConstantes.LogTipoError, "", ex.StackTrace.ToString(), ex.Message.ToString());
                throw ex;
            }
        }

        public int adInsertarVotacionUsuario(int aditipoactualizar, int adidvotacionusuario, int adidvotacion, int adidusuario,
            string adsrepuesta, int adicantopc, int adipregunta1, int adipregunta2, int adipregunta3, int adipregunta4, int adipregunta5,
            int adipregunta6, int adipregunta7, int adipregunta8, int adipregunta9, int adipregunta10, string adobservacion,
            int adiestado, string adsfechareg, string adshorareg, string adsfechamod, string adshoramod)
        {
            try
            {
                int result = -2;
                MySqlCommand cmd = new MySqlCommand("sp_operacion_vot_usuario", cnMysql);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("_tipoactualizar", MySqlDbType.Int32).Value = aditipoactualizar;
                cmd.Parameters.Add("_idvotacion_usuario", MySqlDbType.Int32).Value = adidvotacionusuario;
                cmd.Parameters.Add("_idvotacion", MySqlDbType.Int32).Value = adidvotacion;
                cmd.Parameters.Add("_idusuario", MySqlDbType.Int32).Value = adidusuario;
                cmd.Parameters.Add("_v_respuesta", MySqlDbType.VarChar, 500).Value = adsrepuesta;
                cmd.Parameters.Add("_i_cantidad_opciones", MySqlDbType.Int32).Value = adicantopc;
                cmd.Parameters.Add("_i_pregunta_1", MySqlDbType.Int32).Value = adipregunta1;
                cmd.Parameters.Add("_i_pregunta_2", MySqlDbType.Int32).Value = adipregunta2;
                cmd.Parameters.Add("_i_pregunta_3", MySqlDbType.Int32).Value = adipregunta3;
                cmd.Parameters.Add("_i_pregunta_4", MySqlDbType.Int32).Value = adipregunta4;
                cmd.Parameters.Add("_i_pregunta_5", MySqlDbType.Int32).Value = adipregunta5;
                cmd.Parameters.Add("_i_pregunta_6", MySqlDbType.Int32).Value = adipregunta6;
                cmd.Parameters.Add("_i_pregunta_7", MySqlDbType.Int32).Value = adipregunta7;
                cmd.Parameters.Add("_i_pregunta_8", MySqlDbType.Int32).Value = adipregunta8;
                cmd.Parameters.Add("_i_pregunta_9", MySqlDbType.Int32).Value = adipregunta9;
                cmd.Parameters.Add("_i_pregunta_10", MySqlDbType.Int32).Value = adipregunta10;
                cmd.Parameters.Add("_v_observacion", MySqlDbType.VarChar, 500).Value = adobservacion;
                cmd.Parameters.Add("_b_estado", MySqlDbType.Bit).Value = adiestado;
                cmd.Parameters.Add("_dt_fecharegistro", MySqlDbType.VarChar, 25).Value = adsfechareg;
                cmd.Parameters.Add("_v_horaregistro", MySqlDbType.VarChar, 25).Value = adshorareg;
                cmd.Parameters.Add("_v_fechamodificacion", MySqlDbType.VarChar, 25).Value = adsfechamod;
                cmd.Parameters.Add("_v_horamodificacion", MySqlDbType.VarChar, 25).Value = adshoramod;


                result = Convert.ToInt32(cmd.ExecuteScalar());
                return result;
            }
            catch (Exception ex)
            {
                //utllog.towrite(utlconstantes.tprocessad, utlconstantes.lognamespace_tprocessad, this.gettype().name.tostring(), methodbase.getcurrentmethod().name, utlconstantes.logtipoerror, "", ex.stacktrace.tostring(), ex.message.tostring());
                throw ex;
            }
        }

        public List<edVotacionUsuario> adListarVotacionUsuario(int adidusuario, int adidvotacionusuario)
        {
            try
            {
                List<edVotacionUsuario> lstmaestro = new List<edVotacionUsuario>();
                using (MySqlCommand cmd = new MySqlCommand("sp_listar_vot_usuario", cnMysql))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("_idusuario", MySqlDbType.Int32).Value = adidusuario;
                    cmd.Parameters.Add("_idvotacionusuario", MySqlDbType.Int32).Value = adidvotacionusuario;
                    using (MySqlDataReader mdrd = cmd.ExecuteReader())
                    {
                        if (mdrd != null)
                        {
                            edVotacionUsuario senUsuario = null;
                            int pos_vnombres = mdrd.GetOrdinal("v_nombres");
                            int pos_vapellidos = mdrd.GetOrdinal("v_apellidos");
                            int pos_vnombreusuario = mdrd.GetOrdinal("v_nombre_usuario");
                            int pos_idvotacionusuario = mdrd.GetOrdinal("idvotacion_usuario");
                            int pos_idvotacion = mdrd.GetOrdinal("idvotacion");
                            int pos_idusuario = mdrd.GetOrdinal("idusuario");
                            int pos_vrespuesta = mdrd.GetOrdinal("v_respuesta");
                            int pos_icantidadopciones = mdrd.GetOrdinal("i_cantidad_opciones");
                            int pos_ipregunta1 = mdrd.GetOrdinal("i_pregunta_1");
                            int pos_ipregunta2 = mdrd.GetOrdinal("i_pregunta_2");
                            int pos_ipregunta3 = mdrd.GetOrdinal("i_pregunta_3");
                            int pos_ipregunta4 = mdrd.GetOrdinal("i_pregunta_4");
                            int pos_ipregunta5 = mdrd.GetOrdinal("i_pregunta_5");
                            int pos_ipregunta6 = mdrd.GetOrdinal("i_pregunta_6");
                            int pos_ipregunta7 = mdrd.GetOrdinal("i_pregunta_7");
                            int pos_ipregunta8 = mdrd.GetOrdinal("i_pregunta_8");
                            int pos_ipregunta9 = mdrd.GetOrdinal("i_pregunta_9");
                            int pos_ipregunta10 = mdrd.GetOrdinal("i_pregunta_10");
                            int pos_vobservacion = mdrd.GetOrdinal("v_observacion");
                            int pos_bestado = mdrd.GetOrdinal("b_estado");
                            int pos_dtfecharegistro = mdrd.GetOrdinal("dt_fecharegistro");
                            int pos_vhoraregistro = mdrd.GetOrdinal("v_horaregistro");

                            while (mdrd.Read())
                            {
                                senUsuario = new edVotacionUsuario();
                                senUsuario.snombres = (mdrd.IsDBNull(pos_vnombres) ? "-" : mdrd.GetString(pos_vnombres));
                                senUsuario.sapellidos = (mdrd.IsDBNull(pos_vapellidos) ? "-" : mdrd.GetString(pos_vapellidos));
                                senUsuario.snombre_usuario = (mdrd.IsDBNull(pos_vnombreusuario) ? "-" : mdrd.GetString(pos_vnombreusuario));
                                senUsuario.idvotacion = (mdrd.IsDBNull(pos_idvotacionusuario) ? 0 : mdrd.GetInt32(pos_idvotacionusuario));
                                senUsuario.idusuario = (mdrd.IsDBNull(pos_idvotacion) ? 0 : mdrd.GetInt32(pos_idvotacion));
                                senUsuario.idusuario = (mdrd.IsDBNull(pos_idusuario) ? 0 : mdrd.GetInt32(pos_idusuario));
                                senUsuario.srespuesta = (mdrd.IsDBNull(pos_vrespuesta) ? "-" : mdrd.GetString(pos_vrespuesta));
                                senUsuario.icantidad_opciones = (mdrd.IsDBNull(pos_icantidadopciones) ? 0 : mdrd.GetInt32(pos_icantidadopciones));
                                senUsuario.ipregunta_1 = (mdrd.IsDBNull(pos_ipregunta1) ? 0 : mdrd.GetInt32(pos_ipregunta1));
                                senUsuario.ipregunta_2 = (mdrd.IsDBNull(pos_ipregunta2) ? 0 : mdrd.GetInt32(pos_ipregunta2));
                                senUsuario.ipregunta_3 = (mdrd.IsDBNull(pos_ipregunta3) ? 0 : mdrd.GetInt32(pos_ipregunta3));
                                senUsuario.ipregunta_4 = (mdrd.IsDBNull(pos_ipregunta4) ? 0 : mdrd.GetInt32(pos_ipregunta4));
                                senUsuario.ipregunta_5 = (mdrd.IsDBNull(pos_ipregunta5) ? 0 : mdrd.GetInt32(pos_ipregunta5));
                                senUsuario.ipregunta_6 = (mdrd.IsDBNull(pos_ipregunta6) ? 0 : mdrd.GetInt32(pos_ipregunta6));
                                senUsuario.ipregunta_7 = (mdrd.IsDBNull(pos_ipregunta7) ? 0 : mdrd.GetInt32(pos_ipregunta7));
                                senUsuario.ipregunta_8 = (mdrd.IsDBNull(pos_ipregunta8) ? 0 : mdrd.GetInt32(pos_ipregunta8));
                                senUsuario.ipregunta_9 = (mdrd.IsDBNull(pos_ipregunta9) ? 0 : mdrd.GetInt32(pos_ipregunta9));
                                senUsuario.ipregunta_10 = (mdrd.IsDBNull(pos_ipregunta10) ? 0 : mdrd.GetInt32(pos_ipregunta10));
                                senUsuario.sobservacion = (mdrd.IsDBNull(pos_vobservacion) ? "-" : mdrd.GetString(pos_vobservacion));
                                senUsuario.iestado = (mdrd.IsDBNull(pos_bestado) ? 0 : mdrd.GetInt32(pos_bestado));
                                senUsuario.sfecharegistro = (mdrd.IsDBNull(pos_dtfecharegistro) ? "-" : mdrd.GetString(pos_dtfecharegistro));
                                senUsuario.shoraregistro = (mdrd.IsDBNull(pos_vhoraregistro) ? "-" : mdrd.GetString(pos_vhoraregistro));

                                lstmaestro.Add(senUsuario);
                            }
                        }
                    }
                    return lstmaestro;
                }
            }
            catch (Exception ex)
            {
                //UtlLog.toWrite(UtlConstantes.TProcessAD, UtlConstantes.LogNamespace_TProcessAD, this.GetType().Name.ToString(), MethodBase.GetCurrentMethod().Name, UtlConstantes.LogTipoError, "", ex.StackTrace.ToString(), ex.Message.ToString());
                throw ex;
            }
        }

    }
}
