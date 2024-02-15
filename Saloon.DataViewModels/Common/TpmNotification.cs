using System;
using System.Net.Mail;

namespace Saloon.DataViewModels.Common
{
    public class TpmNotification
  {
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Subject { get; set; }
    public string Body { get; set; }
    public Attachment Attachment { get; set; } = null;
    
  }
}
