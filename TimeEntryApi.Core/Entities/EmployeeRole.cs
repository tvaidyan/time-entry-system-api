using System;
using Microsoft.AspNetCore.Identity;

public class EmployeeRole : IdentityRole
{
    public DateTime CreatedDate { get; set; }
    public DateTime UpdatedDate { get; set; }
    public string CreatedBy { get; set; }
    public string UpdatedBy { get; set; }
    public bool Enabled { get; set; }
}