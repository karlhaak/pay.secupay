using System;
using pay.secupay;
using pay.secupay.Model;

public partial class success : System.Web.UI.Page
{
    private const string ConfigFileName = "secupay.xml";

    protected void Page_Load(object sender, EventArgs e)
    {
        // Das Anfrageobjekt wird aus der Session genommen. Alternativ geht auch eine Datenbank
        var secupayInit = Session["secupayInit"] as PaySecupayInit;

        // Konfiguration laden
        TPaySecupayConfig config = TPaySecupayConfig.LoadFromFile(Server.MapPath("~/app_data/" + ConfigFileName));

        TPaySecupayManager man = new TPaySecupayManager(config);

        // Statusanfrage erstellen, um sicher zu sein, ob Zahlung erfolgreich ist.
        PaySecupayStatus secupayStatus = new TPayFactory(config).CreateSecupayStatus(secupayInit.ResponseHash);

        // Statusanfrage senden
        man.StatusPayment(secupayStatus);

        // Antwort auswerten
        // TODO: Hier muss im SHOP ein Prozess gestartet werden
        status.InnerHtml = secupayStatus.JsonOut + "<br />" + secupayStatus.JsonIn;
    }
}