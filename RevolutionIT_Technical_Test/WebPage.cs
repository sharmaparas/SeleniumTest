using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;

namespace RevolutionIT_Technical_Test
{
    public class WebPage
    {
        private readonly IWebDriver Driver;
        private readonly string url = @"http://newtours.demoaut.com/mercurywelcome.php";
        public WebDriverWait Wait { get; set; }
        public WebPage(IWebDriver browser)
        {
            Driver = browser;
            PageFactory.InitElements(browser, this);
            Wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(30));
        }

        [FindsBy(How = How.Name, Using = "userName")]
        public IWebElement UserName { get; set; }

        [FindsBy(How = How.Name, Using = "password")]
        public IWebElement Password { get; set; }

        [FindsBy(How = How.Name, Using = "login")]
        public IWebElement SignIn { get; set; }

        [FindsBy(How = How.Name, Using = "findFlights")]
        public IWebElement FindFlightContinue { get; set; }

        [FindsBy(How = How.Name, Using = "reserveFlights")]
        public IWebElement ReserveFlightContinue { get; set; }

        [FindsBy(How = How.Name, Using = "tripType")]
        public IList<IWebElement> TripTypeRadioBtn { get; set; }

        [FindsBy(How = How.Name, Using = "fromPort")]
        public IWebElement DepartFrom { get; set; }

        [FindsBy(How = How.Name, Using = "toPort")]
        public IWebElement ArriveAt { get; set; }

        [FindsBy(How = How.Name, Using = "servClass")]
        public IList<IWebElement> ServiceClassRadioBtn { get; set; }

        [FindsBy(How = How.Name, Using = "passFirst0")]
        public IWebElement FirstName { get; set; }

        [FindsBy(How = How.Name, Using = "passLast0")]
        public IWebElement LastName { get; set; }

        [FindsBy(How = How.Name, Using = "creditnumber")]
        public IWebElement CardNumber { get; set; }

        [FindsBy(How = How.Name, Using = "ticketLess")]
        public IWebElement TicketLess { get; set; }

        [FindsBy(How = How.Name, Using = "buyFlights")]
        public IWebElement SecurePurchaseBtn { get; set; }


        public void BookFlight(Person person)
        {
            FirstName.SendKeys(person.FirstName);
            LastName.SendKeys(person.LastName);
            CardNumber.SendKeys(person.CardNumber);
            TicketLess.Click();
            SecurePurchaseBtn.Click();
            Wait.Until<IWebElement>(ExpectedConditions.ElementIsVisible(By.CssSelector("[href='mercurywelcome.php']")));
        }
        public void Navigate()
        {
            this.Driver.Navigate().GoToUrl(this.url);
        }

        public void SelectFlight()
        {
            ReserveFlightContinue.Click();
            //Wait for webdriver to load the page.
            Wait.Until<IWebElement>(ExpectedConditions.ElementIsVisible(By.Name("passFirst0")));
        }

        public void FindFlight()
        {
            TripTypeRadioBtn[1].Click();
            var departoption = new SelectElement(DepartFrom);
            departoption.SelectByValue("Sydney");
            var arriveat = new SelectElement(ArriveAt);
            arriveat.SelectByValue("London");
            ServiceClassRadioBtn[2].Click();
            FindFlightContinue.Click();
            Wait.Until<IWebElement>(ExpectedConditions.ElementIsVisible(By.Name("reserveFlights")));
        }

        public void Login(string username, string password)
        {
            Driver.Navigate().GoToUrl(this.url);
            UserName.Clear();
            Password.Clear();
            UserName.SendKeys(username);
            Password.SendKeys(password);
            SignIn.Click();
            Wait.Until<IWebElement>(ExpectedConditions.ElementIsVisible(By.Name("findFlights")));
        }
    }
}
