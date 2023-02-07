using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;


namespace de1.Models
{
    public class DbContext
    {
        public string ConnectionString { get; set; }//biết thành viên 

        public DbContext(string connectionString = "server=localhost;user id=root;password=;port=3306;database=de2;") //phuong thuc khoi tao
        {
            this.ConnectionString = connectionString;
        }
        private MySqlConnection GetConnection() //lấy connection 
        {
            return new MySqlConnection(ConnectionString);
        }

        public List<CongViec> ChiTiet(string MaBD){
            List<CongViec> list = new List<CongViec>();

            string sql = "select c.MaCV,c.TenCV,c.DonGia from CongViec c join CT_BD ct on c.MaCV = ct.MaCV where ct.MaBD = @MaBD";
            using(MySqlConnection conn = GetConnection()){
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@MaBD", MaBD);
                conn.Open();
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    CongViec cv = new CongViec(reader["MaCV"].ToString(), reader["TenCV"].ToString(), reader["DonGia"].ToString());
                    list.Add(cv);
                }
                conn.Close();
            }           

            return list;
        }

        public int CapNhat(BaoDuong bd){
            int sum = 0;

            string sql = "Update BaoDuong set NgayGioNhan = @NgayGioNhan , NgayGioTra=@NgayGioTra , SoKM=@SoKM , NoiDung=@NoiDung where MaBD = @MaBD";
            using(MySqlConnection conn = GetConnection()){
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@MaBD", bd.MABD);
                cmd.Parameters.AddWithValue("@NgayGioNhan", bd.NGAYNGIONHAN.ToString("yyyy-MM-dd"));
                cmd.Parameters.AddWithValue("@NgayGioTra", bd.NGAYGIOTRA.ToString("yyyy-MM-dd"));
                cmd.Parameters.AddWithValue("@NoiDung", bd.NOIDUNG);
                cmd.Parameters.AddWithValue("@SoKM", bd.SOKM);
                cmd.ExecuteNonQuery();
                sum=1;
                conn.Close();
            }

            return sum;
        }

        public int XoaCV(string MaCV,string MaBD){
            int count = 0;
            string sql = "delete from CT_BD where MaCV = @MaCV and MaBD = @MaBD";
            using(MySqlConnection conn = GetConnection()){
               try{
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand(sql,conn);
                    cmd.Parameters.AddWithValue("@MaCV", MaCV);
                    cmd.Parameters.AddWithValue("@MaBD", MaBD);
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    count=1;
               }catch(Exception ex){

               }
            }
            return count;
        }

        public List<BaoDuong> LietKe(string SoXe){
            List<BaoDuong> list = new List<BaoDuong>();

            using(MySqlConnection conn = GetConnection())
            {
                conn.Open();
                string sql = "SELECT * FROM BaoDuong WHERE SoXe = @SoXe";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@SoXe", SoXe);
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    BaoDuong bd = new BaoDuong();
                    bd.MABD = reader["MaBD"].ToString();
                    bd.NGAYGIOTRA=DateTime.Parse(reader["NgayGioTra"].ToString());
                    bd.NGAYGIOTRA=DateTime.Parse(reader["NgayGioNhan"].ToString());;
                    bd.NOIDUNG = reader["NoiDung"].ToString();
                    bd.SOKM = reader["SoKM"].ToString();
                    bd.SOXE = reader["SoXe"].ToString();
                    list.Add(bd);
                }
                conn.Close();
            }

            return list;
        }

        public BaoDuong GetBaoDuong(string MaBD){
            BaoDuong bd = new BaoDuong();

            using(MySqlConnection conn = GetConnection()){
                conn.Open();
                string sql = "SELECT * FROM BaoDuong WHERE MaBD = @MaBD";

                MySqlCommand cmd = new MySqlCommand(sql, conn);

                cmd.Parameters.AddWithValue("@MaBD",MaBD);

                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read()){
                    bd.MABD = reader["MaBD"].ToString();
                    bd.NGAYGIOTRA=DateTime.Parse(reader["NgayGioTra"].ToString());
                    bd.NGAYNGIONHAN=DateTime.Parse(reader["NgayGioNhan"].ToString());;
                    bd.NOIDUNG = reader["NoiDung"].ToString();
                    bd.SOKM = reader["SoKM"].ToString();
                    bd.SOXE = reader["SoXe"].ToString();
                }
            }
            return bd;
        }

        public int ThemCongViec(string MaCV, string TenCV, string DonGia){
            int count = 0;
            using (MySqlConnection conn = GetConnection()){
                try{
                    conn.Open();
                    string str = "INSERT INTO CongViec (MaCV,TenCV,DonGia) VALUES (@manv,@tennv,@dongia)";

                    MySqlCommand cmd = new MySqlCommand(str, conn);

                    cmd.Parameters.AddWithValue("@manv", MaCV);
                    cmd.Parameters.AddWithValue("@tennv", TenCV);
                    cmd.Parameters.AddWithValue("@dongia", DonGia);

                    cmd.ExecuteNonQuery();
                    count = 1;
                    conn.Close();
                }catch(Exception ex){

                }

            }
            return count;
        }
    }
}