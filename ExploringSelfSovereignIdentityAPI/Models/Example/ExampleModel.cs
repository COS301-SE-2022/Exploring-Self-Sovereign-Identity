namespace ExploringSelfSovereignIdentityAPI.Models.Example
{
    public class ExampleModel
    {
        public string FieldA { get; set; }
        public string FieldB { get; set; }

        public ExampleModel()
        {

        }
        public ExampleModel(string FieldA, string FieldB)
        {
            this.FieldA = FieldA;
            this.FieldB = FieldB; 
        }
    }
}
