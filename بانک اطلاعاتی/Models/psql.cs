using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;
using System.Threading;


namespace بانک_اطلاعاتی.Models
{
    public class psqlMessages
    {
        public enum types {
            ConnectionSucceeded,
            ConnectionFailed
        }
        public static string messages(types msg)
        {
            switch (msg)
            {
                case types.ConnectionSucceeded:
                    return "اتصال موفقیت آمیز بود.";

                case types.ConnectionFailed:
                    return "اتصال ناموفق بود.";

                default:
                    return "شماره پیام ناشناخته است.";
            }
        }
        public static Windows.UI.Color messageColour(types err)
        {
            switch (err)
            {
                case types.ConnectionSucceeded:
                    return Windows.UI.Colors.ForestGreen;

                case types.ConnectionFailed:
                    return Windows.UI.Colors.Red;

                default:
                    return Windows.UI.Colors.Yellow;
            }
        }

    }


    public class psql
    {
        public psql(string Host, string Database, string Username, string Password)
        {
            this.Host = Host;
            this.Username = Username;
            this.Database = Database;
            this._Password = Password;
        }
        ~psql()
        {
            connection.Close();
        }
        public string state = "قطع شده";
        public Windows.UI.Color stateColour = Windows.UI.Colors.Red;


        private string _Username;
        private string _Password;
        private string connectionString { 
            get
            {
                if (String.IsNullOrEmpty(Host) || String.IsNullOrEmpty(Database) || String.IsNullOrEmpty(_Username) || String.IsNullOrEmpty(_Password))
                    return null;
                else 
                    return "Host=" + this.Host + ";Username=" + this._Username + ";Password=" + this._Password + ";Database=" + this.Database;
            }
        }
        private NpgsqlConnection connection;


        private string Host { get; set; }
        private string Database { get; set; }
        private string Password
        {
            set
            {
                if(!String.IsNullOrEmpty(value))
                {
                    this._Password = value;
                }
            }
        }
        private string Username
        {
            set
            {
                if(!String.IsNullOrEmpty(value))
                {
                    this._Username = value;
                }
            }
        }


        public psqlMessages.types Connect()
        {
            this.connection = new NpgsqlConnection(connectionString);
            try
            {
                connection.Open();
                this.state = "متصل شده";
                this.stateColour = Windows.UI.Colors.ForestGreen;
                return psqlMessages.types.ConnectionSucceeded;
            } catch
            {
                this.state = "قطع شده";
                this.stateColour = Windows.UI.Colors.Red;
                return psqlMessages.types.ConnectionFailed;

            }
        }

    }
}
