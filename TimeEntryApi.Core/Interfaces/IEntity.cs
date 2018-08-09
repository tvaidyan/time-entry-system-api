using System;
public interface IEntity
{
    DateTime CreatedDate { get; set; }
    DateTime UpdatedDate { get; set; }
    string CreatedBy { get; set; }
    string UpdatedBy { get; set; }
    bool IsDeleted { get; set; }
    bool IsVisible { get; set; }
}