using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using Newtonsoft.Json;

namespace QuanLyCuaHang_WebApp.DAL
{
    public class LT_DonHangXuat
    {   
        //Data
        private static string filePath = HttpContext.Current.Server.MapPath("~/Data/DonHangXuat.json");

        //Doc du lieu
        public static List<DonHangXuat> DocDanhSach()
        {
            List<DonHangXuat> ds = new List<DonHangXuat>();
            StreamReader file = new StreamReader(filePath);
            string json = file.ReadToEnd();
            if (!string.IsNullOrEmpty(json))
                ds = JsonConvert.DeserializeObject<List<DonHangXuat>>(json);
            file.Close();
            return ds;
        }

        //Them vao danh sach
        public static void ThemVaoDanhSach(DonHangXuat dhx)
        {
            var ds = DocDanhSach();
            if (ds.Count == 0)
            {
                dhx.MaDonHang = 1;
            }
            else
            {
                dhx.MaDonHang = ds.Max(u => u.MaDonHang) + 1;
            }
            ds.Add(dhx);
            LuuTruDanhSach(ds);
        }

        //Luu danh sach
        public static void LuuTruDanhSach(List<DonHangXuat> ds)
        {
            StreamWriter file = new StreamWriter(filePath);
            string json = JsonConvert.SerializeObject(ds, Formatting.Indented);
            file.WriteLine(json);
            file.Close();
        }
    }
}