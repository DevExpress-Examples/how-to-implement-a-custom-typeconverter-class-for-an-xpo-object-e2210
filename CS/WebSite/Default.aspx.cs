using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DevExpress.Xpo;

public partial class _Default : System.Web.UI.Page
{
    Session session;

    protected void Page_Init(object sender, EventArgs e)
    {
        session = new Session();
        xds.Session = session;
    }
}