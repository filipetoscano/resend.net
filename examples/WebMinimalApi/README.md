.NET SDK: ASP.NET - Minimal API
=====================================================================

This example shows how to send emails from an ASP.NET Minimal API
application.


How to run
---------------------------------------------------------------------

1. Set the `RESEND_APITOKEN` environment variable to your Resend API.
2. Edit the `From` and `To` in the `Program.cs` as necessary.
3. Run the console app with `dotnet run`.
4. Make a `POST` request to `http://localhost:5001/email/send`

```bash
> set RESEND_APITOKEN=re_8m9gwsVG_6n94KaJkJ42Yj6qSeVvLq9xF
> dotnet run
```