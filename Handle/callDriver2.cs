using Do_an_NMCNPM.Models;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;

namespace Do_an_NMCNPM.Handle
{
    public class callDriver2
    {
        IWebDriver driver = new ChromeDriver();

        public List<Conference> crawlConference()
        {
            List<Conference> items = new List<Conference>();
            for (int i = 1; i < 2; i++)
            {
                driver.Navigate().GoToUrl($"https://conferenceindex.org/conferences/information-technology?page={i}");
                IReadOnlyCollection<IWebElement> productElements = driver.FindElements(By.CssSelector(".list-unstyled li"));
                int k = 0;
                foreach (IWebElement productElement in productElements)
                {
                    // Extract the name and price of the product
                    //string date = productElement.Text.Split('\n')[0];
                    string name = productElement.FindElement(By.TagName("a")).Text;
                    string location = productElement.Text.Split('-')[1];
                    var URLtemp = productElement.FindElement(By.TagName("a")).GetAttribute("href");
                    // string URL = URLtemp.GetAttribute("href");
                    IWebDriver driver2 = new ChromeDriver();
                    driver2.Navigate().GoToUrl($"{URLtemp}");
                    //var container = driver2.FindElement(By.ClassName("serchsingle-box"));
                    string title = driver2.FindElement(By.CssSelector("h1")).Text;
                    ////string conDetail = container.FindElement(By.XPath("//p[strong[text()='Conference Details']]/following-sibling::p")).Text;
                    string conDetail = driver2.FindElement(By.CssSelector("#event-description")).Text;
                    //string conDetail = driver2.FindElement(By.XPath("//div[@id='event-description']//p")).Text;
                    string type = driver2.FindElement(By.XPath("//li[contains(text(),'Event Type:')]//strong")).Text;
                    //string type = container.FindElement(By.XPath("//p[strong[text()='Conference Details']]/following-sibling::p")).Text;
                    //string status = container.FindElement(By.XPath("//p[strong[text()='Status']]/span")).Text;
                    ////string status = container.FindElement(By.CssSelector("p strong:contains(\"Status\") + span.status-active")).Text;
                   // string venue = driver2.FindElement(By.CssSelector("li:contains('Venue:') strong")).Text.Split(":")[1];
                    //var venuePslit = venue.Split(":");
                    //var ven = venuePslit[1];
                    //string conCate = container.FindElement(By.CssSelector("div.inr-right-sec > div.serchsingle-box > p:nth-child(8)")).Text.Split(":")[1].Trim();
                    string dedLine = driver2.FindElement(By.XPath("//li[contains(text(),'Final Submission:')]//strong")).Text;
                    string conDate = driver2.FindElement(By.CssSelector("li:contains('Date:') strong")).Text;
                    //string conTopic = container.FindElement(By.CssSelector("div.serchsingle-box p:nth-of-type(7)")).Text.Split(":")[1].Trim();
                    ////string Org = container.FindElement(By.CssSelector("div.serchsingle-box p:nth-of-type(8)")).Text;
                    string Org = driver2.FindElement(By.CssSelector("li:contains('Organization:') strong")).Text;
                    string web = driver2.FindElement(By.CssSelector("li:contains('Website URL:') a")).GetAttribute("href");
                    string email = driver2.FindElement(By.CssSelector("li:contains('Contact E-mail:') a")).Text;
                    Conference conference = new Conference();
                    // Add the item details to the list
                    conference.Date = conDate;
                    conference.Name = name;
                    conference.Location = location;
                    conference.URLnextPage = URLtemp;
                    //conference.Description = conDetail;
                    //conference.Status = status;
                    conference.Type = type;
                    //conference.Venue = venue;
                    conference.ConferenceDates = conDate;
                    conference.Deadline = dedLine;
                    //conference.Category = conCate;
                    //conference.Topics = conTopic;
                    conference.Organizer = Org;
                    conference.Website = web;
                    conference.WebsiteCraw_ID = 1;
                    conference.Email = email;
                    items.Add(conference);
                    k++;
                    driver2.Quit();
                    if (k == 4)
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

