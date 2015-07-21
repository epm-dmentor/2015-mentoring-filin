using System;
using System.Linq;

namespace Epam.NetMentoring.DesignPatterns.Template_Method
{
    internal abstract class BaseTemplate
    {
        private readonly Email email;
        private readonly Template template;
        private readonly User user;

        protected BaseTemplate(Template template, User user, Email email)
        {
            this.template = template;
            this.user = user;
            this.email = email;
        }

        public void ProcessTemplate()
        {
            CheckVars(template);
            CheckAccess(template, user);
            CheckEmailRegistration(template, email);
            CheckEmailContent();
            Save(template);
        }

        protected virtual void Save(Template templt)
        {
            Console.WriteLine("'{0}' has been saved", templt.Name);
        }

        protected virtual void CheckVars(Template templt)
        {
            Console.WriteLine(string.IsNullOrEmpty(templt.Name)
                ? "'{0}' is not corrected"
                : "'{0}' is correct", templt.Name);
        }

        protected virtual void CheckEmailRegistration(Template templt, Email emailContent)
        {
            Console.WriteLine(templt.Emails.Any(x => x.Id == emailContent.Id)
                ? "Email with id {0} is registered on server"
                : "Email with id {0} is not registered on server", email.Id);
        }

        protected virtual void CheckAccess(Template templt, User userName)
        {
            Console.WriteLine(templt.Users.Contains(userName)
                ? "User {0} has access to '{1}'"
                : "User {0} has no access to '{1}'",
                userName.Name, templt.Name);
        }

        protected abstract void CheckEmailContent();
    }
}