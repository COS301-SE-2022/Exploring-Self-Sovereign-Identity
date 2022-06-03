namespace ExploringSelfSovereignIdentityAPI.Models.Entity
{
    public class OrganizationCredentials
    {
        public string Id { get; set; }

        //public List<string> Credentials { get; } 


        public void AddCredential(string credential)
        {
            /*for (int i = 0; i < credential.Count; i++)
            {
                if (credential[i].Item1 == credential)
                    throw new ArgumentException();
            }*/

            //Credentials.Add(new <string>(credential));
        }
    }
}
