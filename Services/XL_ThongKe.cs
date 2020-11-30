using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using QuanLyCuaHang_WebApp.DAL;

namespace QuanLyCuaHang_WebApp
{   
    // Kiểu dữ liệu báo cáo thống kê cho từng Mặt hàng
    public struct BaoCaoMatHang
    {
        public int MaSo;
        public string TenMatHang;
        public DateTime HanDung;
        public int SoLuongNhap;
        public int SoLuongXuat;
        public int SoLuongConLai;
    }
    // Kiểu dữ liệu báo cáo thống kê cho từng Loại hàng
    public struct BaoCaoLoaiHang
    {
        public int MaSo;
        public string TenLoaiHang;
        public int SoLuongNhap;
        public int SoLuongXuat;
        public int SoLuongConLai;
    }

    public class XL_ThongKe
    {   
        // Xử lý thống kê tất cả mặt hàng
        public static List<BaoCaoMatHang> ThongKeMatHang()
        {
            List<BaoCaoMatHang> kq = new List<BaoCaoMatHang>();

            List<MatHang> ds_MatHang= LT_MatHang.DocDanhSach();
            List<DonHangNhap> ds_DonHangNhap = LT_DonHangNhap.DocDanhSach();
            List<DonHangXuat> ds_DonHangXuat = LT_DonHangXuat.DocDanhSach();

            foreach (var mh in ds_MatHang)
            {
                BaoCaoMatHang bc = new BaoCaoMatHang();

                bc.MaSo = mh.MaSo;
                bc.TenMatHang = mh.TenMatHang;

                //Tính số lượng nhập
                foreach (var dn in ds_DonHangNhap)
                {
                    if(dn.MatHang.MaSo == mh.MaSo)
                    {
                        bc.SoLuongNhap = bc.SoLuongNhap + dn.SoLuong;
                    }
                }
                //Tính số lượng xuất
                foreach (var dx in ds_DonHangXuat)
                {
                    if (dx.MatHang.MaSo == mh.MaSo)
                    {
                        bc.SoLuongXuat = bc.SoLuongXuat + dx.SoLuong;
                    }
                }
                //Tính số lượng còn
                bc.SoLuongConLai = bc.SoLuongNhap - bc.SoLuongXuat;

                kq.Add(bc);
            }

            return kq;
        }

        // Xử lý thống kê tất cả loại hàng
        public static List<BaoCaoLoaiHang> ThongKeLoaiHang()
        {
            List<BaoCaoLoaiHang> kq = new List<BaoCaoLoaiHang>();

            List<LoaiHang> ds_LoaiHang = LT_LoaiHang.DocDanhSach();
            List<DonHangNhap> ds_DonHangNhap = LT_DonHangNhap.DocDanhSach();
            List<DonHangXuat> ds_DonHangXuat = LT_DonHangXuat.DocDanhSach();

            foreach (var lh in ds_LoaiHang)
            {
                BaoCaoLoaiHang bc = new BaoCaoLoaiHang();

                bc.MaSo = lh.MaSo;
                bc.TenLoaiHang = lh.TenLoaiHang;

                //Tính số lượng nhập
                foreach (var dn in ds_DonHangNhap)
                {
                    if (dn.MatHang.LoaiHang == lh.TenLoaiHang)
                    {
                        bc.SoLuongNhap = bc.SoLuongNhap + dn.SoLuong;
                    }
                }
                //Tính số lượng xuất
                foreach (var dx in ds_DonHangXuat)
                {
                    if (dx.MatHang.LoaiHang == lh.TenLoaiHang )
                    {
                        bc.SoLuongXuat = bc.SoLuongXuat + dx.SoLuong;
                    }
                    //bc.SoLuongXuat = 10;
                }
                //Tính số lượng còn
                bc.SoLuongConLai = bc.SoLuongNhap - bc.SoLuongXuat;

                kq.Add(bc);
            }

            return kq;


        }


        // Xử lý thống kê tất cả mặt hàng
        public static List<BaoCaoMatHang> ThongKeMatHang_HetHanDung()
        {
            List<BaoCaoMatHang> kq = new List<BaoCaoMatHang>();

            List<MatHang> ds_MatHang = LT_MatHang.DocDanhSach();
            List<DonHangNhap> ds_DonHangNhap = LT_DonHangNhap.DocDanhSach();
            List<DonHangXuat> ds_DonHangXuat = LT_DonHangXuat.DocDanhSach();

            foreach (var mh in ds_MatHang)
            {
                //Kiểm tra hàng hết hạn
                if(mh.HanDung < DateTime.Now)
                {
                    BaoCaoMatHang bc = new BaoCaoMatHang();
                    bc.MaSo = mh.MaSo;
                    bc.TenMatHang = mh.TenMatHang;
                    bc.HanDung = mh.HanDung;
                    //Tính số lượng nhập
                    foreach (var dn in ds_DonHangNhap)
                    {
                        if (dn.MatHang.MaSo == mh.MaSo)
                        {
                            bc.SoLuongNhap = bc.SoLuongNhap + dn.SoLuong;
                        }
                    }
                    //Tính số lượng xuất
                    foreach (var dx in ds_DonHangXuat)
                    {
                        if (dx.MatHang.MaSo == mh.MaSo)
                        {
                            bc.SoLuongXuat = bc.SoLuongXuat + dx.SoLuong;
                        }
                    }
                    //Tính số lượng còn
                    bc.SoLuongConLai = bc.SoLuongNhap - bc.SoLuongXuat;
                    kq.Add(bc);
                }
            }
            return kq;
        }




    }

    

}