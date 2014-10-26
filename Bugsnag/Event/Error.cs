﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bugsnag.Event
{    
    public class Error : Event
    {
        public Exception Exception { get; private set; }
        public bool? IsRuntimeEnding { get; private set; }
        public StackTrace CallTrace { get; set; }
        public StackTrace CreationTrace { get; private set; }

        public Error(Exception exp, bool? runtimeEnding = null, bool recordTrace = true): base()
        {
            Exception = exp;
            IsRuntimeEnding = runtimeEnding;
            Severity = Severity.Error;

            if (runtimeEnding != null)
                MetaData.AddToTab("Exception Details", "Runtime Ending", IsRuntimeEnding);

            if (exp.HelpLink != null)
                MetaData.AddToTab("Exception Details", "Help Link", exp.HelpLink);

            if (exp.Source != null)
                MetaData.AddToTab("Exception Details", "Source", exp.Source);

            if (exp.TargetSite != null)
                MetaData.AddToTab("Exception Details", "Target Site", exp.TargetSite);

            if (recordTrace)
                CreationTrace = new StackTrace(1);
        }
    }
}