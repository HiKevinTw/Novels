using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Novels.Machine.ViewModels
{
    class DataGridViewAppearance
    {
        public int MaxRows { get; set; }

        public List<DataGridColumnAppearance> ColumnAppearances { get; set; }

        public static DataGridViewAppearance Parse(string serialized)
        {
            return string.IsNullOrEmpty(serialized) ? null : JsonConvert.DeserializeObject<DataGridViewAppearance>(serialized);
        }
    }
}
