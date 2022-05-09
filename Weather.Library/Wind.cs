namespace Weather.Library
{
    public class Wind
    {
        public decimal Speed { get; set; }
        public int Deg { get; set; }
        public decimal Gust { get; set; }

        public string Direction() => Deg switch
        {
            >= 349 and <= 360 or >= 0 and < 11 => "North",
            >= 11 and < 34 => "North by Northeast",
            >= 34 and < 56 => "Northeast",
            >= 56 and < 79 => "East by Northeast",
            >= 79 and < 101 => "East",
            >= 101 and < 124 => "East by Southeast",
            >= 124 and < 146 => "Southeast",
            >= 146 and < 169 => "South by Southeast",
            >= 169 and < 191 => "South",
            >= 191 and < 214 => "South by Southwest",
            >= 214 and < 236 => "Southwest",
            >= 236 and < 259 => "West by Southwest",
            >= 259 and < 281 => "West",
            >= 281 and < 304 => "West by Northwest",
            >= 304 and < 326 => "Northwest",
            >= 326 and < 349 => "North by Northwest",
            > 360 or < 0 => "Error in Degrees",
        };


        public override string ToString()
        {
            var response = "\nWinds are out of the " + Direction() + " at " + Speed + " with gusts to " + Gust + "\n";
            return response;
        }
    }

}