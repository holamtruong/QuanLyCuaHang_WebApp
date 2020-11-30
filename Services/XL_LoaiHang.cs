using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using QuanLyCuaHang_WebApp.DAL;

namespace QuanLyCuaHang_WebApp
{
    //Kieu du lieu
    public struct LoaiHang
    {
        public int MaSo;
        public string TenLoaiHang;
    }
       

    
    //Xu ly nghiep vu
    public class XL_LoaiHang
    {

        // Tim kiem theo ten
        public static List<LoaiHang> TimKiemDanhSach(string TuKhoa)
        {
            List<LoaiHang> ds_full = LT_LoaiHang.DocDanhSach();
            List<LoaiHang> ds_filter = new List<LoaiHang>();

            if (String.IsNullOrEmpty(TuKhoa))
            {
                return ds_full;
            }
            else
            {
                foreach (var x in ds_full)
                {
                    if (x.TenLoaiHang.Contains(TuKhoa))
                    {
                        ds_filter.Add(x);
                    }
                }
            }
            return ds_filter;
        }

        // Tim doi tuong
        public static LoaiHang TimKiemDoiTuong(int ms)
        {
            LoaiHang lh = new LoaiHang();
            var ds = LT_LoaiHang.DocDanhSach();

            foreach (var x in ds)
            {
                if (x.MaSo == ms)
                {
                    lh = x;
                    break;
                }
            }
            return lh;
        }

        // Them moi
        public static void Them(LoaiHang lh)
        {
            LT_LoaiHang.ThemVaoDanhSach(lh);
        }

        // Sua
        public static void SuaDanhSach(LoaiHang lh)
        {
            var ds = LT_LoaiHang.DocDanhSach();
            for (int i = 0; i < ds.Count; i++)
            {
                if (ds[i].MaSo == lh.MaSo)
                {
                    ds[i] = lh;
                    break;
                }
            }
            LT_LoaiHang.LuuTruDanhSach(ds);
        }

        // Xoa
        public static void Xoa(int ms)
        {
            var ds = LT_LoaiHang.DocDanhSach();
            foreach (var x in ds)
            {
                if (x.MaSo == ms)
                {
                    ds.Remove(x);
                    break;
                }
            }
            LT_LoaiHang.LuuTruDanhSach(ds);
        }
    }


}