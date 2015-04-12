
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Text;
using System.Net;
using System.IO;
using System.Data;
using System.ComponentModel;
using System.Reflection;
using System.Data.Linq;

namespace OnlineReg
{
    static public class DBCommon
    {

        //Get this from a client cookie -- I can store this in a cookie when they come in with the URL


        public static Decimal GetMyOrgID()
        {
            HttpCookie myCookie = HttpContext.Current.Request.Cookies["RegOnline"];
            string OnlineID = "";

            if (myCookie != null)
            {
                if (myCookie.Value.Length == 0)
                {
                    OnlineID = "1";
                }
                else
                {
                    OnlineID = myCookie.Value;
                }
            }
            else
            {
                //For now default to 1
                OnlineID = "1";
            }

            return Convert.ToDecimal(OnlineID);
        }

        public static RegOrg GetOrg()
        {

            RegOrg MyOrg = null;
            using (MemberDataDataContext db = new MemberDataDataContext())
            {


                MyOrg = (RegOrg)db.RegOrgs.SingleOrDefault(u => u.OrgID == GetMyOrgID());
            }

            return MyOrg;

        }

        public static string GetOrgID(string url)
        {

            RegOrg MyOrg = null;
            string OrgID = "";
            using (MemberDataDataContext db = new MemberDataDataContext())
            {

                MyOrg = (RegOrg)db.RegOrgs.SingleOrDefault(u => u.URL.ToUpper() == url.ToUpper());

                if (MyOrg != null)
                {

                    OrgID = MyOrg.OrgID.ToString();
                }
            }


            return OrgID;

        }


        public static RegMember GetMember(string User, string password)
        {
            RegMember MyMember = null;

            using (MemberDataDataContext db = new MemberDataDataContext())
            {

                MyMember = (RegMember)db.RegMembers.SingleOrDefault(u => u.Username.ToUpper() == User && u.Password.ToUpper() == password.ToUpper());

            }

            return MyMember;

        }

        public static RegMember GetMember(string User)
        {

            RegMember MyMember = null;
            using (MemberDataDataContext db = new MemberDataDataContext())
            {

                MyMember = (RegMember)db.RegMembers.SingleOrDefault(u => u.Username.ToUpper() == User);
            }

            return MyMember;

        }

        public static RegMember GetMember(decimal ID)
        {

            RegMember MyMember = null;
            using (MemberDataDataContext db = new MemberDataDataContext())
            {

                MyMember = (RegMember)db.RegMembers.SingleOrDefault(u => u.MemberID == ID);
            }

            return MyMember;

        }


        public static void ProcessPurchase(string CustomString, string PayerID)
        {
            //&custom=1|16*1|2|6

            //Break out string into two arrays --one for Memeber Info and the other for Bought Items
            string[] container = CustomString.Split('*');

            //Member Info
            string[] MemberInfo = container[0].Split('|');

            //Take Member Info and break out the strings
            //Container ID
            string orgID = MemberInfo[0];

            //MemberID
            string memberID = MemberInfo[1];

            //Now find out the bought Items
            string[] myitems = container[1].Split('|');


            //if (orgID == "SS") //Special Event -- Rising Sun Summer Session
            if (orgID == "FB") //Special Event -- Rising Sun Summer Session
            {

                using (MemberDataDataContext db = new MemberDataDataContext())
                {
                    foreach (string s in myitems)
                    {
                        //Create an Order Record
                        RegSpecEvent myOrder = new RegSpecEvent();
                        myOrder.PlayerID = Convert.ToDecimal(s);
                        myOrder.PayerID = PayerID;
                        myOrder.MemberID = Convert.ToDecimal(memberID);
                        myOrder.SpecEventName = orgID;
                        myOrder.CreatedDate = DateTime.Now;

                        db.RegSpecEvents.InsertOnSubmit(myOrder);
                        db.SubmitChanges();
                    }
                }

            }
            else
            {

                using (MemberDataDataContext db = new MemberDataDataContext())
                {
                    foreach (string s in myitems)
                    {
                        //Create an Order Record
                        RegOrder myOrder = new RegOrder();
                        myOrder.MemberID = Convert.ToDecimal(memberID);
                        myOrder.PayerID = PayerID;
                        myOrder.EventID = Convert.ToDecimal(s);
                        myOrder.CreateDate = DateTime.Now;

                        db.RegOrders.InsertOnSubmit(myOrder);
                        db.SubmitChanges();
                    }
                }

            }
           
        }

        public static void InsertOrder(decimal memberID, decimal EventID,  string PayerID)
        {
           
            using (MemberDataDataContext db = new MemberDataDataContext())
            {
                //Create an Order Record
                    RegOrder myOrder = new RegOrder();
                    myOrder.MemberID = memberID;
                    myOrder.PayerID = PayerID;
                    myOrder.EventID = EventID;
                    myOrder.CreateDate = DateTime.Now;

                    db.RegOrders.InsertOnSubmit(myOrder);
                    db.SubmitChanges();
              
            }

        }

        public static void DeleteOrder(decimal orderID)
        {

            using (MemberDataDataContext db = new MemberDataDataContext())
            {
                //Delete an Order Record
                RegOrder myOrder =  (RegOrder)db.RegOrders.SingleOrDefault(u => u.OrderID == orderID);

                db.RegOrders.DeleteOnSubmit(myOrder);
                db.SubmitChanges();
            }

        }

        public static void InsertPayPalInfo(string PayerID, string PayPalQS)
        {
            using (MemberDataDataContext db = new MemberDataDataContext())
            {
                RegPayPalInfo pp = new RegPayPalInfo();

                pp.PayerID = PayerID;
                pp.PayPalQS = PayPalQS;

                db.RegPayPalInfos.InsertOnSubmit(pp);
                db.SubmitChanges();

            }

        }

       
        public static void ToggleAdmin(decimal MemberID)
        {
            RegMember MyMember = null;
            using (MemberDataDataContext db = new MemberDataDataContext())
            {
                MyMember = (RegMember)db.RegMembers.SingleOrDefault(u => u.MemberID == MemberID);

                if (Convert.ToBoolean(MyMember.IsAdmin))
                {
                    MyMember.IsAdmin = false;
                }
                else
                {
                    MyMember.IsAdmin = true;
                }

                MyMember.UpdateDate = DateTime.Now;
                db.SubmitChanges();

            }
        }

        public static void DeletePlayer(decimal PlayerID)
        {
            RegPlayer MyPlayer = null;
            using (MemberDataDataContext db = new MemberDataDataContext())
            {
                MyPlayer = (RegPlayer)db.RegPlayers.SingleOrDefault(u => u.PlayerID == PlayerID && u.DeleteDate == null);

                MyPlayer.DeleteDate = DateTime.Now;
                db.SubmitChanges();

            }
        }


        public static void ToggleEventStatus(decimal eventID)
        {
            RegEvent MyEvent = null;
            using (MemberDataDataContext db = new MemberDataDataContext())
            {
                MyEvent = (RegEvent)db.RegEvents.SingleOrDefault(u => u.EventID == eventID);

                if (Convert.ToBoolean(MyEvent.Enabled))
                {
                    MyEvent.Enabled = false;
                }
                else
                {
                    MyEvent.Enabled = true;
                }

                MyEvent.UpdateDate = DateTime.Now;
                db.SubmitChanges();

            }
        }

        public static string GetPlayerCount(decimal memberID)
        {

            List<RegPlayer> MyPlayers = null;
            string playerCount = "";
          
            using (MemberDataDataContext db = new MemberDataDataContext())
            {

                MyPlayers = (List<RegPlayer>)db.RegPlayers.Where(u => u.MemberID == memberID && u.DeleteDate == null).ToList();

                if (MyPlayers != null)
                {
                    playerCount = MyPlayers.Count.ToString();
                }

           
            }

            return playerCount;

        }

        public static RegEvent GetEvent(decimal eventID)
        {

            RegEvent MyEvent = null;
            using (MemberDataDataContext db = new MemberDataDataContext())
            {

                MyEvent = (RegEvent)db.RegEvents.SingleOrDefault(u => u.EventID == eventID);
            }

            return MyEvent;

        }

        public static List<RegEvent> GetEvents()
        {

            List<RegEvent> MyEvents = null;
            using (MemberDataDataContext db = new MemberDataDataContext())
            {

                MyEvents = (List<RegEvent>)db.RegEvents.Where(u => u.Enabled == true && u.OrgID == GetMyOrgID()).ToList();
            }

            return MyEvents;

        }

        public static List<RegEvent> GetAllEvents()
        {

            List<RegEvent> MyEvents = null;
            using (MemberDataDataContext db = new MemberDataDataContext())
            {

                MyEvents = (List<RegEvent>)db.RegEvents.Where(u => u.OrgID == GetMyOrgID()).ToList();
            }

            return MyEvents;

        }

        public static void InsertEvent(string eventname, string eventprice)
        {
            using (MemberDataDataContext db = new MemberDataDataContext())
            {
                RegEvent ee = new RegEvent();

                ee.EventName = eventname;
                ee.EventPrice = eventprice;
                ee.Enabled = true;
                ee.OrgID = GetMyOrgID();
                ee.CreateDate = DateTime.Now;
                ee.UpdateDate = DateTime.Now;

                db.RegEvents.InsertOnSubmit(ee);
                db.SubmitChanges();

            }

        }


        public static List<RegMember> GetAllMembers()
        {

            List<RegMember> MyMembers = null;
            using (MemberDataDataContext db = new MemberDataDataContext())
            {

                MyMembers = (List<RegMember>)db.RegMembers.Where(u => u.OrgID == GetMyOrgID()).OrderByDescending(r => r.CreateDate).ToList();

            }

            return MyMembers;

        }

        public static List<vMemberPaid> GetMembersPaid()
        {
            List<vMemberPaid> mem = null;

            using (MemberDataDataContext db = new MemberDataDataContext())
            {
                mem = (List<vMemberPaid>)db.vMemberPaids.Where(u => u.OrgID == GetMyOrgID()).OrderByDescending(r => r.CreateDate).ToList();
               
            }

            return mem;
        }

        public static List<vNotMemberPaid> NotGetMembersPaid()
        {
            List<vNotMemberPaid> mem = null;

            using (MemberDataDataContext db = new MemberDataDataContext())
            {
                mem = (List<vNotMemberPaid>)db.vNotMemberPaids.Where(u => u.OrgID == GetMyOrgID()).OrderByDescending(r => r.CreateDate).ToList();

            }

            return mem;
        }

        public static List<vNotMemberPaidLastYear> NotGetMembersPaidLastYear()
        {
            List<vNotMemberPaidLastYear> mem = null;

            using (MemberDataDataContext db = new MemberDataDataContext())
            {
                mem = (List<vNotMemberPaidLastYear>)db.vNotMemberPaidLastYears.Where(u => u.OrgID == GetMyOrgID()).OrderBy(r => r.Parent1LastName).ToList();

            }

            return mem;
        }

        


        public static List<vEverythingReport> GetRisingStarSummerPlayers(decimal MemberID)
        {
            List<vEverythingReport> mem = null;
            //var myAges = new []{"5","6","7"};
            var myAges = new[] { "6", "7", "8", "9","10","11"};

            using (MemberDataDataContext db = new MemberDataDataContext())
            {
           
                    mem = (List<vEverythingReport>)db.vEverythingReports.Where(u => u.OrgID == GetMyOrgID() && u.MemberID == MemberID && myAges.Contains(u.Age.ToString())).OrderByDescending(r => r.BirthDate).ToList();
              
            }

            return mem;
        }

        public static List<RegSpecEvent> GetPaidRisingStarSummerPlayers(decimal MemberID)
        {
            List<RegSpecEvent> spec = null;

            using (MemberDataDataContext db = new MemberDataDataContext())
            {

                //spec = (List<RegSpecEvent>)db.RegSpecEvents.Where(u => u.MemberID == MemberID && u.SpecEventName == "SS").ToList();
                spec = (List<RegSpecEvent>)db.RegSpecEvents.Where(u => u.MemberID == MemberID && u.SpecEventName == "FB").ToList();
            }

            return spec;
        }

        public static List<vRisingStarRegistration> GetRisingStarView()
        {
            List<vRisingStarRegistration> rs = null;

            using (MemberDataDataContext db = new MemberDataDataContext())
            {
                rs = (List<vRisingStarRegistration>)db.vRisingStarRegistrations.OrderByDescending(r => r.PlayerLastName).ToList();

            }

            return rs;
        }

        public static List<vFallBall> GetFallBallView()
        {
            List<vFallBall> rs = null;

            using (MemberDataDataContext db = new MemberDataDataContext())
            {
                rs = (List<vFallBall>)db.vFallBalls.OrderByDescending(r => r.PlayerLastName).ToList();

            }

            return rs;
        }


        public static List<vEverythingReport> GetEverythingReport(string Age)
        {
            List<vEverythingReport> mem = null;

            using (MemberDataDataContext db = new MemberDataDataContext())
            {
                if (Age == "All")
                {
                    mem = (List<vEverythingReport>)db.vEverythingReports.Where(u => u.OrgID == GetMyOrgID()).OrderByDescending(r => r.BirthDate).ToList();
                }
                else
                {
                    mem = (List<vEverythingReport>)db.vEverythingReports.Where(u => u.Age == Convert.ToInt32(Age) && u.OrgID == GetMyOrgID()).OrderByDescending(r => r.BirthDate).ToList();
                }
            }

            return mem;
        }

        public static List<GetEverythingDataResult> GetEverythingReportSP(string Age)
        {
            List<GetEverythingDataResult> everyList = null;
            RegOrg MyOrg = DBCommon.GetOrg();

            using (MemberDataDataContext db = new MemberDataDataContext())
            {
                ISingleResult<GetEverythingDataResult> every = db.GetEverythingData(Convert.ToDateTime(MyOrg.CutOffDate).ToString("dd-MMM-yyyy"), Convert.ToInt32(GetMyOrgID()), Age);
                    everyList = every.ToList();

            }

            return everyList;
        }




        public static List<RegOrder> GetOrders(decimal memberid)
        {

            List<RegOrder> MyOrders = null;
            using (MemberDataDataContext db = new MemberDataDataContext())
            {

                MyOrders = (List<RegOrder>)db.RegOrders.Where(u => u.MemberID == memberid).OrderBy(r => r.CreateDate).ToList();
            }

            return MyOrders;

        }

        public static bool HasAPlayer(string User)
        {
            bool HasPlayers = false;
            using (MemberDataDataContext db = new MemberDataDataContext())
            {

                RegMember MyMember = (RegMember)db.RegMembers.SingleOrDefault(u => u.Username.ToUpper() == User.ToUpper() && u.OrgID == GetMyOrgID());
                List<RegPlayer> MyPlayers = (List<RegPlayer>)db.RegPlayers.Where(t => t.MemberID == MyMember.MemberID).ToList();

                if (MyPlayers.Count > 0)
                {
                    HasPlayers = true;
                }
            }

            return HasPlayers;

        }


        public static bool EmailDoesExist(string Email)
        {
            bool DoesExist = false;

            using (MemberDataDataContext db = new MemberDataDataContext())
            {
                //Insert if it does not exist

                // if (db.RegMembers.Any(u => u.Username == Email && u.OrgID == GetMyOrgID()))
                if (db.RegMembers.Any(u => u.Username == Email))
                {
                    DoesExist = true;
                }
            }


            return DoesExist;

        }

        public static string SaveMember(decimal MemberID, string FamilyDrPhone,string FamilyDr, string  MothersPhone, string MothersEmail, string MothersFirstName, string MothersLastName, string MothersOccupation, string FathersPhone, string FathersEmail, string FathersFirstName, string FathersLastName, string FathersOccupation)
        {
            using (MemberDataDataContext db = new MemberDataDataContext())
            {

                RegMember mem;

                if (MemberID == 0)
                {
                    mem = new RegMember();
                    mem.CreateDate = DateTime.Now;
                }
                else
                {
                    mem = (RegMember)db.RegMembers.SingleOrDefault(u => u.MemberID == MemberID);
                    mem.UpdateDate = DateTime.Now;
                }

                mem.MemberID = MemberID;
                mem.DoctorPhone = FamilyDrPhone;
                mem.FamilyDoctor = FamilyDr;
                mem.Parent1Phone = MothersPhone;
                mem.Parent1Email = MothersEmail;
                mem.Parent1FirstName = MothersFirstName;
                mem.Parent1LastName = MothersLastName;
                mem.Parent1Occupation = MothersOccupation;
                mem.Parent2Phone = FathersPhone;
                mem.Parent2Email = FathersEmail;
                mem.Parent2FirstName = FathersFirstName;
                mem.Parent2LastName = FathersLastName;
                mem.Parent2Occupation = FathersOccupation;

                if (mem.MemberID == 0)
                {
                    db.RegMembers.InsertOnSubmit(mem);
                }

                db.SubmitChanges();
                return mem.MemberID.ToString();
            }

        }

        public static string SavePlayer(decimal MemberID, string playerid, string firstname, string lastname, string streetaddress, string city, string state, string zip, string birthdate, string sex, string otherSport, string primarycommitment, string healthissues)
        {
            using (MemberDataDataContext db = new MemberDataDataContext())
            {
                //Insert if it does not exist
                RegPlayer player;

                if (playerid.Length == 0)
                {
                    player = new RegPlayer();
                    player.CreateDate = DateTime.Now;
                }
                else
                {
                    player = (RegPlayer)db.RegPlayers.SingleOrDefault(u => u.PlayerID == Convert.ToDecimal(playerid) && u.DeleteDate == null);
                    player.UpdateDate = DateTime.Now;
                }

                player.MemberID = MemberID;
                player.BirthDate = Convert.ToDateTime(birthdate);
                player.City = city;
                player.HeathIssues = healthissues;

                if (otherSport.ToUpper() == "Y")
                {
                    player.OtherSpringSport = true;
                }
                else if (otherSport.ToUpper() == "N")
                {
                    player.OtherSpringSport = false;
                }
                else
                {
                    player.OtherSpringSport = null;
                }

                if (primarycommitment.ToUpper() == "Y")
                {
                    player.PrimaryCommitment = true;
                }
                else if (primarycommitment.ToUpper() == "N")
                {
                    player.PrimaryCommitment = false;
                }
                else
                {
                    player.PrimaryCommitment = null;
                }

                player.PlayerFirstName = firstname;
                player.PlayerLastName = lastname;
                player.StreetAddress = streetaddress;
                player.City = city;
                player.State = state;
                player.Zip = zip;
                player.Sex = sex;


                if (player.PlayerID == 0)
                {
                    db.RegPlayers.InsertOnSubmit(player);
                }

                db.SubmitChanges();
                return player.PlayerID.ToString();
            }

        }

        public static void DeleteParticipations(decimal parentnum, decimal memberid)
        {
            using (MemberDataDataContext db = new MemberDataDataContext())
            {

                var deletedParticipationRecords =
                    from parts in db.RegParticipations
                    where parts.ParentNum == parentnum && parts.MemberID == memberid
                    select parts;

                foreach (var part in deletedParticipationRecords)
                {
                    db.RegParticipations.DeleteOnSubmit(part);
                }

                db.SubmitChanges();
            }

        }

        public static List<RegParticipation> LoadParticipations(decimal memberid, decimal parentnum)
        {
            using (MemberDataDataContext db = new MemberDataDataContext())
            {

                List<RegParticipation> part = (List<RegParticipation>)db.RegParticipations.Where(u => u.MemberID == memberid && u.ParentNum == parentnum).ToList();
                return part;

            }
        }

        public static List<RegPlayer> LoadPlayers(decimal memberid)
        {
            using (MemberDataDataContext db = new MemberDataDataContext())
            {

                List<RegPlayer> players = (List<RegPlayer>)db.RegPlayers.Where(u => u.MemberID == memberid && u.DeleteDate == null).ToList();
                return players.OrderBy(t=>t.PlayerID).ToList();

            }
        }

        public static RegPlayer LoadPlayer(decimal playerID)
        {
            using (MemberDataDataContext db = new MemberDataDataContext())
            {

                RegPlayer player = (RegPlayer)db.RegPlayers.SingleOrDefault(u => u.PlayerID == playerID && u.DeleteDate == null);
                return player;

            }
        }

        public static List<vEverythingReport> LoadPlayersView(decimal memberid)
        {
            using (MemberDataDataContext db = new MemberDataDataContext())
            {

                List<vEverythingReport> players = (List<vEverythingReport>)db.vEverythingReports.Where(u => u.OrgID == GetMyOrgID() && u.MemberID == memberid).ToList();
                return players.ToList();

            }
        }

        public static List<RegPlayer> GetPlayers(DateTime StartDate, DateTime EndDate)
        {
            using (MemberDataDataContext db = new MemberDataDataContext())
            {

                List<RegPlayer> players = (List<RegPlayer>)db.RegPlayers.Where(u => u.BirthDate >= StartDate && u.BirthDate <= EndDate && u.RegMember.OrgID == GetMyOrgID() && u.DeleteDate == null).ToList();
                return players.OrderBy(t => t.BirthDate).ToList();

            }
        }

        public static List<RegPlayer> GetPlayers(Decimal MemberID)
        {
            using (MemberDataDataContext db = new MemberDataDataContext())
            {

                List<RegPlayer> players = (List<RegPlayer>)db.RegPlayers.Where(u => u.MemberID == MemberID && u.DeleteDate == null).ToList();
                return players.OrderBy(t => t.BirthDate).ToList();

            }
        }


        public static void InsertParticipation(decimal memberid, decimal Actid, decimal parentnum)
        {
            using (MemberDataDataContext db = new MemberDataDataContext())
            {
                RegParticipation part = new RegParticipation();

                part.MemberID = memberid;
                part.ActivityID = Actid;
                part.ParentNum = parentnum;

                db.RegParticipations.InsertOnSubmit(part);
                db.SubmitChanges();

            }
        }

        public static void BackUpTables()
        {
            using (MemberDataDataContext db = new MemberDataDataContext())
            {
                DataTable dt1 = LINQToDataTable(db.RegEvents);
                Backup(dt1,"RegEvents.csv");

                DataTable dt2 = LINQToDataTable(db.RegMembers);
                Backup(dt2, "RegMembers.csv");

                DataTable dt3 = LINQToDataTable(db.RegOrders);
                Backup(dt3, "RegOrders.csv");

                DataTable dt4 = LINQToDataTable(db.RegActivities);
                Backup(dt4, "RegActivities.csv");

                DataTable dt5 = LINQToDataTable(db.RegPayPalInfos);
                Backup(dt5, "RegPayPalInfos.csv");

                DataTable dt6 = LINQToDataTable(db.RegParticipations);
                Backup(dt6, "RegParticipations.csv");

                DataTable dt7 = LINQToDataTable(db.RegPlayers);
                Backup(dt7, "RegPlayers.csv");
            }
        }

        private static DataTable LINQToDataTable<T>(IEnumerable<T> varlist)
        {
             DataTable dtReturn = new DataTable();

             // column names 
             PropertyInfo[] oProps = null;

             if (varlist == null) return dtReturn;

             foreach (T rec in varlist)
             {
                  if (oProps == null)
                  {
                       oProps = ((Type)rec.GetType()).GetProperties();
                       foreach (PropertyInfo pi in oProps)
                       {
                            Type colType = pi.PropertyType;

                            if ((colType.IsGenericType) && (colType.GetGenericTypeDefinition()      
                            ==typeof(Nullable<>)))
                             {
                                 colType = colType.GetGenericArguments()[0];
                             }

                            dtReturn.Columns.Add(new DataColumn(pi.Name, colType));
                       }
                  }

                  DataRow dr = dtReturn.NewRow();

                  foreach (PropertyInfo pi in oProps)
                  {
                       dr[pi.Name] = pi.GetValue(rec, null) == null ?DBNull.Value :pi.GetValue
                       (rec,null);
                  }

                  dtReturn.Rows.Add(dr);
             }
             return dtReturn;
        }

        private static void Backup(DataTable dt, string fileName)
        {
            StringBuilder sb = new StringBuilder();

            string[] columnNames = dt.Columns.Cast<DataColumn>().
                                              Select(column => column.ColumnName).
                                              ToArray();
            sb.AppendLine(string.Join(",", columnNames));

            foreach (DataRow row in dt.Rows)
            {
                string[] fields = row.ItemArray.Select(field => field.ToString()).
                                                ToArray();
                sb.AppendLine(string.Join(",", fields));
            }

            string path = HttpContext.Current.Server.MapPath("~/App_Data/" + fileName);

            File.WriteAllText(path, sb.ToString());
        }


        public static DataTable ToDataTable<T>(this IList<T> data)
        {
            PropertyDescriptorCollection properties =
                TypeDescriptor.GetProperties(typeof(T));
            DataTable table = new DataTable();
            foreach (PropertyDescriptor prop in properties)
                table.Columns.Add(prop.Name, Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType);
            foreach (T item in data)
            {
                DataRow row = table.NewRow();
                foreach (PropertyDescriptor prop in properties)
                {
                    try
                    {
                        row[prop.Name] = prop.GetValue(item) ?? DBNull.Value;
                    }
                    catch (Exception ex)
                    {
                        //Do nothing
                    }
                }
                table.Rows.Add(row);
            
            }
            return table;
        }

        public static string CreateAccount(decimal OrgID, string email, string password)
        {
            using (MemberDataDataContext db = new MemberDataDataContext())
            {
                RegMember member = new RegMember();

                member.Username = email;
                member.Password = password;
                member.OrgID = OrgID;
                member.CreateDate = DateTime.Now;
                member.UpdateDate = DateTime.Now;


                db.RegMembers.InsertOnSubmit(member);
                db.SubmitChanges();

                return Convert.ToString(member.MemberID);
            }
        }

        public static void ExportTableData(DataTable dtdata, string myName, HttpResponse Response)
        {
            string attach = "attachment;filename=" + myName + ".csv";
            Response.ClearContent();
            Response.AddHeader("content-disposition", attach);
            Response.ContentType = "application/ms-excel";
            if (dtdata != null)
            {
                foreach (DataColumn dc in dtdata.Columns)
                {
                    Response.Write(dc.ColumnName + ",");
                    //sep = ";";
                }
                Response.Write(System.Environment.NewLine);
                foreach (DataRow dr in dtdata.Rows)
                {
                    for (int i = 0; i < dtdata.Columns.Count; i++)
                    {
                        Response.Write(dr[i].ToString() + ",");
                    }
                    Response.Write("\n");
                }
                Response.End();
            }
        }

    }
}