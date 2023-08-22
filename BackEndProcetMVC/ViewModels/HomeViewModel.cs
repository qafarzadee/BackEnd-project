using BackEndMvcCore.Entities;

namespace BackEndProcetMVC.ViewModels
{
    public class HomeViewModel
    {
        public IEnumerable<Slider> sliders { get; set; }
        public IEnumerable<Welcome> welcomes { get; set; }
        public IEnumerable<Video> videos { get; set; }
        public IEnumerable<NoticeBoard> noticeboards { get; set; }
        public IEnumerable<Course> courses { get; set; }
        public IEnumerable<ExtraInfo> extraInfos { get; set; }
        public IEnumerable<Event> events { get; set; }
       public IEnumerable<Blog> blogs { get; set; }
      public  IEnumerable<PageInfo> pageInfos { get; set; }
    }
}
