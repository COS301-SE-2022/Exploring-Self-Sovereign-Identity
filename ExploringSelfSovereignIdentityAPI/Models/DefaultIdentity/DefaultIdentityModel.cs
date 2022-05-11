using System;
using System.Collections.Generic;

namespace ExploringSelfSovereignIdentityAPI.Models.DefaultIdentity
{
    public class DefaultIdentityModel
    {
        public List<Tuple<string, bool>> attributes { get; }

        public DefaultIdentityModel()
        {
            attributes = new List<Tuple<string, bool>>();
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
