namespace LastSeenApplication
{
    public class LastSeenUser
    {
        public string UserId { get; set; }
        public string Nickname { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime RegistrationDate { get; set; }
        public DateTime? LastSeenDate { get; set; }
        public bool IsOnline { get; set; }
    }
}