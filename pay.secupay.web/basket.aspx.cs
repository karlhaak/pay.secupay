using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using pay.secupay;
using pay.secupay.Model;

public partial class basket : System.Web.UI.Page
{
    private const string ConfigFileName = "secupay.xml";

    protected void btnOK_OnClick(object sender, EventArgs e)
    {
        TPaySecupayConfig config = TPaySecupayConfig.LoadFromFile(Server.MapPath("~/app_data/" + ConfigFileName));

        // Zahlungsobjekt erzeugen
        PaySecupayInit secupayInit = new TPayFactory(config).CreateSecupayInit(Convert.ToDecimal(txtBetrag.Text));

        // Daten in Zahlungsobjekt übergeben
        secupayInit.Firstname = "Karl";
        secupayInit.Lastname = "Mustermann";
        secupayInit.Langauge = "DE";
        secupayInit.Street = "Hauptstrasse";
        secupayInit.Housenumber = "12";
        secupayInit.Zip = "50000";
        secupayInit.City = "Köln";
        secupayInit.Telephone = "";
        secupayInit.Email = "";
        secupayInit.PaymentAction = EnumPaymentAction.sale.ToString();
        secupayInit.PaymentType = drpType.SelectedValue;

        // Artikel übergeben
        secupayInit.Basket.Add(new PaySecupayBasket
        {
            Name = "Item",
            ArticleNumber = "01-1111",
            Ean = "111111111111111111",
            Model = "Model",
            Price = "100",
            Quantity = "1",
            Tax = "19",
            Total = "100",
        }.SetNew(config.Username));

        // Lieferadresse übergeben
        secupayInit.DeliveryAddress = new PaySecupayDeliveryAddress
        {
            Firstname = secupayInit.Firstname,
            Lastname = secupayInit.Lastname,
            Company = secupayInit.Company,
            Street = secupayInit.Street,
            Housenumber = secupayInit.Housenumber,
            Zip = secupayInit.Zip,
            City = secupayInit.City,
            Country = secupayInit.Country
        }.SetNew(config.Username);

        // Bezahlung am Gateway anmelden und IFrameUrl generieren
        TPaySecupayManager man = new TPaySecupayManager(config);
        man.InitPayment(secupayInit);

        // Objekt wird im Beispiel in Session gesichert und auf Bezahlseite weitergeleitet
        Session["secupayInit"] = secupayInit;
        Response.Redirect("payment.aspx");
    }

  
}