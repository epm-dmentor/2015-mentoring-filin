using System;

namespace Epam.NetMentoring.DesignPatterns.Template_Method
{
    internal class SecondTemplate : BaseTemplate
    {
        private readonly Template template;

        public SecondTemplate(Template template, User user, Email email) : base(template, user, email)
        {
            this.template = template;
        }

        protected override void CheckEmailContent()
        {
            Console.WriteLine("Email content of '{0}' is checked", template.Name);
        }
    }
}