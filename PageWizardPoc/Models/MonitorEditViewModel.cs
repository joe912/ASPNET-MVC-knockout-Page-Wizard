using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;
using PageWizardPoc.Attributes;

namespace PageWizardPoc.Models
{
    public class MonitorEditViewModel
    {
        public int MonitorId { get; set; }

        public string MonitorName { get; set; }

        [BindFromJson]
        public IEnumerable<TriggerViewModel> Triggers { get; set; }

        public bool EditingTriggerOrAlert { get; set; }
    }

    public class TriggerViewModel
    {
        [JsonProperty("triggerId")]
        public int TriggerId { get; set; }

        [JsonProperty("triggerName")]
        public string TriggerName { get; set; }
    }
}