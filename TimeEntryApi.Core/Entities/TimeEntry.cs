using System;

public class TimeEntry : IEntity
{
    public int TimeEntryId { get; set; }
    public int ProjectId { get; set; }
    public DateTime EntryDateTime { get; set; }
    public string DetailsForInvoice { get; set; }
    public bool IsBillable {get;set;}
    public string InternalNotes {get;set;}
    public DateTime ReviewedDate {get;set;}
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
