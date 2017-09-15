using System;

using Xamarin.Forms;

namespace TheForum
{
    public class Items
    {
        //Initialise the ojbect
        public string Title { get; set; }
        public string Body { get; set; }
        public string Name { get; set; }

        //genarate the item 
        public Items (string title, string body, string name)
        {
            this.Title = title;
            this.Body = body;
            this.Name = name;
        }
    }
}

