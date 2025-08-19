using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace WindowsFormsApp1
{
    internal class sqlbaglantısı
    {
        public SqlConnection baglanti()
        {
            SqlConnection baglan = new SqlConnection("Data Source=DESKTOP-R3IS72Q;Initial Catalog=F1_Yarisma;Integrated Security=True;Encrypt=False");
            baglan.Open();
            return baglan;
        }
        
    }
}
