using System;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LAB4_Bai4
{
    public partial class Register : Form
    {

        private static readonly HttpClient client = new HttpClient();

        public Register()
        {
            InitializeComponent();
        }

        private async void buttonRegister_Click(object sender, EventArgs e)
        {
            string username = textboxUsername.Text;
            string email = textboxEmail.Text;
            string password = textboxPassword.Text;
            string first_name = textboxFirstName.Text;
            string last_name = textboxLastName.Text;
            string sex = textboxSex.Text;
            string birthday = textboxBirthday.Text;
            string language = textboxLanguage.Text;
            string phone = textboxPhone.Text;
            string url = "https://nt106.uitiot.vn/api/v1/user/signup";

            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(email)
                || string.IsNullOrWhiteSpace(password) || string.IsNullOrWhiteSpace(first_name)
                || string.IsNullOrWhiteSpace(last_name) || string.IsNullOrWhiteSpace(sex)
                || string.IsNullOrWhiteSpace(birthday) || string.IsNullOrWhiteSpace(language) || string.IsNullOrWhiteSpace(phone))
            {
                MessageBox.Show("Fill in all fields!");
                return;
            }

            var signupData = new
            {
                username = username,
                email = email,
                password = password,
                first_name = first_name,
                last_name = last_name,
                sex = sex,
                birthday = birthday,
                language = language,
                phone = phone
            };

            string jsonObject = JsonSerializer.Serialize(signupData);
            var sendData = new StringContent(jsonObject, Encoding.UTF8, "application/json");

            try
            {
                HttpResponseMessage response = await client.PostAsync(url, sendData);
                if (response.IsSuccessStatusCode)
                    MessageBox.Show("Successfully signed up! You may now login!");
                else if (response.StatusCode == System.Net.HttpStatusCode.BadRequest)
                {
                    string body = await response.Content.ReadAsStringAsync();
                    var error = JsonSerializer.Deserialize<JsonElement>(body);
                    string details = error.GetProperty("detail").GetString();
                    MessageBox.Show($"Failed to sign up - {details}");
                }
                else
                    MessageBox.Show($"Failed to sign up - Error code: {response.StatusCode}");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Connection error: {ex.Message}");
            }
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            Login login = new Login();
            this.Hide();
            login.Show();
        }

        private void Register_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void Register_Load(object sender, EventArgs e)
        {

        }
    }
}
