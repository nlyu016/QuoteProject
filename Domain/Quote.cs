namespace Domain
{
    using System;
    using System.Collections.Generic;

    public partial class Quote
    {
        public int QuoteId { get; set; }
        public string QuoteType { get; set; }
        public string Contact { get; set; }
        public string Task { get; set; }
        public Nullable<System.DateTime> DueDate { get; set; }
        public string TaskType { get; set; }
    }
}
