namespace CarDIler.ViewModel
{
    public class EditBlogPostViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ShortDesc { get; set; }
        public string Desc { get; set; }
        public string Date { get; set; }
        public string DateEdit { get; set; }
        public string AddedBy { get; set; }

        public string CoverPath { get; set; }
    }
}
