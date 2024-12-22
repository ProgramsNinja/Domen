using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domen
{
    public class Company
    {
        private Company(Guid id, string name, string description)
        {
            Id = id;
            Name = name;
            Description = description;
        }

        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }

        public Company Create(string name, string description)
        {
            if (name == null) 
                throw new ArgumentNullException(nameof(name));
            if (description == null) 
                throw new ArgumentNullException(nameof(description));

            var company = new Company(new Guid(), name, description);

            return company;
        }
    }
}
