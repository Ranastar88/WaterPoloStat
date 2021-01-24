using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace WaterPoloStat.Domain
{
    public abstract class BaseTenantInfo
    {
        [Required]
        public string LicenzaId { get; set; }
        [Required]
        public string CreatoDa { get; set; }
        public string ModificatoDa { get; set; }
        public DateTime DataCreazione { get; set; }
        public DateTime? DataUltimaModifica { get; set; }

    }
}
