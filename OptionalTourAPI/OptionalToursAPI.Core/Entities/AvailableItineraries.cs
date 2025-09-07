using System;
using System.Collections.Generic;
using System.Text;

namespace OptionalToursAPI.Core.Entities
{
    public class AvailableItineraries
    {
        public int ITIN_ID { get; set; }
        public string PROGRAM { get; set; }
        public string BASE_PROGRAM { get; set; }
        public DateTime BASE_DEP_DATE { get; set; }
        public string PRE_PROGRAM { get; set; }
        public DateTime PRE_DEP_DATE { get; set; }
        public string SHIP_CODE { get; set; }
        public string SHIP_NAME { get; set; }
    }
}
