using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using QuanLyCuaHang_WebApp.DAL;

namespace QuanLyCuaHang_WebApp
{
    // Kieu du lieu MatHang
    public struct MatHang
    {
        public int MaSo;
        public string TenMatHang;
        public DateTime HanDung;
        public string CongTySanXuat;
        public int NamSanXuat;
        public string LoaiHang;
    }

    // Xu ly nghiep vu
    public class XL_MatHang
    {   

        // Tim kiem theo ten
        public static List<MatHang> TimKiemDanhSach(string TuKhoa)
        {
            List<MatHang> ds_full = LT_MatHang.DocDanhSach();
            List<MatHang> ds_filter = new List<MatHang>();

            if (String.IsNullOrEmpty(TuKhoa))
            {
                return ds_full;
            }
            else
            {
                foreach(var x in ds_full)
                {
                    if(x.TenMatHang.Contains(TuKhoa))
                    {
                        ds_filter.Add(x);
                    }
                }
            }
            return ds_filter;
        }

        // Tim doi tuong
        public static MatHang TimKiemDoiTuong(int ms)
        {
            MatHang mh = new MatHang();
            var ds = LT_MatHang.DocDanhSach();

            foreach (var x in ds) {
                if(x.MaSo == ms)
                {
                    mh = x;
                    break;
                }
            }
            return mh;
        }

        // Them moi
        public static void Them(MatHang mh)
        {
            LT_MatHang.ThemVaoDanhSach(mh);
        }

        // Sua
        public static void SuaDanhSach(MatHang mh)
        {
            var ds = LT_MatHang.DocDanhSach();
            for (int i = 0; i < ds.Count; i++)
            {
                if(ds[i].MaSo == mh.MaSo)
                {
                    ds[i] = mh;
                    break;
                }
            }
            LT_MatHang.LuuTruDanhSach(ds);
        }

        // Xoa
        public static void Xoa(int ms)
        {
            var ds = LT_MatHang.DocDanhSach();
            foreach (var x in ds) 
            {
                if(x.MaSo == ms)
                {
                    ds.Remove(x);
                    break;
                }
            }
            LT_MatHang.LuuTruDanhSach(ds);
        }





        
    }
}