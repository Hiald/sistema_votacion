using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaVotacionTD
{
    public class td_aglobal
    {
        public String mysqlConexion { get; set; }

        public td_aglobal()
        {
            mysqlConexion = ConfigurationManager.ConnectionStrings["cnMysql"].ConnectionString;
        }
    }
}
