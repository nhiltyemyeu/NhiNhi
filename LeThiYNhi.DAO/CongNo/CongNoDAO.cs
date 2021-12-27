using LeThiYNhi.DTO.CongNo;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeThiYNhi.DAO.CongNo
{
    public class CongNoDAO : DBConnection
    {
        public CommandType CommandType { get; private set; }

        public List<CongNoDTO> ReadCN()
        {
            SqlConnection conn = CreateConnection();
            conn.Open();
            SqlCommand cmd = new SqlCommand("CREATE PROC Select_CongNo as select * from CONGNO", conn);

            cmd.CommandText = "Select_CongNo";
            cmd.CommandType = CommandType.StoredProcedure;

            SqlDataReader reader = cmd.ExecuteReader();

            List<CongNoDTO> lstCn = new List<CongNoDTO>();
            while (reader.Read())
            {
                CongNoDTO cno = new CongNoDTO();
                cno.IdCustomer = reader["makhachhang"].ToString();
                cno.NameCustomer = reader["tenkhachhang"].ToString();
                cno.NumberPhone = reader["sodienthoai"].ToString();
                cno.AmountOwed = decimal.Parse(reader["sotienno"].ToString());
                lstCn.Add(cno);
            }
            conn.Close();
            return lstCn;
        }

        public void NewCustomer(CongNoDTO cno)
        {
            SqlConnection conn = CreateConnection();
            conn.Open();
            SqlCommand cmd = new SqlCommand();

            //Chỗ này tạm thời có thể gán cứng chuỗi kết nối
            try
            {

                //sử dụng thuộc tính CommandText để chỉ định tên Proc
                cmd.CommandText = "InsertCustomer";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = conn;

                //khai báo các thông tin của tham số truyền vào
                cmd.Parameters.Add("@makhachhang", SqlDbType.NVarChar).Value = cno.IdCustomer;
                cmd.Parameters.Add("@tenkhachhang", SqlDbType.NVarChar).Value = cno.NameCustomer;
                cmd.Parameters.Add("@sodienthoai", SqlDbType.NVarChar).Value = cno.NumberPhone;
                cmd.Parameters.Add("@sotienno", SqlDbType.Decimal).Value = cno.AmountOwed;
                //mở chuỗi kết nối
                conn.Open();
                //sử dụng ExecuteNonQuery để thực thi
                cmd.ExecuteNonQuery();
                //đóng chuỗi kết nối.
                conn.Close();

                Console.WriteLine("Them khach hang thanh cong !!!");
            }
            catch (Exception e)
            {
                Console.WriteLine("Co loi xay ra !!!" + e);
            }
            // dóng chuỗi kết nối
            finally
            {
                conn.Close();
            }

        }

        public void EditCustomer(CongNoDTO cno)
        {
            SqlConnection conn = CreateConnection();
            conn.Open();
            SqlCommand cmd = new SqlCommand();

            //Chỗ này tạm thời có thể gán cứng chuỗi kết nối
            try
            {

                //sử dụng thuộc tính CommandText để chỉ định tên Proc
                cmd.CommandText = "UpdateCustomer";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = conn;

                //khai báo các thông tin của tham số truyền vào
                cmd.Parameters.Add("@makhachhang", SqlDbType.NVarChar).Value = cno.IdCustomer;
                cmd.Parameters.Add("@tenkhachhang", SqlDbType.NVarChar).Value = cno.NameCustomer;
                cmd.Parameters.Add("@sodienthoai", SqlDbType.NVarChar).Value = cno.NumberPhone;
                cmd.Parameters.Add("@sotienno", SqlDbType.Decimal).Value = cno.AmountOwed;
                //mở chuỗi kết nối
                conn.Open();
                //sử dụng ExecuteNonQuery để thực thi
                cmd.ExecuteNonQuery();
                //đóng chuỗi kết nối.
                conn.Close();

                Console.WriteLine("Sua khach hang thanh cong !!!");
            }
            catch (Exception e)
            {
                Console.WriteLine("Co loi xay ra !!!" + e);
            }
            // dóng chuỗi kết nối
            finally
            {
                conn.Close();
            }
        }

        public void DeleteCustomer(CongNoDTO cno)
        {
            SqlConnection conn = CreateConnection();
            conn.Open();
            SqlCommand cmd = new SqlCommand();

            //Chỗ này tạm thời có thể gán cứng chuỗi kết nối
            try
            {

                //sử dụng thuộc tính CommandText để chỉ định tên Proc
                cmd.CommandText = "DeleteCustomer";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = conn;

                //khai báo các thông tin của tham số truyền vào
                cmd.Parameters.Add("@makhachhang", SqlDbType.NVarChar).Value = cno.IdCustomer;
                //mở chuỗi kết nối
                conn.Open();
                //sử dụng ExecuteNonQuery để thực thi
                cmd.ExecuteNonQuery();
                //đóng chuỗi kết nối.
                conn.Close();



            }
            catch (Exception e)
            {
                Console.WriteLine("Co loi xay ra !!!" + e);
            }
            // dóng chuỗi kết nối
            finally
            {
                conn.Close();
            }
        }
    }
}
