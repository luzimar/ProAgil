using ProAgil.Application.ViewModels.Base;

namespace ProAgil.Application.ViewModels
{
    public class UserLoginViewModel : BaseViewModel
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
