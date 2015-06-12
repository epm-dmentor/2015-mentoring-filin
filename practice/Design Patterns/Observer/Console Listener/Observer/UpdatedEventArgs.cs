using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Epam.NetMentoring.Patterns.Observer
{
    class UpdatedEventArgs : EventArgs
    {
        public string Message { get; set; }
        public UpdatedEventArgs(string message)
        {
            Message = message;
        }
    }
}
