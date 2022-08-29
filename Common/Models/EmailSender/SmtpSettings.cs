using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Models.EmailSender;

public class SmtpSettings
{
    public string Host { get; set; } = default!;
    public int Port { get; set; }
    public bool EnableSsl { get; set; }
    public string UserName { get; set; } = default!;
    public string Password { get; set; } = default!;
    public string SenderEmail { get; set; } = default!;
    public string SenderDisplayName { get; set; } = default!;
    public string MediaType { get; set; } = default!;
}
