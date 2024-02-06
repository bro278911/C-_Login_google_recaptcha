1.修改web.config connectingstring 資料庫連接字串<br/>
2.進入App_Data資料夾修改Method_Login.cs檔案內的資料庫連接語法<br/>
3.修改Logon.aspx內的 datasite-key = (google reCAPTCHA api key (在向使用者顯示的 HTML 程式碼中使用這串網站金鑰)<br/>
4.修改Logon.aspx.內的google api key = google reCAPTCHA api key(用這串密鑰來建立網站和 reCAPTCHA 之間的通訊)<br/>
![image](https://github.com/bro278911/C-_Login_google_recaptcha/assets/52504229/5cd4d468-d8da-409c-be5b-dcc9b9907fd5)
![image](https://github.com/bro278911/C-_Login_google_recaptcha/assets/52504229/50f1daa8-4b44-4413-9d4e-9da7f2a2d46a)

取得登入資訊
使用者帳號：Page.User.Identity.Name<br/>
驗證狀態：Page.User.Identity.IsAuthenticated<br/>
驗證模式：Page.User.Identity.AuthenticationType<br/>
