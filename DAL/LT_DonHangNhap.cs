using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using Newtonsoft.Json;

namespace QuanLyCuaHang_WebApp.DAL
{
    public class LT_DonHangNhap
    {   
        //Data
        private static string filePath = HttpContext.Current.Server.MapPath("~/Data/DonHangNhap.json");

        //Doc du lieu
        public static List<DonHangNhap> DocDanhSach()
        {
            List<DonHangNhap> ds = new List<DonHangNhap>();
            StreamReader file = new StreamReader(filePath);
            string json = file.ReadToEnd();
            if (!string.IsNullOrEmpty(json))
                ds = JsonConvert.DeserializeObject<List<DonHangNhap>>(json);
            file.Close();
            return ds;
        }

        //Them vao danh sach
        public static void ThemVaoDanhSach(DonHangNhap dhn)
        {
            var ds = DocDanhSach();
            if (ds.Count == 0)
            {
                dhn.MaDonHang = 1;
            }
            else
            {
                dhn.MaDonHang = ds.Max(u => u.MaDonHang) + 1;
            }
            ds.Add(dhn);
            LuuTruDanhSach(ds);
        }

        //Luu danh sach
        public static void LuuTruDanhSach(List<DonHangNhap> ds)
        {
            StreamWriter file = new StreamWriter(filePath);
            string json = JsonConvert.SerializeObject(ds, Formatting.Indented);
            file.WriteLine(json);
            file.Close();
        }
    }
}