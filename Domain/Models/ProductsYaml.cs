using System.Collections.Generic;

namespace Domain.Models
{
	public class ProductsYaml: object
	{
		public string Tags { get; set; }
        public string Name { get; set; }
		public string Twitter { get; set; }

        public override string ToString()
        {
            return $"Name: {Name}; Twitter: {Twitter}; Tags: [{Tags}];";
        }
    }
}

