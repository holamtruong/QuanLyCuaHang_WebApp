using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using QuanLyCuaHang_WebApp.DAL;

namespace QuanLyCuaHang_WebApp
{
    //Kieu du lieu
    public struct DonHangXuat
    {
        public int MaDonHang;
        public MatHang MatHang;
        public int SoLuong;
        public DateTime NgayBan;
    }


    // Xu ly nghiêp vu
    public class XL_DonHangXuat
    {
        // Tim kiem danh sach
        public static List<DonHangXuat> TimKiemDanhSach(string tukhoa)
        {
            List<DonHangXuat> ds_full = new List<DonHangXuat>();
            List<DonHangXuat> ds_filter = new List<DonHangXuat>();

            ds_full = LT_DonHangXuat.DocDanhSach();

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
        public static DonHangXuat TimKiemDoiTuong(int ms)
        {
            DonHangXuat dhx = new DonHangXuat();
            var ds = LT_DonHangXuat.DocDanhSach();

            foreach (var x in ds)
            {
                if (x.MaDonHang == ms)
                {
                    dhx = x;
                    break;
                }
            }
            return dhx;
        }



        // Them
        public static void Them(DonHangXuat dhx)
        {
            LT_DonHangXuat.ThemVaoDanhSach(dhx);
          
        }

        // Sua
        public static void SuaDanhSach(DonHangXuat dhx)
        {
            var ds = LT_DonHangXuat.DocDanhSach();
            for (int i = 0; i < ds.Count; i++)
            {
                if (ds[i].MaDonHang == dhx.MaDonHang)
                {
                    ds[i] = dhx;
                    break;
                }
            }
            LT_DonHangXuat.LuuTruDanhSach(ds);
        }

        // Xoa
        public static void Xoa(int ms)
        {
            var ds = LT_DonHangXuat.DocDanhSach();
            foreach (var x in ds)
            {
                if (x.MaDonHang == ms)
                {
                    ds.Remove(x);
                    break;
                }
            }
            LT_DonHangXuat.LuuTruDanhSach(ds);
        }







    }





}