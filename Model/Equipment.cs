namespace Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Equipment")]
    public class Equipment : IAggregateRoot
    {
        public int Id { get; set; }


        public string EquipmentType { get; set; }


        public string Producer { get; set; }


        public string Country { get; set; }

        public string Telephone { get; set; }

 
        public string Email { get; set; }

        public int? Price { get; set; }
    }
}
