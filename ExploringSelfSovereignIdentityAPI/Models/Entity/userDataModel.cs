

namespace ExploringSelfSovereignIdentityAPI.Models.Entity
{
    public class UserDataModel
    {
        public string Hash { get; }

        public int Profile_version { get; }

        public string UserID { get; } 

        //public List<Tuple<string, bool>> Attributes { get; }

        //public List<Tuple<string, bool>> Credentials { get; } 

        public UserDataModel()
        {
            //Attributes = new List<Tuple<string, bool>>();
       
        }

        public void AddAttribute(string attribute, bool isRequired)
        {
            /*for (int i = 0; i < attributes.Count; i++)
            {
                if (attributes[i].Item1 == attribute)
                    throw new ArgumentException();
            }*/

            //attributes.Add(new Tuple<string, bool>(attribute, isRequired));
        }

    }

   
}
