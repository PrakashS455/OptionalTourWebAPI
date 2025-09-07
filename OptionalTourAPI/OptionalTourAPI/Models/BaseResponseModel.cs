using System;

namespace PAMAPI.Api.Models
{
    public class BaseResponseModel
    {
        public long Id { get; set; }
        public bool Active { get; set; }
        public long CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public long ModifiedBy { get; set; }
        public DateTime ModifiedDate { get; set; }
        public string CreatedName { get; set; }
        public string ModifiedName { get; set; }
        public long FilterTotalCount { get; set; }
    }
}