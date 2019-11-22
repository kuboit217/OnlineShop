namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("User")]
    public partial class User
    {
        public long ID { get; set; }

        [StringLength(50)]
        [DisplayName("Tài khoản")][Required]
        public string UserName { get; set; }

        [StringLength(50)]
        [DisplayName("Mật khẩu")][Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Compare("Password", ErrorMessage = "Password Mismatched. Re-enter your password")]
        [DataType(DataType.Password)]
        [Display(Name = "Confirm Password")]
        [NotMapped]
        public string ConfirmPassword { get; set; }

        [StringLength(50)]
        [DisplayName("Họ tên")][Required]
        public string Name { get; set; }

        [StringLength(50)]
        [DisplayName("Địa chỉ")][Required]
        public string Address { get; set; }

        [StringLength(50)][Required]
        public string Email { get; set; }

        [StringLength(50)][Required]
        [DisplayName("Điện thoại")]
        public string Phone { get; set; }

        public DateTime? CreateDate { get; set; }

        [StringLength(250)]
        public string CreateBy { get; set; }

        public DateTime? ModifiedDate { get; set; }

        [StringLength(50)]
        public string ModifiedBy { get; set; }
        [DisplayName("Trạng thái")]
        public bool Status { get; set; }
    }
}
