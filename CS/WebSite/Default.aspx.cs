using System;
using System.Data.OleDb;

public partial class _Default : System.Web.UI.Page {
    protected void Page_Load(object sender, EventArgs e) {
        if (!IsCallback && !IsPostBack)
            htmlEditor.Html = LoadHtml();
    }
    protected void htmlEditor_CustomDataCallback(object sender, DevExpress.Web.ASPxClasses.CustomDataCallbackEventArgs e) {
        switch (e.Parameter) {
            case "Save":
                //Code Central - Read Only Mode
                //SaveHtml(htmlEditor.Html);
                break;
        }
    }
    private string LoadHtml() {
        string html = string.Empty;

        using (OleDbConnection connection = GetConnection()) {
            OleDbCommand command = new OleDbCommand(string.Empty, connection);
            command.CommandText = "SELECT TOP 1 [Html] FROM [Items]";

            connection.Open();
            object htmlFromDatabase = command.ExecuteScalar();
            if (htmlFromDatabase != null)
                html = htmlFromDatabase.ToString();
        }

        return html;
    }
    private void SaveHtml(string html) {
        using (OleDbConnection connection = GetConnection()) {
            OleDbCommand command = new OleDbCommand(string.Empty, connection);
            command.CommandText = string.Format("UPDATE [Items] SET [Html] = '{0}'", html);

            connection.Open();
            command.ExecuteNonQuery();
        }
    }
    private OleDbConnection GetConnection() {
        OleDbConnection connection = new OleDbConnection();
        connection.ConnectionString = string.Format("Provider=Microsoft.Jet.OLEDB.4.0;Data Source={0}", MapPath("~/App_Data/Database.mdb"));
        return connection;
    }
}