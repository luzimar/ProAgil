using ProAgil.Application.ViewModels.Base;

namespace ProAgil.Application.ViewModels
{
    public class UserViewModel : BaseViewModel
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string FullName { get; set; }
    }
}
