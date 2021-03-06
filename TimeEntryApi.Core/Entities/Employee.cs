using System;
using Microsoft.AspNetCore.Identity;

public class Employee : IdentityUser, IEntity
{
    public virtual int DepartmentId { get; set; }
    public virtual Department Department { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime CreatedDate { get; set; }
    public string CreatedBy { get; set; }
    public DateTime UpdatedDate { get; set; }
    public string UpdatedBy { get; set; }
    public bool IsDeleted { get; set; }
    public bool IsVisible { get; set; }
}