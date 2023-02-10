namespace DataloopExercise
{
    class Result
    {
        public string ImageUrl { get; set; }
        public string SourceUrl { get; set; }
        public int Depth { get; set; }

        public Result(string imageUrl, string sourceUrl, int depth)
        {
            ImageUrl = imageUrl;
            SourceUrl = sourceUrl;
            Depth = depth;
        }
    }
}
