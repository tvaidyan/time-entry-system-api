using System;

public class TimeEntry : IEntity
{
    int TimeEntryId { get; set; }
    int ProjectId { get; set; }
    DateTime EntryDateTime { get; set; }
    string DetailsForInvoice { get; set; }
    bool IsBillable {get;set;}
    string InternalNotes {get;set;}
    DateTime ReviewedDate {get;set;}
    public string ReviewedBy { get; set; }
    public DateTime InvoicedDate { get; set; }
    public string InvoicedBy { get; set; }
    public string InvoiceId { get; set; }
    public DateTime CreatedDate  { get; set; }
    public DateTime UpdatedDate  { get; set; }
    public string CreatedBy  { get; set; }
    public string UpdatedBy  { get; set; }
    public bool IsDeleted  { get; set; }
    public bool IsVisible  { get; set; }
}
