using System;
using System.Collections.Generic;
using System.Linq;

namespace Epam.NetMentoring.DesignPatterns.Template_Method
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var alex = new User {Name = "Alex"};
            var bogdan = new User {Name = "Bogdan"};
            var igor = new User {Name = "Igor"};
            var users = new List<User> {alex, igor, bogdan};

            var template = new Template
            {
                Emails = new List<Email>
                {
                    new Email(1, "me@ya.ua", "Test1Subj", "fsdfsdfdsfs"),
                    new Email(2, "fs@ya.ua", "Test2Subj", "fsdfsdfdsfs"),
                    new Email(3, "hf@ya.ua", "Test3Subj", "fsdfsdfdsfs")
                },
                IsRegistered = true,
                Users = users,
                Name = "Template One"
            };

            var firstTempl = new FirstTemplate(template, alex, template.Emails.First());
            firstTempl.ProcessTemplate();

            Console.ReadKey();
        }
    }
}