//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace second_api_project.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class ArchiveBooks_TBL
    {
        public int ArchiveBookID { get; set; }
        public string BookCode { get; set; }
        public string BookNumber { get; set; }
        public string BookDate { get; set; }
        public string InboundNumber { get; set; }
        public string InboundDate { get; set; }
        public string Subject { get; set; }
        public Nullable<int> BooksTypeID { get; set; }
        public string From { get; set; }
        public string To { get; set; }
        public string SearchKeys { get; set; }
        public string BookPriority { get; set; }
        public Nullable<System.DateTime> ArchivedDate { get; set; }
        public string BookPaperType { get; set; }
        public string Notes { get; set; }
        public Nullable<int> DepartmentID_archivedBy { get; set; }
        public Nullable<int> UserID_archivedBy { get; set; }
        public string BookStatus { get; set; }
        public string Privacy { get; set; }
    }
}