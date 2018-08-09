using System;

namespace TimeEntryApi.Core
{
    public class Company : IEntity
    {
        public int CompanyId { get; set; }
        public string Name { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime UpdatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsVisible { get; set; }
    }
}
