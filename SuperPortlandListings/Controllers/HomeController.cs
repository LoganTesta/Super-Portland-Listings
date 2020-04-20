using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SuperPortlandListings.Models;

using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;

using Microsoft.AspNetCore.Html; //For using HTML in strings 
using Microsoft.AspNetCore.Http;   // For Sessions


namespace SuperPortlandListings.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AboutUs()
        {
            return View();
        }

        public IActionResult Listings()
        {
            ViewData["theListings"] = SuperPortlandListings.Program.theListings;
            ViewData["projectDate"] = SuperPortlandListings.Program.projectDate;

            return View();
        }

        [HttpPost]
        public IActionResult Listings(ListingsModel listingsModel)
        {

            if (ModelState.IsValid)
            {
                ViewData["theListings"] = SuperPortlandListings.Program.theListings;
                ViewData["projectDate"] = SuperPortlandListings.Program.projectDate;

                bool validForm = true;
                string searchResults = "";

                string searchCity = "";
                string searchBeds = "";
                string searchBaths = "";
                string searchParkingSpaces = "";
                string searchStories = "";
                string searchPriceRange = "";
                string searchByOptions = "";
                string displayAll = "";

                try
                {
                    searchCity = System.Web.HttpUtility.HtmlEncode(Request.Form["searchCity"]);
                    searchBeds = System.Web.HttpUtility.HtmlEncode(Request.Form["searchBeds"]);
                    searchBaths = System.Web.HttpUtility.HtmlEncode(Request.Form["searchBaths"]);
                    searchParkingSpaces = System.Web.HttpUtility.HtmlEncode(Request.Form["searchParkingSpaces"]);
                    searchStories = System.Web.HttpUtility.HtmlEncode(Request.Form["searchStories"]);
                    searchPriceRange = System.Web.HttpUtility.HtmlEncode(Request.Form["searchPriceRange"]);
                    searchByOptions = System.Web.HttpUtility.HtmlEncode(Request.Form["searchByOptions"]);
                    displayAll = System.Web.HttpUtility.HtmlEncode(Request.Form["searchListingsShowAll"]);
                }
                catch (Exception)
                {
                    searchCity = "";
                    searchBeds = "";
                    searchBaths = "";
                    searchParkingSpaces = "";
                    searchStories = "";
                    searchPriceRange = "";
                    searchByOptions = "";
                    displayAll = "";
                }

                if (displayAll == "Show All")
                {
                    validForm = false;
                }

                if (searchCity == "" && searchBeds == "" && searchBaths == "" && searchParkingSpaces == "" && searchStories == "" && searchPriceRange == "" && searchByOptions == "")
                {
                    validForm = false;
                }


                searchResults = "";
                if (validForm)
                {
                    if (searchCity != "")
                    {
                        searchResults += " Showing listings in <strong>" + searchCity + "</strong>.";
                    }

                    if (searchBeds != "")
                    {
                        searchResults += " Showing listings with <strong>" + searchBeds + "+ bedrooms</strong>.";
                    }

                    if (searchBaths != "")
                    {
                        searchResults += " Showing listings with <strong>" + searchBaths + "+ bathrooms</strong>.";
                    }

                    if (searchParkingSpaces != "")
                    {
                        searchResults += " Showing listings with a <strong>" + searchParkingSpaces + " car garage</strong>.";
                    }

                    if (searchStories != "")
                    {
                        searchResults += " Showing <strong>" + searchStories + " story listings</strong>.";
                    }

                    if (searchPriceRange != "")
                    {
                        searchResults += " Showing listings between <strong>" + searchPriceRange + "</strong>.";
                    }

                    if (searchByOptions != "")
                    {
                        searchResults += " Order by <strong>" + searchByOptions + "</strong>.";
                    }
                }
                else
                {
                    searchCity = "";
                    searchBeds = "";
                    searchBaths = "";
                    searchParkingSpaces = "";
                    searchStories = "";
                    searchPriceRange = "";
                    searchByOptions = "";
                    searchResults += " Showing all listings.";
                }

                ViewData["searchResults"] = searchResults;
                ViewBag.searchCity = "" + searchCity;
                ViewBag.searchBeds = "" + searchBeds;
                ViewBag.searchBaths = "" + searchBaths;
                ViewBag.searchParkingSpaces = "" + searchParkingSpaces;
                ViewBag.searchStories = "" + searchStories;
                ViewBag.searchPriceRange = "" + searchPriceRange;
                ViewBag.searchByOptions = "" + searchByOptions;
                ViewBag.displayAll = "" + displayAll;
            }

            return View();
        }

        [HttpGet]
        public IActionResult ContactUs()
        {
            return View();
        }

        [HttpPost]
        public IActionResult ContactUs(ContactUsModel contactUsModel)
        {
            if (ModelState.IsValid)
            {
                bool validForm = true;
                string contactFormResponse = "";

                string userName = "";
                string userEmail = "";
                string userSubject = "";
                string userComments = "";
                try
                {
                    userName = System.Web.HttpUtility.HtmlEncode(Request.Form["userName"]);
                    userEmail = System.Web.HttpUtility.HtmlEncode(Request.Form["userEmail"]);
                    userSubject = System.Web.HttpUtility.HtmlEncode(Request.Form["userSubject"]);
                    userComments = System.Web.HttpUtility.HtmlEncode(Request.Form["userComments"]);
                }
                catch (Exception)
                {
                    userName = "";
                    userEmail = "";
                    userSubject = "";
                    userComments = "";
                }


                if (userName == "" || userEmail == "" || userComments == "")
                {
                    validForm = false;
                    contactFormResponse = "Sorry, form not valid, please fill in all required (**) input fields. ";
                }


                if (!userEmail.Contains("@"))
                {
                    validForm = false;
                    contactFormResponse += "Email must contain at least 1 @ symbol. ";
                }

                if (!userEmail.Contains("."))
                {
                    validForm = false;
                    contactFormResponse += "Email must contain at least 1 period (.). ";
                }

                int atSymbolIndex = userEmail.IndexOf("@");
                int lastPeriodSymbol = userEmail.LastIndexOf(".");
                int userEmailLength = userEmail.Length;


                //Ensure at least 1 char before first @ symbol.
                if (!(atSymbolIndex > 0))
                {
                    validForm = false;
                    contactFormResponse += "Email must have at least one chracter before first @. ";
                }

                //Verify that at least 1 @ symbol comes before the last period, and that there is at least
                //one char in between them.
                if (!(atSymbolIndex + 1 < lastPeriodSymbol))
                {
                    validForm = false;
                    contactFormResponse += "Email must have at least 1 @ symbol before the last period (.). ";
                }

                //Verify that there are at least 2 chars after the last period.
                if (!(lastPeriodSymbol + 2 < userEmailLength))
                {
                    validForm = false;
                    contactFormResponse += "Email must contain at least two characters after the last period (.). ";
                }



                if (!validForm)
                {
                    contactFormResponse += "";
                }
                else if (validForm)
                {

                    //Construct the Email
                    string FromName = userName;
                    string FromEmail = userEmail;
                    string ToEmail = "youremail";
                    string EmailSubject = userSubject;

                    string BodyEmail = "<strong>From:</strong> " + userName + "<br />";
                    BodyEmail += "<strong>Email:</strong> " + userEmail + "<br />";
                    BodyEmail += "<strong>Subject:</strong> " + userSubject + "<br />";
                    BodyEmail += "<strong>Message/Comments:</strong> " + userComments;


                    var emailMessage = new MimeMessage();
                    emailMessage.From.Add(new MailboxAddress(FromName, ToEmail));
                    emailMessage.To.Add(new MailboxAddress("Super Portland Listings", ToEmail));

                    emailMessage.Subject = EmailSubject;
                    BodyBuilder emailBody = new BodyBuilder();
                    emailBody.HtmlBody = "" + BodyEmail;
                    emailMessage.Body = emailBody.ToMessageBody();

                    using (var destinationSmtp = new SmtpClient())
                    {
                        destinationSmtp.Connect("cmx5.my-hosting-panel.com", 465, true);
                        destinationSmtp.Authenticate("youremail", "yourpassword");
                        destinationSmtp.Send(emailMessage);
                        destinationSmtp.Disconnect(true);
                        destinationSmtp.Dispose();

                        contactFormResponse = "Thank you <strong>" + userName + "</strong>, we look forward to reading your comments and our reply will be sent to your email at: <strong>" + userEmail + "</strong>.";
                    }
                }
                ViewData["Message"] = "" + contactFormResponse;
            }
            return View();
        }

        public IActionResult Sellers()
        {
            return View();
        }

        public IActionResult OurTeam()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Sellers(SellerModel sellerModel)
        {
            if (ModelState.IsValid)
            {
                bool validForm = true;
                string contactFormResponse = "";

                string sellerName = "";
                string sellerEmail = "";
                string sellerPhone = "";
                string sellerCity = "";
                string sellerState = "";
                string sellerZIP = "";
                string sellerShortDescription = "";
                string sellerDesiredPrice = "";
                string sellerDesiredSellDate = "";
                string sellerAdditionalNotes = "";

                try
                {
                    sellerName = System.Web.HttpUtility.HtmlEncode(Request.Form["sellerName"]);
                    sellerEmail = System.Web.HttpUtility.HtmlEncode(Request.Form["sellerEmail"]);
                    sellerPhone = System.Web.HttpUtility.HtmlEncode(Request.Form["sellerPhone"]);
                    sellerCity = System.Web.HttpUtility.HtmlEncode(Request.Form["sellerCity"]);
                    sellerState = System.Web.HttpUtility.HtmlEncode(Request.Form["sellerState"]);
                    sellerZIP = System.Web.HttpUtility.HtmlEncode(Request.Form["sellerZIP"]);
                    sellerShortDescription = System.Web.HttpUtility.HtmlEncode(Request.Form["sellerShortDescription"]);
                    sellerDesiredPrice = System.Web.HttpUtility.HtmlEncode(Request.Form["sellerDesiredPrice"]);
                    sellerDesiredSellDate = System.Web.HttpUtility.HtmlEncode(Request.Form["sellerDesiredSellDate"]);
                    sellerAdditionalNotes = System.Web.HttpUtility.HtmlEncode(Request.Form["sellerAdditionalNotes"]);
                }
                catch (Exception)
                {
                    sellerName = "";
                    sellerEmail = "";
                    sellerPhone = "";
                    sellerCity = "";
                    sellerState = "";
                    sellerZIP = "";
                    sellerShortDescription = "";
                    sellerDesiredPrice = "";
                    sellerDesiredSellDate = "";
                    sellerAdditionalNotes = "";
                }


                if (sellerName == "" || sellerEmail == "" || sellerCity == "" || sellerState == "" || sellerZIP == "" || sellerShortDescription == "" || sellerDesiredPrice == ""
                    || sellerDesiredSellDate == "")
                {
                    validForm = false;
                    contactFormResponse = "Sorry, form not valid, please fill in all required (**) input fields. ";
                }


                if (!sellerEmail.Contains("@"))
                {
                    validForm = false;
                    contactFormResponse += "Email must contain at least 1 @ symbol. ";
                }

                if (!sellerEmail.Contains("."))
                {
                    validForm = false;
                    contactFormResponse += "Email must contain at least 1 period (.). ";
                }

                int atSymbolIndex = sellerEmail.IndexOf("@");
                int lastPeriodSymbol = sellerEmail.LastIndexOf(".");
                int userEmailLength = sellerEmail.Length;


                //Ensure at least 1 char before first @ symbol.
                if (!(atSymbolIndex > 0))
                {
                    validForm = false;
                    contactFormResponse += "Email must have at least one chracter before first @. ";
                }

                //Verify that at least 1 @ symbol comes before the last period, and that there is at least
                //one char in between them.
                if (!(atSymbolIndex + 1 < lastPeriodSymbol))
                {
                    validForm = false;
                    contactFormResponse += "Email must have at least 1 @ symbol before the last period (.). ";
                }

                //Verify that there are at least 2 chars after the last period.
                if (!(lastPeriodSymbol + 2 < userEmailLength))
                {
                    validForm = false;
                    contactFormResponse += "Email must contain at least two characters after the last period (.). ";
                }


                Int64 sellerPhoneInteger;
                bool sellerPhoneIsNumeric = Int64.TryParse(sellerPhone, out sellerPhoneInteger);
                if (sellerPhone.Length != 10 || !sellerPhoneIsNumeric)
                {
                    validForm = false;
                    contactFormResponse += "Phone must be exactly 10 digits in length, no dashes. ";
                }


                Int64 sellerZipCodeInteger;
                bool sellerZipCodeIsNumeric = Int64.TryParse(sellerZIP, out sellerZipCodeInteger);
                if (sellerZIP.Length != 5 || !sellerZipCodeIsNumeric)
                {
                    validForm = false;
                    contactFormResponse += "Zip code must be a number exactly 5 digits in length. ";
                }



                if (!validForm)
                {
                    contactFormResponse += "";
                }
                else if (validForm)
                {

                    //Construct the Email
                    string FromName = sellerName;
                    string FromEmail = sellerEmail;
                    string ToEmail = "youremail";
                    string EmailSubject = "Potential Seller Question from " + sellerName;

                    string BodyEmail = "<strong>From:</strong> " + sellerName + "<br />";
                    BodyEmail += "<strong>Email:</strong> " + FromEmail + "<br />";
                    BodyEmail += "<strong>Phone:</strong> " + sellerPhone + "<br />";
                    BodyEmail += "<strong>Subject:</strong> " + EmailSubject + "<br />";
                    BodyEmail += "<strong>Home Info (City, State, ZIP):</strong> " + sellerCity + " " + sellerState + " " + sellerZIP + "<br />";
                    BodyEmail += "<strong>Short Description:</strong> " + sellerShortDescription + "<br />";
                    BodyEmail += "<strong>Desired Price:</strong> " + sellerDesiredPrice + "<br />";
                    BodyEmail += "<strong>Desired Sell Date:</strong> " + sellerDesiredSellDate + "<br />";
                    BodyEmail += "<strong>Additional Notes:</strong> " + sellerAdditionalNotes;


                    var emailMessage = new MimeMessage();
                    emailMessage.From.Add(new MailboxAddress(FromName, ToEmail));
                    emailMessage.To.Add(new MailboxAddress("Super Portland Listings", ToEmail));

                    emailMessage.Subject = EmailSubject;
                    BodyBuilder emailBody = new BodyBuilder();
                    emailBody.HtmlBody = "" + BodyEmail;
                    emailMessage.Body = emailBody.ToMessageBody();

                    using (var destinationSmtp = new SmtpClient())
                    {
                        destinationSmtp.Connect("cmx5.my-hosting-panel.com", 465, true);
                        destinationSmtp.Authenticate("youremail", "yourpassword");
                        destinationSmtp.Send(emailMessage);
                        destinationSmtp.Disconnect(true);
                        destinationSmtp.Dispose();

                        contactFormResponse = "Thank you <strong>" + sellerName + "</strong>, we look forward to reading your comments and our reply will be sent to your email at: <strong>"
                            + sellerEmail + "</strong>.";
                    }
                }
                ViewData["Message"] = "" + contactFormResponse;
            }
            return View();
        }


        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult ListingPage()
        {
            ViewData["theListings"] = SuperPortlandListings.Program.theListings;
            ViewData["projectDate"] = SuperPortlandListings.Program.projectDate;
            return View();
        }

        [Route("error/404")]
        public IActionResult Error404()
        {
            return View();
        }

        public IActionResult Error500()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
