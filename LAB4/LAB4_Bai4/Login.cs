using System;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace LAB4_Bai4
{
    public partial class Login : Form
    {

        private static readonly HttpClient client = new HttpClient();
        public Login()
        {
            InitializeComponent();
        }

        private void buttonRegister_Click(object sender, EventArgs e)
        {
            Register register = new Register();
            this.Hide();
            register.Show();
        }

        private async void buttonLogin_Click(object sender, EventArgs e)
        {
            string username = textboxUsername.Text;
            string password = textboxPassword.Text;
            string url = textboxURL.Text;

            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Please fill in all fields!");
                return;
            }

            var loginData = new[]
            {
                new KeyValuePair<string, string>("username", username),
                new KeyValuePair<string, string>("password", password)
            };

            var sendData = new FormUrlEncodedContent(loginData);

            try
            {
                HttpResponseMessage response = await client.PostAsync(url, sendData);
                if (response.IsSuccessStatusCode)
                {
                    string body = await response.Content.ReadAsStringAsync();
                    var jsonResponse = JsonSerializer.Deserialize<JsonElement>(body);
                    string tokenType = jsonResponse.GetProperty("token_type").GetString();
                    string accessToken = jsonResponse.GetProperty("access_token").GetString();
                    textboxResult.Text = $"Token type: {tokenType}";
                    textboxResult.Text += Environment.NewLine + $"Access token: {accessToken}";
                    textboxResult.Text += Environment.NewLine + "Successfully logged in!";
                }
                else if (response.StatusCode == System.Net.HttpStatusCode.BadRequest)
                {
                    string body = await response.Content.ReadAsStringAsync();
                    var jsonResponse = JsonSerializer.Deserialize<JsonElement>(body);
                    string errorDetail = jsonResponse.GetProperty("detail").GetString();
                    textboxResult.Text = $"{errorDetail} \n Failed to login! Please try again.";
                }
                else
                    MessageBox.Show("Failed to login! Please check your username/password!");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message} \n Please try again!");
            }
        }

        private void Login_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}