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
    public class adUsuario : ad_aglobal
    {
        public adUsuario(MySqlConnection cn)
        {
            cnMysql = cn;
        }


        public edUsuario adObtenerUsuario(string adcorreo, string adclave)
        {
            try
            {
                edUsuario senUsuario = null;
                using (MySqlCommand cmd = new MySqlCommand("sp_obtener_usuario", cnMysql))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("_usuario", MySqlDbType.VarChar, 100).Value = adcorreo;
                    cmd.Parameters.Add("_clave", MySqlDbType.VarChar, 500).Value = adclave;

                    using (MySqlDataReader mdrd = cmd.ExecuteReader())
                    {
                        if (mdrd != null)
                        {
                            int pos_idusuario = mdrd.GetOrdinal("idusuario");
                            int pos_vnombres = mdrd.GetOrdinal("v_nombres");
                            int pos_vapellidos = mdrd.GetOrdinal("v_apellidos");
                            int pos_vnombreusuario = mdrd.GetOrdinal("v_nombre_usuario");
                            int pos_igenero = mdrd.GetOrdinal("i_genero");
                            int pos_idpais = mdrd.GetOrdinal("idpais");
                            int pos_idregion = mdrd.GetOrdinal("idregion");
                            int pos_idprovincia = mdrd.GetOrdinal("idprovincia");
                            int pos_idciudad = mdrd.GetOrdinal("idciudad");
                            int pos_iddistrito = mdrd.GetOrdinal("iddistrito");
                            int pos_vubigeo = mdrd.GetOrdinal("v_ubigeo");
                            int pos_vcorreo = mdrd.GetOrdinal("v_correo");
                            int pos_itipousuario = mdrd.GetOrdinal("i_tipo_usuario");
                            int pos_resultado = mdrd.GetOrdinal("_resultado");

                            while (mdrd.Read())
                            {
                                senUsuario = new edUsuario();
                                senUsuario.idusuario = (mdrd.IsDBNull(pos_idusuario) ? 0 : mdrd.GetInt32(pos_idusuario));
                                senUsuario.snombres = (mdrd.IsDBNull(pos_vnombres) ? "-" : mdrd.GetString(pos_vnombres));
                                senUsuario.sapellidos = (mdrd.IsDBNull(pos_vapellidos) ? "-" : mdrd.GetString(pos_vapellidos));
                                senUsuario.snombre_usuario = (mdrd.IsDBNull(pos_vnombreusuario) ? "-" : mdrd.GetString(pos_vnombreusuario));
                                senUsuario.igenero = (mdrd.IsDBNull(pos_igenero) ? 0 : mdrd.GetInt32(pos_igenero));
                                senUsuario.idpais = (mdrd.IsDBNull(pos_idpais) ? 0 : mdrd.GetInt32(pos_idpais));
                                senUsuario.idregion = (mdrd.IsDBNull(pos_idregion) ? 0 : mdrd.GetInt32(pos_idregion));
                                senUsuario.idprovincia = (mdrd.IsDBNull(pos_idprovincia) ? 0 : mdrd.GetInt32(pos_idprovincia));
                                senUsuario.idciudad = (mdrd.IsDBNull(pos_idciudad) ? 0 : mdrd.GetInt32(pos_idciudad));
                                senUsuario.iddistrito = (mdrd.IsDBNull(pos_iddistrito) ? 0 : mdrd.GetInt32(pos_iddistrito));
                                senUsuario.subigeo = (mdrd.IsDBNull(pos_vubigeo) ? "-" : mdrd.GetString(pos_vubigeo));
                                senUsuario.scorreo = (mdrd.IsDBNull(pos_vcorreo) ? "-" : mdrd.GetString(pos_vcorreo));
                                senUsuario.itipousuario = (mdrd.IsDBNull(pos_itipousuario) ? 0 : mdrd.GetInt32(pos_itipousuario));
                                senUsuario._resultado = (mdrd.IsDBNull(pos_resultado) ? 0 : mdrd.GetInt32(pos_resultado));
                            }
                        }
                    }
                    return senUsuario;
                }
            }
            catch (Exception ex)
            {
                //UtlLog.toWrite(UtlConstantes.TProcessAD, UtlConstantes.LogNamespace_TProcessAD, this.GetType().Name.ToString(), MethodBase.GetCurrentMethod().Name, UtlConstantes.LogTipoError, "", ex.StackTrace.ToString(), ex.Message.ToString());
                throw ex;
            }
        }

        public int adInsertarUsuario(string adnombres, string adapellidos, int igenero, int adidregion,int adidprovincia,
            int adidciudad, int adiddistrito, string adubigeo, string simagenperfil, string simagenportada, string adfechanacimiento,
            int adbestado, string adfecharegistro, string adhoraregistro, int adtipousuario, string adcorreo, 
            string adclave, string adtoken)
        {
            try
            {
                int result = -2;
                MySqlCommand cmd = new MySqlCommand("sp_insertar_usuario", cnMysql);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("_v_nombres", MySqlDbType.VarChar, 100).Value = adnombres;
                cmd.Parameters.Add("_v_apellidos", MySqlDbType.VarChar, 100).Value = adapellidos;
                cmd.Parameters.Add("_v_nombre_usuario", MySqlDbType.VarChar, 100).Value = adapellidos;
                cmd.Parameters.Add("_i_genero", MySqlDbType.Int32).Value = igenero;
                cmd.Parameters.Add("_idregion", MySqlDbType.Int32).Value = adidregion;
                cmd.Parameters.Add("_idprovincia", MySqlDbType.Int32).Value = adidprovincia;
                cmd.Parameters.Add("_idciudad", MySqlDbType.Int32).Value = adidciudad;
                cmd.Parameters.Add("_iddistrito", MySqlDbType.Int32).Value = adiddistrito;
                cmd.Parameters.Add("_v_ubigeo", MySqlDbType.VarChar, 10).Value = adubigeo;
                cmd.Parameters.Add("_v_imagenperfil", MySqlDbType.VarChar, 250).Value = simagenperfil;
                cmd.Parameters.Add("_v_imagenportada", MySqlDbType.VarChar, 250).Value = simagenportada;
                cmd.Parameters.Add("_v_fechanacimiento", MySqlDbType.VarChar, 25).Value = adfechanacimiento;
                cmd.Parameters.Add("_b_estado", MySqlDbType.Bit).Value = adbestado;
                cmd.Parameters.Add("_dt_fecharegistro", MySqlDbType.VarChar, 25).Value = adfecharegistro;
                cmd.Parameters.Add("_v_horaregistro", MySqlDbType.VarChar, 25).Value = adhoraregistro;
                cmd.Parameters.Add("_i_tipo_usuario", MySqlDbType.Int32).Value = adtipousuario;
                cmd.Parameters.Add("_v_correo", MySqlDbType.VarChar, 100).Value = adcorreo;
                cmd.Parameters.Add("_v_clave", MySqlDbType.VarChar, 500).Value = adclave;
                cmd.Parameters.Add("_v_token", MySqlDbType.VarChar, 500).Value = adtoken;

                result = Convert.ToInt32(cmd.ExecuteScalar());
                return result;
            }
            catch (Exception ex)
            {
                //utllog.towrite(utlconstantes.tprocessad, utlconstantes.lognamespace_tprocessad, this.gettype().name.tostring(), methodbase.getcurrentmethod().name, utlconstantes.logtipoerror, "", ex.stacktrace.tostring(), ex.message.tostring());
                throw ex;
            }
        }

        //adtipoactualizar: 1 par actualizar, 2 para deshabilitar la cuenta
        public int adActualizarAcceso(int adtipoactualizar, int adidusuario, string adcorreo, string adclave)
        {
            try
            {
                int result = -1;
                MySqlCommand cmd = new MySqlCommand("sp_actualizar_acceso", cnMysql);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("_tipoactualizar", MySqlDbType.Int32).Value = adtipoactualizar;
                cmd.Parameters.Add("_idusuario", MySqlDbType.Int32).Value = adidusuario;
                cmd.Parameters.Add("_v_correo", MySqlDbType.VarChar, 100).Value = adcorreo;
                cmd.Parameters.Add("_v_clave", MySqlDbType.VarChar, 500).Value = adclave;
                result = Convert.ToInt32(cmd.ExecuteNonQuery());

                return result;
            }
            catch (Exception ex)
            {
                //utllog.towrite(utlconstantes.tprocessad, utlconstantes.lognamespace_tprocessad, this.gettype().name.tostring(), methodbase.getcurrentmethod().name, utlconstantes.logtipoerror, "", ex.stacktrace.tostring(), ex.message.tostring());
                throw ex;
            }
        }

        public int adActualizarClave(int adidusuario, string adnuevaclave)
        {
            try
            {
                int result = -1;
                MySqlCommand cmd = new MySqlCommand("sp_actualizar_clave", cnMysql);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("_idusuario", MySqlDbType.Int32).Value = adidusuario;
                cmd.Parameters.Add("_nuevaclave", MySqlDbType.VarChar, 500).Value = adnuevaclave;
                result = Convert.ToInt32(cmd.ExecuteNonQuery());
                return result;
            }
            catch (Exception ex)
            {
                //utllog.towrite(utlconstantes.tprocessad, utlconstantes.lognamespace_tprocessad, this.gettype().name.tostring(), methodbase.getcurrentmethod().name, utlconstantes.logtipoerror, "", ex.stacktrace.tostring(), ex.message.tostring());
                throw ex;
            }
        }

        public int adActualizarCuenta(int adidusuario,int idpais, int adidprovincia, int adidciudad, int adiddistrito, 
            string adsubigeo,string adnombres, string adapellidos, string adsnombreusuario, string adsdireccion,
            string addireccion2, int adigenero, string adscorreo2, string adfacebook, string adinstagram, string adtwitter,
            string adimagenperfil, string adimagenportada, string adcelular1, string adfechanacimiento, string adfechamodificacion,
            string adhoramodificacion, int adbestado)
        {
            try
            {
                int result = -2;
                MySqlCommand cmd = new MySqlCommand("sp_actualizar_usuario", cnMysql);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("_idusuario", MySqlDbType.Int32).Value = adidusuario;
                cmd.Parameters.Add("_idpais", MySqlDbType.Int32).Value = idpais;
                cmd.Parameters.Add("_idprovincia", MySqlDbType.Int32).Value = adidprovincia;
                cmd.Parameters.Add("_idciudad", MySqlDbType.Int32).Value = adidciudad;
                cmd.Parameters.Add("_iddistrito", MySqlDbType.Int32).Value = adiddistrito;
                cmd.Parameters.Add("_v_ubigeo", MySqlDbType.VarChar, 10).Value = adsubigeo;
                cmd.Parameters.Add("_v_nombres", MySqlDbType.VarChar, 100).Value = adnombres;
                cmd.Parameters.Add("_v_apellidos", MySqlDbType.VarChar, 100).Value = adapellidos;
                cmd.Parameters.Add("_v_nombre_usuario", MySqlDbType.VarChar, 100).Value = adsnombreusuario;
                cmd.Parameters.Add("_v_direccion", MySqlDbType.VarChar, 150).Value = adsdireccion;
                cmd.Parameters.Add("_v_direccion2", MySqlDbType.VarChar, 150).Value = addireccion2;
                cmd.Parameters.Add("_i_genero", MySqlDbType.Int32).Value = adigenero;
                cmd.Parameters.Add("_v_correo2", MySqlDbType.VarChar, 150).Value = adscorreo2;
                cmd.Parameters.Add("_v_facebook", MySqlDbType.VarChar, 250).Value = adfacebook;
                cmd.Parameters.Add("_v_instagram", MySqlDbType.VarChar, 250).Value = adinstagram;
                cmd.Parameters.Add("_v_twitter", MySqlDbType.VarChar, 250).Value = adtwitter;
                cmd.Parameters.Add("_v_imagenperfil", MySqlDbType.VarChar, 250).Value = adimagenperfil;
                cmd.Parameters.Add("_v_imagenportada", MySqlDbType.VarChar, 250).Value = adimagenportada;
                cmd.Parameters.Add("_v_celular1", MySqlDbType.VarChar, 15).Value = adcelular1;
                cmd.Parameters.Add("_v_fechanacimiento", MySqlDbType.VarChar, 25).Value = adfechanacimiento;
                cmd.Parameters.Add("_v_fechamodificacion", MySqlDbType.VarChar, 25).Value = adfechamodificacion;
                cmd.Parameters.Add("_v_horamodificacion", MySqlDbType.VarChar, 25).Value = adhoramodificacion;
                cmd.Parameters.Add("_b_estado", MySqlDbType.Bit).Value = adbestado;
                result = Convert.ToInt32(cmd.ExecuteScalar());
                return result;
            }
            catch (Exception ex)
            {
                //UtlLog.toWrite(UtlConstantes.ventaAD, UtlConstantes.LogNamespace_ventaAD, this.GetType().Name.ToString(), MethodBase.GetCurrentMethod().Name, UtlConstantes.LogTipoError, "", ex.StackTrace.ToString(), ex.Message.ToString());
                throw ex;
            }
        }

        public edUsuario adFiltrarUsuario(int adusuario, int adbestado)
        {
            try
            {
                edUsuario senUsuario = null;
                using (MySqlCommand cmd = new MySqlCommand("sp_filtrar_usuario", cnMysql))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("_idusuario", MySqlDbType.Int32).Value = adusuario;
                    cmd.Parameters.Add("_bestado", MySqlDbType.Bit).Value = adbestado;
                    using (MySqlDataReader mdrd = cmd.ExecuteReader())
                    {
                        if (mdrd != null)
                        {
                            int pos_idusuario = mdrd.GetOrdinal("idusuario");
                            int pos_idpais = mdrd.GetOrdinal("idpais");
                            int pos_idprovincia = mdrd.GetOrdinal("idprovincia");
                            int pos_idciudad = mdrd.GetOrdinal("idciudad");
                            int pos_iddistrito = mdrd.GetOrdinal("iddistrito");
                            int pos_vubigeo = mdrd.GetOrdinal("v_ubigeo");
                            int pos_vnombres = mdrd.GetOrdinal("v_nombres");
                            int pos_vapellidos = mdrd.GetOrdinal("v_apellidos");
                            int pos_vnombreusuario = mdrd.GetOrdinal("v_nombre_usuario");
                            int pos_vdireccion = mdrd.GetOrdinal("v_direccion");
                            int pos_vdireccion2 = mdrd.GetOrdinal("v_direccion2");
                            int pos_igenero = mdrd.GetOrdinal("i_genero");
                            int pos_vcorreo2 = mdrd.GetOrdinal("v_correo2");
                            int pos_vfacebook = mdrd.GetOrdinal("v_facebook");
                            int pos_vinstagram = mdrd.GetOrdinal("v_instagram");
                            int pos_vtwitter = mdrd.GetOrdinal("v_twitter");
                            int pos_vimagenperfil = mdrd.GetOrdinal("v_imagenperfil");
                            int pos_vimagenportada = mdrd.GetOrdinal("v_imagenportada");
                            int pos_vcelular1 = mdrd.GetOrdinal("v_celular1");
                            int pos_vfechanacimiento = mdrd.GetOrdinal("v_fechanacimiento");

                            while (mdrd.Read())
                            {
                                senUsuario = new edUsuario();
                                senUsuario.idusuario = (mdrd.IsDBNull(pos_idusuario) ? 0 : mdrd.GetInt32(pos_idusuario));
                                senUsuario.idpais = (mdrd.IsDBNull(pos_idpais) ? 0 : mdrd.GetInt32(pos_idpais));
                                senUsuario.idprovincia = (mdrd.IsDBNull(pos_idprovincia) ? 0 : mdrd.GetInt32(pos_idprovincia));
                                senUsuario.idciudad = (mdrd.IsDBNull(pos_idciudad) ? 0 : mdrd.GetInt32(pos_idciudad));
                                senUsuario.iddistrito = (mdrd.IsDBNull(pos_iddistrito) ? 0 : mdrd.GetInt32(pos_iddistrito));
                                senUsuario.subigeo = (mdrd.IsDBNull(pos_vubigeo) ? "-" : mdrd.GetString(pos_vubigeo));
                                senUsuario.snombres = (mdrd.IsDBNull(pos_vnombres) ? "-" : mdrd.GetString(pos_vnombres));
                                senUsuario.sapellidos = (mdrd.IsDBNull(pos_vapellidos) ? "-" : mdrd.GetString(pos_vapellidos));
                                senUsuario.snombre_usuario = (mdrd.IsDBNull(pos_vnombreusuario) ? "-" : mdrd.GetString(pos_vnombreusuario));
                                senUsuario.sdireccion = (mdrd.IsDBNull(pos_vdireccion) ? "-" : mdrd.GetString(pos_vdireccion));
                                senUsuario.sdireccion2 = (mdrd.IsDBNull(pos_vdireccion2) ? "-" : mdrd.GetString(pos_vdireccion2));
                                senUsuario.igenero = (mdrd.IsDBNull(pos_igenero) ? 0 : mdrd.GetInt32(pos_igenero));
                                senUsuario.scorreo2 = (mdrd.IsDBNull(pos_vcorreo2) ? "-" : mdrd.GetString(pos_vcorreo2));
                                senUsuario.sfacebook = (mdrd.IsDBNull(pos_vfacebook) ? "-" : mdrd.GetString(pos_vfacebook));
                                senUsuario.sinstagram = (mdrd.IsDBNull(pos_vinstagram) ? "-" : mdrd.GetString(pos_vinstagram));
                                senUsuario.stwitter = (mdrd.IsDBNull(pos_vtwitter) ? "-" : mdrd.GetString(pos_vtwitter));
                                senUsuario.simagenperfil = (mdrd.IsDBNull(pos_vimagenperfil) ? "-" : mdrd.GetString(pos_vimagenperfil));
                                senUsuario.simagenportada = (mdrd.IsDBNull(pos_vimagenportada) ? "-" : mdrd.GetString(pos_vimagenportada));
                                senUsuario.scelular1 = (mdrd.IsDBNull(pos_vcelular1) ? "-" : mdrd.GetString(pos_vcelular1));
                                senUsuario.sfechanacimiento = (mdrd.IsDBNull(pos_vfechanacimiento) ? "-" : mdrd.GetString(pos_vfechanacimiento));
                            }
                        }
                    }
                    return senUsuario;
                }
            }
            catch (Exception ex)
            {
                //UtlLog.toWrite(UtlConstantes.TProcessAD, UtlConstantes.LogNamespace_TProcessAD, this.GetType().Name.ToString(), MethodBase.GetCurrentMethod().Name, UtlConstantes.LogTipoError, "", ex.StackTrace.ToString(), ex.Message.ToString());
                throw ex;
            }
        }


        
        //#region POR AGREGAR

        //public int test(int adidalumno, string addireccionip, string addireccionmac, int adtipoconexion)
        //{
        //    try
        //    {
        //        int result = -1;
        //        MySqlCommand cmd = new MySqlCommand("spalumno_registro", cnMysql);
        //        cmd.CommandType = CommandType.StoredProcedure;
        //        cmd.Parameters.Add("@_idalumno", MySqlDbType.Int32).Value = adidalumno;
        //        cmd.Parameters.Add("@_direccionip", MySqlDbType.VarChar, 150).Value = addireccionip;
        //        cmd.Parameters.Add("@_direccionmac", MySqlDbType.VarChar, 150).Value = addireccionmac;
        //        cmd.Parameters.Add("@_tipoconexion", MySqlDbType.Int32).Value = adtipoconexion;

        //        result = Convert.ToInt32(cmd.ExecuteScalar());

        //        return result;
        //    }
        //    catch (Exception ex)
        //    {
        //        //utllog.towrite(utlconstantes.tprocessad, utlconstantes.lognamespace_tprocessad, this.gettype().name.tostring(), methodbase.getcurrentmethod().name, utlconstantes.logtipoerror, "", ex.stacktrace.tostring(), ex.message.tostring());
        //        throw ex;
        //    }
        //}

        //#endregion

    }
}
