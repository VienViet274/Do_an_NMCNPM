using Do_an_NMCNPM.Models;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;

namespace Do_an_NMCNPM.Handle
{
    public class callDriver2
    {
        IWebDriver driver = new ChromeDriver();

        public List<Conference> crawlConference()
        {
            List<Conference> items = new List<Conference>();
            for (int i = 2; i < 3; i++)
            {
                driver.Navigate().GoToUrl($"https://conferenceindex.org/conferences/information-technology?page={i}");
                IReadOnlyCollection<IWebElement> productElements = driver.FindElements(By.CssSelector(".list-unstyled li"));
                int k = 0;
                foreach (IWebElement productElement in productElements)
                {
                    
                    string name = productElement.FindElement(By.TagName("a")).Text;
                    string location = productElement.Text.Split('-')[1];
                    var URLtemp = productElement.FindElement(By.TagName("a")).GetAttribute("href");
                    
                    IWebDriver driver2 = new ChromeDriver();
                    driver2.Navigate().GoToUrl($"{URLtemp}");
                    
                    string title = driver2.FindElement(By.CssSelector("h1")).Text;
                    
                    string conDetail = driver2.FindElement(By.CssSelector("#event-description")).Text;
                    
                    string type = driver2.FindElement(By.XPath("//li[contains(text(),'Event Type:')]//strong")).Text;
                    
                    string dedLine = driver2.FindElement(By.XPath("//li[contains(text(),'Final Submission:')]//strong")).Text;
                    string conDate = driver2.FindElement(By.XPath("//li[contains(text(),'Date:')]//strong")).Text;
                    
                    string Org = driver2.FindElement(By.XPath("//li[contains(text(),'Organization:')]//strong")).Text;
                    string web = driver2.FindElement(By.XPath("//li[contains(text(),'Website URL: ')]//strong")).GetAttribute("href");
                    string email = driver2.FindElement(By.XPath("//li[contains(text(),'Contact URL: ')]//strong")).Text;
                    Conference conference = new Conference();
                    // Add the item details to the list
                    conference.Date = conDate;
                    conference.Name = name;
                    conference.Location = location;
                    conference.URLnextPage = URLtemp;
                    conference.Description = conDetail;
                    
                    conference.Type = type;
                    
                    conference.ConferenceDates = conDate;
                    conference.Deadline = dedLine;
                    
                    conference.Organizer = Org;
                    conference.Website = web;
                    conference.WebsiteCraw_ID = 38;
                    conference.Email = email;
                    items.Add(conference);
                    k++;
                    driver2.Quit();
                    if (k == 10)
                    {
                        break;
                    }

                }

            }
            driver.Quit();
            return items;
        }
    }
}

