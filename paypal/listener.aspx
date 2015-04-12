<!--
	OK enough of this VB balloney, let's get real although C# is not real it is close
	let's use it here to handle it
-->
<%@ Page Language="C#"    %>
<%@ Import Namespace =  "System"%>
<%@ Import Namespace =  "System.IO"%>
<%@ Import Namespace =  "System.Text"  %>
<%@ Import Namespace =  "System.Net"  %>
<%@ Import Namespace =  "System.Web"  %>
<%@ Import Namespace =	"System.Net.Mail" %>
 
<script language="JavaScript">
    //Some JavaScript you may need goes here
</script>
 
<script language="C#" Option="Explicit"  runat="server">
 
protected void Page_Load(object sender, EventArgs e)
{
 
	//Post back to either sandbox or live
    string strSandbox = ConfigurationManager.AppSettings["PayPalURL"];
	HttpWebRequest req = (HttpWebRequest)WebRequest.Create(strSandbox);
	//Set values for the request back
	req.Method = "POST";
	req.ContentType = "application/x-www-form-urlencoded";
	byte[] param = Request.BinaryRead(HttpContext.Current.Request.ContentLength);
	string strRequest = Encoding.ASCII.GetString(param);
	string strResponse_copy = strRequest;  //Save a copy of the initial info sent by PayPal
	strRequest += "&cmd=_notify-validate";
	req.ContentLength = strRequest.Length;
	
	//for proxy
	//WebProxy proxy = new WebProxy(new Uri("http://url:port#"));
	//req.Proxy = proxy;
	//Send the request to PayPal and get the response
	StreamWriter streamOut = new StreamWriter(req.GetRequestStream(), System.Text.Encoding.ASCII);
	streamOut.Write(strRequest);
	streamOut.Close();
	StreamReader streamIn = new StreamReader(req.GetResponse().GetResponseStream());
	string strResponse = streamIn.ReadToEnd();
	streamIn.Close();

    
    //string dataFile = Server.MapPath("~/paypal/IPNdata.txt");
    //using (StreamWriter outfile = new StreamWriter(dataFile, true))
    //{
    //    string WriteOut = DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToShortTimeString() + " Response: " + strResponse + " QueryStrings: " + strResponse_copy + Environment.NewLine;
    //    outfile.Write(WriteOut);
    //}
    
 
	if (strResponse == "VERIFIED")
	{
		//check the payment_status is Completed
		//check that txn_id has not been previously processed
		//check that receiver_email is your Primary PayPal email
		//check that payment_amount/payment_currency are correct
		//process payment

        //strResponse_copy = "txn_type=subscr_signup&subscr_id=I-4BKM4A4GD6JP&last_name=Sprows&residence_country=US&mc_currency=USD&item_name=MySocialPromo&business=seller_1348759594_biz%40gmail.com&amount1=0.00&amount3=20.00&recurring=1&verify_sign=AQU0e5vuZCvSg-XJploSa.sGUDlpAgzmP5YXj5SUv2JqMyy9WiWG-g7Z&payer_status=verified&test_ipn=1&payer_email=sprows_1348758987_per%40gmail.com&first_name=Tom&receiver_email=seller_1348759594_biz%40gmail.com&payer_id=J5DU7ER3BR6YL&reattempt=1&subscr_date=11%3A54%3A17+Oct+19%2C+2012+PDT&custom=22&charset=windows-1252&notify_version=3.7&period1=30+D&mc_amount1=0.00&period3=1+M&mc_amount3=20.00&ipn_track_id=3cf0c91285038";
        
        bool txTypeStatus = false;
        bool receiverEmail = false;
       
        
	        // pull the values passed on the initial message from PayPal
	
		  NameValueCollection these_argies = HttpUtility.ParseQueryString(strResponse_copy);

          if (these_argies["txn_type"] != null)
          {
              string txnType = these_argies["txn_type"].ToString();
              if (txnType == "cart")
              {
                  txTypeStatus = true;
              }
          }

         if (these_argies["receiver_email"] != null)
         {
             if (these_argies["receiver_email"].Trim().ToUpper() == ConfigurationManager.AppSettings["PayPalBusinessEmail"].Trim().ToUpper())
             {
                 receiverEmail = true;
             }
              
         }

        //Insert the PayPalInfo every time
         string PayerID = "";
         if (these_argies["payer_id"] != null)
         {
               PayerID = these_argies["payer_id"];
               OnlineReg.DBCommon.InsertPayPalInfo(PayerID, strResponse_copy);
         }
        
	         

         if (these_argies["custom"] != null)
         {
             string CustomString = these_argies["custom"].ToString();


             if (receiverEmail && txTypeStatus)
			        {
			              //Process Record -Update record and record what they bought
                        OnlineReg.DBCommon.ProcessPurchase(CustomString, PayerID);
			        }
             
         }

      
         
		// more checks needed here specially your account number and related stuff
	}
	else if (strResponse == "INVALID")
	{
		//log for manual investigation
	}
	else
	{
		//log response/ipn data for manual investigation
	}
}  // --- end of page load --


// IsNumeric Function
static bool IsNumeric(object Expression)
{
    // Variable to collect the Return value of the TryParse method.
    bool isNum;

    // Define variable to collect out parameter of the TryParse method. If the conversion fails, the out parameter is zero.
    double retNum;

    // The TryParse method converts a string in a specified style and culture-specific format to its double-precision floating point number equivalent.
    // The TryParse method does not generate an exception if the conversion fails. If the conversion passes, True is returned. If it does not, False is returned.
    isNum = Double.TryParse(Convert.ToString(Expression), System.Globalization.NumberStyles.Any, System.Globalization.NumberFormatInfo.InvariantInfo, out retNum);
    return isNum;
}


</script>
	
	
<html>
<head id="Head1" runat="server" />
<title>IPN PayPal</title>
<body>
<asp:label id="debuggy" runat="server"/>
<h2> my test page</h2>
Load this first to check the syntax of your page
</body>
</html>


