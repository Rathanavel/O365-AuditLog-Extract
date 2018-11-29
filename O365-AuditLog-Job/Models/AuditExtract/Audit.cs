using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuditExtractJob.Models.AuditExtract
{
    class Audit
    {
        public string contentUri { get; set; }

        public string contentId { get; set; }

        public string contentType { get; set; }

        public string contentCreated { get; set; }

        public string contentExpiration { get; set; }
    }
}
