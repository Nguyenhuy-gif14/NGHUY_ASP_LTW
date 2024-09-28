using System.ComponentModel.DataAnnotations;

namespace Project.Models
{
    public class TheLoai
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage ="Khong duoc de trong ten tuoi!")]
        [Display(Name="Thể Loại")]
        public string Name { get; set; }
        [Required(ErrorMessage ="Không đúng định dạng ngày tháng năm!")]
        [Display(Name ="Ngày Tạo")]
        public DateTime DateCreated { get; set; } = DateTime.Now;

    }
}
