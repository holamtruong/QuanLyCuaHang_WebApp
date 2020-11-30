using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using QuanLyCuaHang_WebApp.DAL;

namespace QuanLyCuaHang_WebApp
{
    //Kieu du lieu
    public struct DonHangNhap
    {
        public int MaDonHang;
        public MatHang MatHang;
        public int SoLuong;
        public DateTime NgayNhap;
    }


    // Xu ly nghiêp vu
    public class XL_DonHangNhap
    {
        // Tim kiem danh sach
        public static List<DonHangNhap> TimKiemDanhSach(string tukhoa)
        {
            List<DonHangNhap> ds_full = new List<DonHangNhap>();
            List<DonHangNhap> ds_filter = new List<DonHangNhap>();

            ds_full = LT_DonHangNhap.DocDanhSach();

            if (String.IsNullOrEmpty(tukhoa)) {
                return ds_full;
            }
            else
            {
                foreach(var x in ds_full)
                {
                    if(x.MatHang.TenMatHang.Contains(tukhoa))
                    {
                        ds_filter.Add(x);
                    }
                }
                return ds_filter;
            }
        }


        // Tim kiem doi tuong
        // Tim doi tuong
        public static DonHangNhap TimKiemDoiTuong(int ms)
        {
            DonHangNhap dhn = new DonHangNhap();
            var ds = LT_DonHangNhap.DocDanhSach();

            foreach (var x in ds)
            {
                if (x.MaDonHang == ms)
                {
                    dhn = x;
                    break;
                }
            }
            return dhn;
        }



        // Them
        public static void Them(DonHangNhap dhn)
        {
            LT_DonHangNhap.ThemVaoDanhSach(dhn);
          
        }

        // Sua
        public static void SuaDanhSach(DonHangNhap dhn)
        {
            var ds = LT_DonHangNhap.DocDanhSach();
            for (int i = 0; i < ds.Count; i++)
            {
                if (ds[i].MaDonHang == dhn.MaDonHang)
                {
                    ds[i] = dhn;
                    break;
                }
            }
            LT_DonHangNhap.LuuTruDanhSach(ds);
        }

        // Xoa
        public static void Xoa(int ms)
        {
            var ds = LT_DonHangNhap.DocDanhSach();
            foreach (var x in ds)
            {
                if (x.MaDonHang == ms)
                {
                    ds.Remove(x);
                    break;
                }
            }
            LT_DonHangNhap.LuuTruDanhSach(ds);
        }







    }





}