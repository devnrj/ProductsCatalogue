using System.Collections.Generic;

namespace Domain.Models
{
	public class ProductsJson : object
	{
        public List<string> Categories { get; set; }
        public string Title { get; set; }
        public string Twitter { get; set; }

        public override string ToString()
        {
            string categories = string.Join(",", Categories);
            return $"Title: {Title}; Twitter: {Twitter}; Categories: [{categories}];";
        }
    }
}

