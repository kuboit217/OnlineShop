namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Slide")]
    public partial class Slide
    {
        public long ID { get; set; }

        [StringLength(10)]
        public string Image { get; set; }

        [StringLength(10)]
        public string DisplayOrrder { get; set; }

        [StringLength(10)]
        public string Link { get; set; }

        public bool Status { get; set; }

        [StringLength(10)]
        public string Description { get; set; }

        public DateTime? CreateDate { get; set; }

        [StringLength(250)]
        public string CreateBy { get; set; }

        public DateTime? ModifiedDate { get; set; }

        [StringLength(50)]
        public string ModifiedBy { get; set; }
    }
}
