using System;
using System.Collections.Generic;

namespace ExploringSelfSovereignIdentityAPI.Models.DefaultIdentity
{
    public class DefaultIdentityModel
    {
        public string IdentityName { get; }

        public string IssuerSignature { get; }

        public string HolderSignature { get; set; }
        public List<Tuple<string, bool>> attributes { get; }

        public DefaultIdentityModel()
        {
            attributes = new List<Tuple<string, bool>>();
            IssuerSignature = "#CodeOfDuty";
            IdentityName = "Default Identity";
        }

        public void addAttribute(string attribute, bool isRequired)
        {
            /*for (int i = 0; i < attributes.Count; i++)
            {
                if (attributes[i].Item1 == attribute)
                    throw new ArgumentException();
            }*/

            attributes.Add(new Tuple<string, bool>(attribute, isRequired));
        }

    }
}
