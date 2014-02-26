using System;
using pay.secupay.Model;

public partial class payment : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        // Bezahlobjekt aus Session in Beispiel entnehmen
        var secupayInit = Session["secupayInit"] as PaySecupayInit;

        // IFrameUrl setzten, die vom Gateway gesendet wurde.
        framePay.Attributes["src"] = secupayInit.ResponseIFrameUrl;

    }
}