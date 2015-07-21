namespace Epam.NetMentoring.DesignPatterns.Template_Method
{
    internal class Email
    {
        public Email(int id, string to, string subj, string message)
        {
            Id = id;
            To = to;
            Subj = subj;
            Message = message;
        }

        public int Id { get; set; }
        public string To { get; set; }
        public string Subj { get; set; }
        public string Message { get; set; }
    }
}