using System.Data;
using System.Data.SqlClient;
using System.Web.Configuration;

/// <summary>
/// Method_Fish 的摘要描述
/// </summary>
public class Method_Login
{
    string web_sql = WebConfigurationManager.ConnectionStrings["Login_test"].ConnectionString;
    SqlConnection conn = null;
    public Method_Login()
    {
        conn = new SqlConnection(web_sql);
    }
    #region 登入驗證
    public DataTable login_check(string account)
    {
        SqlCommand cmd = new SqlCommand(@"Select [Pwd] from [SQL].[dbo].[Users] where (uname = @uname)");
        cmd.Parameters.Add("@uname", SqlDbType.VarChar, 50).Value = account;
        DataTable dt = Login_WEB.SqlHelper.cmdTable(cmd);
        return dt;
    }
    #endregion

}