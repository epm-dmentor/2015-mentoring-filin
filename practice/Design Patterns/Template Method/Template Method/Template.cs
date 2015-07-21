using System.Collections.Generic;

namespace Epam.NetMentoring.DesignPatterns.Template_Method
{
    internal class Template
    {
        public IEnumerable<Email> Emails;
        public IEnumerable<User> Users { get; set; }
        public bool IsRegistered { get; set; }
        public string Name { get; set; }
    }
}