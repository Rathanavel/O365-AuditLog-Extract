using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuditExtractJob.Models
{
    public class SharePointAuditOperation
    {
        public enum AuditOperation
        {
            [DescriptionAttribute("The recipient of an invitation to view or edit a shared file (or folder) has accessed the shared file by clicking on the link in the invitation.")]
            AccessInvitationAccepted,

            [DescriptionAttribute("User sends an invitation to another person (inside or outside their organization) to view or edit a shared file or folder on a SharePoint or OneDrive for Business site. The details of the event entry identifies the name of the file that was shared, the user the invitation was sent to, and the type of the sharing permission selected by the person who sent the invitation.")]
            AccessInvitationCreated
        }       
    }
}
