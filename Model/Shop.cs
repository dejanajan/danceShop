namespace Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Shop")]
    public class Shop : IAggregateRoot
    {
        public int Id { get; set; }


        public string Location { get; set; }

        public int? CustomerID { get; set; }

        public string CustomerName { get; set; }

        public string EquipmentName { get; set; }

        public int EquipmentID { get; set; }

        public string EquipmentType { get; set; }

        public int? Price { get; set; }
    }
}
