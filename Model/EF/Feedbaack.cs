namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Feedbaack")]
    public partial class Feedbaack
    {
        public long ID { get; set; }

        [StringLength(10)]
        public string Name { get; set; }

        [StringLength(10)]
        public string Phone { get; set; }

        [StringLength(10)]
        public string Email { get; set; }

        [StringLength(10)]
        public string Address { get; set; }

        [Column(TypeName = "ntext")]
        public string Content { get; set; }

        [StringLength(10)]
        public string CreateDate { get; set; }

        public bool? Status { get; set; }
    }
}
