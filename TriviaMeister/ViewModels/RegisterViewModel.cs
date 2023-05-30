using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using TriviaMeister.Models;
using TriviaMeister.Views;
using Xamarin.Forms;

namespace TriviaMeister.ViewModels
{
    public class RegisterViewModel : BaseViewModel
    {
        private string _firstName;
        private string _lastName;
        private string _email;
        private string _password;
        private string _confirmPassword;

        public string FirstName
        {
            get => _firstName;
            set => SetProperty(ref _firstName, value);
        }

        public string LastName
        {
            get => _lastName;
            set => SetProperty(ref _lastName, value);
        }

        public string Email
        {
            get => _email;
            set => SetProperty(ref _email, value);
        }

        public string Password
        {
            get => _password;
            set => SetProperty(ref _password, value);
        }

        public string ConfirmPassword
        {
            get => _confirmPassword;
            set => SetProperty(ref _confirmPassword, value);
        }

        public Command LoginCommand { get; }
        public Command RegisterCommand { get; }

        public RegisterViewModel()
        {
            RegisterCommand = new Command(OnRegisterClicked);
            LoginCommand = new Command(OnLoginClicked);
        }

        private void Reset()
        {
            FirstName = string.Empty;
            LastName = string.Empty;
            Email = string.Empty;
            Password = string.Empty;
            ConfirmPassword = string.Empty;
        }

        private async void OnRegisterClicked()
        {
            // FirstName validation
            if (string.IsNullOrEmpty(FirstName))
            {
                await MessageService.ShowAsync("Required", "First Name is required.", "Ok");
                return;
            }
            else if (FirstName.Length > 64)
            {
                await MessageService.ShowAsync("Invalid", "First Name should be at most be 64 characters long.", "Ok");
                return;
            }

            // LastName validation
            if (string.IsNullOrEmpty(LastName))
            {
                await MessageService.ShowAsync("Required", "Last Name is required.", "Ok");
                return;
            }
            else if (LastName.Length > 64)
            {
                await MessageService.ShowAsync("Invalid", "Last Name should be at most be 64 characters long.", "Ok");
                return;
            }
            
            // Email validation
            if (string.IsNullOrEmpty(Email))
            {
                await MessageService.ShowAsync("Required", "Email is required.", "Ok");
                return;
            }
            else if (!IsValidEmail(Email))
            {
                await MessageService.ShowAsync("Invalid", "Please enter a valid email address.", "Ok");
                return;
            }
            else if (!(await IsEmailUnique(Email)))
            {
                await MessageService.ShowAsync("Invalid", "Email is already in use. Please use another one.", "Ok");
                return;
            }

            // Password Validation
            if (string.IsNullOrEmpty(Password))
            {
                await MessageService.ShowAsync("Required", "Password is required.", "Ok");
                return;
            } 
            else if(Password.Length < 8) 
            {
                await MessageService.ShowAsync("Invalid", "Password should be at least be 8 characters long.", "Ok");
                return;
            }
            else if (Password.Length > 16)
            {
                await MessageService.ShowAsync("Invalid", "Password should be at most be 16 characters long.", "Ok");
                return;
            }
            else if (!IsValidPassword(Password))
            {
                await MessageService.ShowAsync("Invalid", "Password must contain the following:\n- One uppercase letter.\n- One lowercase letter.\n- One number.\n- One special character (@$!%*?&).", "Ok");
                return;
            }

            // Confirm Password Validation
            if (Password != ConfirmPassword)
            {
                await MessageService.ShowAsync("Mismatch", "Confirm Password must match the Password.", "Ok");
                return;
            }

            await UserStore.AddItemAsync(new User()
            {
                FirstName = FirstName.Trim(),
                LastName = LastName.Trim(),
                Email = Email.Trim(),
                Password = Password
            });

            await MessageService.ShowAsync("Account Created", "Your account was successfully created.", "Ok");
            Reset();
        }

        private async Task<bool> IsEmailUnique(string email)
        {
            var users = await UserStore.GetItemsAsync();
            var user = users.Where((User u) => u.Email == email.Trim()).FirstOrDefault();

            return await Task.FromResult(user == default(User));
        }

        private bool IsValidEmail(string email)
        {
            string emailPattern = @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$";
            return Regex.IsMatch(email, emailPattern);
        }

        private bool IsValidPassword(string password)
        {
            string passwordPattern = @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,16}$";
            return Regex.IsMatch(password, passwordPattern);
        }

        private async void OnLoginClicked()
        {
            await Navigation.PopAsync();
        }
    }
}
