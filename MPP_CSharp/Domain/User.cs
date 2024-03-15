namespace MPP_CSharp.Domain
{
    public class User : Entity<long>
    {
        private string username;
        private string password;

        public User(long id, string username, string password) : base(id)
        {
            this.username = username;
            this.password = password;
        }
    }
}