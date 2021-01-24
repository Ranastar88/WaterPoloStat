using System;
using System.Collections.Generic;
using System.Text;

namespace WaterPoloStat.Domain
{
    public abstract class BaseInfo : BaseTenantInfo
    {
        public string CancellatoDa { get; set; }
        public bool Cancellato { get; set; }
        public DateTime? DataCancellazione { get; set; }
    }
}
