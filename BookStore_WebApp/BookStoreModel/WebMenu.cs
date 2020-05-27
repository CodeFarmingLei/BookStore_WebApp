namespace BookStore.Model
{
    public class WebMenu
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Link { get; set; }
        public int ParentId { get; set; }

        public int IsShow { get; set; } //这个是用于设定是否在导航栏上进行显示的 0 false 1 true
    }
}