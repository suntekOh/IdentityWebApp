
using System.ComponentModel.DataAnnotations;

namespace Common.Models.EmailSender;

public class EmailInfo
{
	public EmailContact? Sender { get; set; }
	public List<EmailContact> Recipients { get; set; } = new List<EmailContact>();
	public string Subject { get; set; } = default!;
	public string Emailbody { get; set; } = default!;
}

public class EmailContact
{
	[Required]
	public string Email { get; set; } = default!;
	public string? DisplayName { get; set; }
}

