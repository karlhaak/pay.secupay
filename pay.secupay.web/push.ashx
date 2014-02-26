<%@ WebHandler Language="C#" Class="push" %>

using System.Web;
using pay.secupay;
using pay.secupay.Model;

public class push : IHttpHandler {

    public void ProcessRequest(HttpContext context)
    {
        // Push kommt zeitlich versetzt zur Weiterleitung auf Success Url
        // Es kann nicht davon ausgegangen werden, das der PUSH vom Gateway schon 
        // vor der Weiterleitung gelaufen ist.
        
        // Config einladen
        string configfileName = context.Server.MapPath("~/APP_DATA/secupay.xml");
        TPaySecupayConfig config = TPaySecupayConfig.LoadFromFile(configfileName);

        if (context.Request.UrlReferrer == null) return;

        // Manager starten
        TPaySecupayManager man = new TPaySecupayManager(config);
        
        // Verarbeitung Push
        PaySecupayPush puschOut = man.ProcessPush(context.Request.Form, context.Request.RawUrl, context.Request.UrlReferrer.ToString());

        // Antwort von Push senden
        context.Response.Write(puschOut.PostOut);
        
        //TODO: Hier weitere Logik ziehen
    }

    public bool IsReusable
    {
        get
        {
            return false;
        }
    }

}