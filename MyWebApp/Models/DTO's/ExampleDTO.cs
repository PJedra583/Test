namespace MyWebApp.Models.DTO_s;

 public class ExampleDTO
    {
        public String firstName { get; set; }
        public String lastName { get; set; }
        public int currentWeight { get; set; }
        public int maxWeight { get; set; }
        public List<Item> backpackItems { get; set; }
        public List<Title> titles { get; set; }
    }