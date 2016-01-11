using System;


namespace DVA231_Projekt.Models
{
    //Stores information about an individual textpost
    public class Textpost
    {
        //Entity framework will generate the identity property
        public int Id { get; set; }
        public DateTime Created { get; set; }
        public string Title { get; set; }
        public string UserName { get; set; }
        public string Message { get; set; }
    }
}
