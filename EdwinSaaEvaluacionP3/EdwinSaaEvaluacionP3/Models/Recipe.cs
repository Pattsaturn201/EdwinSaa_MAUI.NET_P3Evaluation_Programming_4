using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace EdwinSaaEvaluacionP3.Models
{
    public class  Recipe 
    {
        [PrimaryKey]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Ingredients { get; set; }
        public int PreparationTimeMinutes { get; set; }

        public bool IsVegetarian { get; set; }

    }

}
