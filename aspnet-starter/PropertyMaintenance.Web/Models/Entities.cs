namespace PropertyMaintenance.Web.Models;

public class CustomerProfile
{
    public int Id { get; set; }
    public string UserId { get; set; } = string.Empty;
    public ApplicationUser? User { get; set; }
    public string FullName { get; set; } = string.Empty;
    public string Phone { get; set; } = string.Empty;
    public string Address { get; set; } = string.Empty;
    public string Notes { get; set; } = string.Empty;
    public ICollection<JobRequest> JobRequests { get; set; } = new List<JobRequest>();
}

public class Service
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public decimal DefaultRate { get; set; }
}

public enum JobRequestStatus { New, Quoted, Booked, Cancelled, Completed }
public enum QuoteStatus { Draft, Sent, Accepted, Declined }
public enum JobStatus { New, Quoted, Scheduled, InProgress, Completed, Invoiced }

public class JobRequest
{
    public int Id { get; set; }
    public int CustomerProfileId { get; set; }
    public CustomerProfile? Customer { get; set; }
    public int ServiceId { get; set; }
    public Service? Service { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public DateTime PreferredFrom { get; set; }
    public DateTime PreferredTo { get; set; }
    public JobRequestStatus Status { get; set; } = JobRequestStatus.New;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public ICollection<Attachment> Attachments { get; set; } = new List<Attachment>();
}

public class Quote
{
    public int Id { get; set; }
    public int JobRequestId { get; set; }
    public JobRequest? JobRequest { get; set; }
    public decimal TotalAmount { get; set; }
    public QuoteStatus Status { get; set; } = QuoteStatus.Draft;
    public string CreatedBy { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}

public class Booking
{
    public int Id { get; set; }
    public int QuoteId { get; set; }
    public Quote? Quote { get; set; }
    public DateTime ScheduledStart { get; set; }
    public DateTime ScheduledEnd { get; set; }
    public string AssignedTechnicianId { get; set; } = string.Empty;
    public string Location { get; set; } = string.Empty;
}

public class Job
{
    public int Id { get; set; }
    public int BookingId { get; set; }
    public Booking? Booking { get; set; }
    public JobStatus Status { get; set; } = JobStatus.New;
    public DateTime? StartedAt { get; set; }
    public DateTime? CompletedAt { get; set; }
    public string OutcomeNotes { get; set; } = string.Empty;
}

public class JobStatusLog
{
    public int Id { get; set; }
    public int JobId { get; set; }
    public Job? Job { get; set; }
    public JobStatus OldStatus { get; set; }
    public JobStatus NewStatus { get; set; }
    public string ChangedByUserId { get; set; } = string.Empty;
    public DateTime ChangedAt { get; set; } = DateTime.UtcNow;
}

public class Attachment
{
    public int Id { get; set; }
    public int? JobRequestId { get; set; }
    public string FilePath { get; set; } = string.Empty;
    public string FileType { get; set; } = string.Empty;
    public string UploadedBy { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}
