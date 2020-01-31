using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Media;
using Windows.UI;
using Npgsql;



namespace بانک_اطلاعاتی.Models
{
    public class psql : DependencyObject
    {
        public string message
        {
            get { return (String)GetValue(messageProperty); }
            set { SetValue(messageProperty, value); }
        }
        public SolidColorBrush messageColor {
            get { return (SolidColorBrush) GetValue(messageColorProperty); }
            set { SetValue(messageColorProperty, value); }
        }
        public string connectionState {
            set { SetValue(connectionStateProperty, value); }
            get { return (string)GetValue(connectionStateProperty); }
        }
        public SolidColorBrush connectionStateColor
        {
            set { SetValue(connectionStateColorProperty, value); }
            get { return (SolidColorBrush)GetValue(connectionStateColorProperty); }
        }
        public static readonly DependencyProperty messageProperty = DependencyProperty.Register("message", typeof(string), typeof(psql), null);
        public static readonly DependencyProperty messageColorProperty = DependencyProperty.Register("messageColor", typeof(SolidColorBrush), typeof(psql), null);
        public static readonly DependencyProperty connectionStateProperty = DependencyProperty.Register("connectionState", typeof(string), typeof(psql), null);
        public static readonly DependencyProperty connectionStateColorProperty = DependencyProperty.Register("connectionStateColor", typeof(SolidColorBrush), typeof(psql), null);

        private NpgsqlConnection connection;
        private string Host { get; set; }
        private string Database { get; set; }
        private string Password { set; get; }
        private string Username { set; get; }
        private string connectionString
        {
            get
            {
                if (String.IsNullOrEmpty(Host) || String.IsNullOrEmpty(Database) || String.IsNullOrEmpty(Username) || String.IsNullOrEmpty(Password))
                    return null;
                else
                    return "Host=" + this.Host + ";Username=" + this.Username + ";Password=" + this.Password + ";Database=" + this.Database;
            }
        }

        public psql(string Host, string Database, string Username, string Password)
        {
            this.Host = Host;
            this.Username = Username;
            this.Database = Database;
            this.Password = Password;
            this.connectionState = "قطع شده";
            this.connectionStateColor = new SolidColorBrush(Colors.Red);
        }
        public psql(){
            this.connectionState = "قطع شده";
            this.connectionStateColor = new SolidColorBrush(Colors.Red);
        }
        public void UpdateConnectionString(string Host, string Database, string Username, string Password)
        {
            this.Host = Host;
            this.Username = Username;
            this.Database = Database;
            this.Password = Password;
        }

        ~psql()
        {
            try
            {
                connection.Close();
                this.connectionState = "قطع شده";
                this.connectionStateColor = new SolidColorBrush(Colors.Red);
            } catch { }
        }
        public void Connect()
        {
            this.connection = new NpgsqlConnection(connectionString);
            
            try
            {
                connection.Open();
                SetDependencyStates("اتصال موفقیت آمیز بود.", Colors.ForestGreen, "متصل شده", Colors.ForestGreen);
            } catch {
                SetDependencyStates("اتصال ناموفق بود.", Colors.Red, "قطع شده", Colors.Red);
            }
        }

        private void SetDependencyStates(string message, Color messageColor, string connectionState, Color connectionStateColor)
        {
            this.message = message;
            this.messageColor = new SolidColorBrush(messageColor);
            this.connectionState = connectionState;
            this.connectionStateColor = new SolidColorBrush(connectionStateColor);
        }
        private void SetDependencyStates(string message, Color messageColor)
        {
            this.message = message;
            this.messageColor = new SolidColorBrush(messageColor);
        }
    }
}
