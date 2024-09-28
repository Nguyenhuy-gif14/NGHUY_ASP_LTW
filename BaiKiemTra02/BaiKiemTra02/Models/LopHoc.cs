using System.ComponentModel.DataAnnotations;

namespace BaiKiemTra02.Models
{
    public class LopHoc
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Tên lớp học là bắt buộc")]
        [Display(Name = "Tên Lớp Học")]
        public string TenLopHoc { get; set; }

        [Required(ErrorMessage = "Năm nhập học là bắt buộc")]
        [Display(Name = "Năm Nhập Học")]
        public int NamNhapHoc { get; set; }

        [Required(ErrorMessage = "Năm ra trường là bắt buộc")]
        [Display(Name = "Năm Ra Trường")]
        public int NamRaTruong { get; set; }

        [Required(ErrorMessage = "Số lượng sinh viên là bắt buộc")]
        [Display(Name = "Số Lượng Sinh Viên")]
        public int SoLuongSinhVien { get; set; }
    }
}
