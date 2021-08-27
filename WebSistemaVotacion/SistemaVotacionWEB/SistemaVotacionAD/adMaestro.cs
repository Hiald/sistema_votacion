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
    public class adMaestro: ad_aglobal
    {
        public adMaestro(MySqlConnection cn)
        {
            cnMysql = cn;
        }

        public List<edMaestro> adListarMaestro(int adidmaestro)
        {
            try
            {
                List<edMaestro> lstmaestro = new List<edMaestro>();
                using (MySqlCommand cmd = new MySqlCommand("sp_listar_maestro", cnMysql))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("_idmaestro", MySqlDbType.Int32).Value = adidmaestro;
                    using (MySqlDataReader mdrd = cmd.ExecuteReader())
                    {
                        if (mdrd != null)
                        {
                            edMaestro senUsuario = null;
                            int pos_idparametro = mdrd.GetOrdinal("idparametro");
                            int pos_idmaestro = mdrd.GetOrdinal("idmaestro");
                            int pos_snombre = mdrd.GetOrdinal("v_nombre");
                            int pos_sdescripcion = mdrd.GetOrdinal("v_descripcion");
                            int pos_bestado = mdrd.GetOrdinal("b_estado");
                            int pos_dtfecreg = mdrd.GetOrdinal("dt_fecharegistro");
                            while (mdrd.Read())
                            {
                                senUsuario = new edMaestro();
                                senUsuario.idparametro = (mdrd.IsDBNull(pos_idparametro) ? 0 : mdrd.GetInt32(pos_idparametro));
                                senUsuario.idmaestro = (mdrd.IsDBNull(pos_idmaestro) ? 0 : mdrd.GetInt32(pos_idmaestro));
                                senUsuario.snombre = (mdrd.IsDBNull(pos_snombre) ? "-" : mdrd.GetString(pos_snombre));
                                senUsuario.sdescripcion = (mdrd.IsDBNull(pos_sdescripcion) ? "-" : mdrd.GetString(pos_sdescripcion));
                                senUsuario.iestado = (mdrd.IsDBNull(pos_bestado) ? 0 : mdrd.GetInt32(pos_bestado));
                                senUsuario.sfecharegistro = (mdrd.IsDBNull(pos_dtfecreg) ? "-" : mdrd.GetString(pos_dtfecreg));
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
