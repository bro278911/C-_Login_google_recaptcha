<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Logon.aspx.cs" Inherits="WebApplication1.Logon" %>
<%@ Import Namespace="Newtonsoft.Json" %>
<%@ Import Namespace="Newtonsoft.Json.Linq" %>

<!DOCTYPE html>

<html>
<head>
	<meta charset="utf-8">
	<title>reCaptcha Test</title>
	<script src="https://www.google.com/recaptcha/api.js" async defer></script>
</head>
<body>
	<form runat="server">
		<div>帳號：<input id="txtUserName" type="text" runat="server"/></div>
		<div>密碼：<input id="txtUserPass" type="password" runat="server"/></div>
        <!-- google reCAPTCHA api key (在向使用者顯示的 HTML 程式碼中使用這串網站金鑰)-->
		<div class="g-recaptcha" data-sitekey="6LdT....XRJ-J"></div>
		<div><label runat="server" id="msg"></label></div>
		<div>Persistent Cookie:<asp:CheckBox ID="chkPersistCookie" runat="server" AutoPostBack="false" /></div>
		<div><input type="submit" value="Logon" runat="server" id="cmdLogin" /></div>
	</form>
</body>
</html>