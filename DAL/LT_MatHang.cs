using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using Newtonsoft.Json;


namespace QuanLyCuaHang_WebApp.DAL
{   
    //Xu ly luu tru du lieu
    public class LT_MatHang
    {
        //Data
        private static string filePath = HttpContext.Current.Server.MapPath("~/Data/MatHang.json");

        //Doc du lieu
        public static List<MatHang> DocDanhSach()
        {
            List<MatHang> ds = new List<MatHang>();
            StreamReader file = new StreamReader(filePath);
            string json = file.ReadToEnd();
            if (!string.IsNullOrEmpty(json))
                ds = JsonConvert.DeserializeObject<List<MatHang>>(json);
            file.Close();
            return ds;
        }

        //Them vao danh sach
        public static void ThemVaoDanhSach(MatHang mh)
        {
            var ds = DocDanhSach();
            if (ds.Count == 0)
            {
                mh.MaSo = 1;
            }
            else
            {
                mh.MaSo = ds.Max(u => u.MaSo) + 1;
            }
            ds.Add(mh);
            LuuTruDanhSach(ds);
        }
        //Luu danh sach
        public static void LuuTruDanhSach(List<MatHang> ds)
        {
            StreamWriter file = new StreamWriter(filePath);
            string json = JsonConvert.SerializeObject(ds, Formatting.Indented);
            file.WriteLine(json);
            file.Close();
        }
    }
}