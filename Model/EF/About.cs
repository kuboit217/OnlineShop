namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("About")]
    public partial class About
    {
        public long ID { get; set; }

        [StringLength(250)]
        [DisplayName("Tiêu đề")]
        [Required]
        public string Name { get; set; }

        [Required]
        [StringLength(250)]
        public string MetaTitle { get; set; }

        [StringLength(500)]
        [DisplayName("Mô tả")]
        [Required]
        public string Descriptions { get; set; }

        [StringLength(250)]
        [DisplayName("Hình ảnh")]
        [Required]
        public string Image { get; set; }

        [Column(TypeName = "ntext")]
        [DisplayName("Nội dung")]
        [Required]
        public string Detail { get; set; }

        public DateTime? CreateDate { get; set; }

        [StringLength(250)]
        public string CreateBy { get; set; }

        public DateTime? ModifiedDate { get; set; }

        [StringLength(50)]
        public string ModifiedBy { get; set; }

        [StringLength(250)]
        [DisplayName("Từ khóa")]
        public string MetaKeywords { get; set; }

        [StringLength(250)]
        [DisplayName("Mô tả ngắn")]
        public string MetaDescriptions { get; set; }
        [DisplayName("Trạng thái")]
        [Required]
        public bool Status { get; set; }
    }
}
