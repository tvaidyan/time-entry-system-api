using System;

public class TimeEntry
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
}
