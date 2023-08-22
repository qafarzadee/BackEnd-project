using BackEndMvcCore.Entities;

namespace BackEndProcetMVC.ViewModels
{
    public class ContectViewModel
    {
        public IEnumerable<Adress> adresses { get; set; }
        public IEnumerable<AdressMessage> messages { get; set; }
    }
}
