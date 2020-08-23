using System;
using System.Collections.Generic;
using System.Text;

namespace Mantle.DataModels.Models
{
    public class BaseDataModel
    {
        public int Id { get; set; }
        public DateTimeOffset ModifiedOn { get; set; }
        public string ModifiedBy { get; set; }
    }
}
