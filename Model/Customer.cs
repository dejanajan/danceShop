namespace Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Customer")]
    public class Customer : IAggregateRoot
    {
        public int Id { get; set; }

 
        public string Name { get; set; }

  
        public string Surname { get; set; }


        public string Address { get; set; }


        public string Telephone { get; set; }

        public string Email { get; set; }
    }
}
