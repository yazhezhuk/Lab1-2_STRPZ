using System.Collections;
using System.Collections.Generic;
using Types;

namespace Entities
{
    public class EmployeeEntity : IEntity
    {
        public int Id { get; set; }

        public string Firstname { get; set; }
        public string Lastname { get; set; }

        public Speciality Speciality { get; set; }
        public int Age { get; set; }
        
        public virtual ICollection<OrderEntity> Orders { get; set; }
    }
}