using Do_an_NMCNPM.Models;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;

namespace Do_an_NMCNPM.Handle
{
    public class callDriver
    {
        IWebDriver driver = new ChromeDriver();

        public List<Conference> crawlConference()
        {
            List<Conference> items = new List<Conference>();
            for (int i = 2; i < 3; i++)
            {
                driver.Navigate().GoToUrl($"https://www.conferenceineurope.org/information_technology.php?page={i}");
                IReadOnlyCollection<IWebElement> productElements = driver.FindElements(By.ClassName("data1"));
                int k = 0;
                foreach (IWebElement productElement in productElements)
                {
                    // Extract the name and price of the product
                    string date = productElement.FindElement(By.TagName("span")).Text;
                    string name = productElement.FindElement(By.CssSelector("td:nth-child(2) a")).Text;
                    string location = productElement.FindElement(By.CssSelector("td:nth-child(3) strong a")).Text;
                    var URLtemp = productElement.FindElement(By.CssSelector("td:nth-child(2) a"));
                    string URL = URLtemp.GetAttribute("href");
                    IWebDriver driver2 = new ChromeDriver();
                    driver2.Navigate().GoToUrl($"{URL}");
                    var container = driver2.FindElement(By.ClassName("serchsingle-box"));
                    string title = container.FindElement(By.TagName("h1")).Text;
                    //string conDetail = container.FindElement(By.XPath("//p[strong[text()='Conference Details']]/following-sibling::p")).Text;
                    string conDetail = container.FindElement(By.CssSelector("div.serchsingle-box p")).Text;
                   // string type = container.FindElement(By.XPath("//p[strong[text()='Type']]/following-sibling::p")).Text;
                    string type = container.FindElement(By.XPath("//p[strong[text()='Conference Details']]/following-sibling::p")).Text;
                    string status = container.FindElement(By.XPath("//p[strong[text()='Status']]/span")).Text;
                    //string status = container.FindElement(By.CssSelector("p strong:contains(\"Status\") + span.status-active")).Text;
                    string venue = container.FindElement(By.CssSelector("div.serchsingle-box p.event-detal")).Text;
                    var venuePslit = venue.Split(":");
                    var ven = venuePslit[1];
                    string conCate = container.FindElement(By.CssSelector("div.inr-right-sec > div.serchsingle-box > p:nth-child(8)")).Text.Split(":")[1].Trim();
                    string dedLine = container.FindElement(By.CssSelector("div.serchsingle-box p:nth-of-type(5)")).Text.Split(":")[1].Trim();
                    string conDate = container.FindElement(By.CssSelector("div.serchsingle-box p:nth-of-type(6)")).Text.Split(":")[1].Trim();
                    string conTopic = container.FindElement(By.CssSelector("div.serchsingle-box p:nth-of-type(7)")).Text.Split(":")[1].Trim();
                    //string Org = container.FindElement(By.CssSelector("div.serchsingle-box p:nth-of-type(8)")).Text;
                    string Org = container.FindElement(By.CssSelector("div.inr-right-sec > div.serchsingle-box > p:nth-child(10)")).Text;
                    string web = container.FindElement(By.CssSelector("div.serchsingle-box a.link")).GetAttribute("href");
                    string email = container.FindElement(By.CssSelector("div.serchsingle-box p:nth-of-type(10)")).Text.Split(":")[0].Trim();
                    Conference conference = new Conference();
                    // Add the item details to the list
                    conference.Date = date;
                    conference.Name = name;
                    conference.Location = location;
                    conference.URLnextPage = URL;
                    conference.Description = conDetail;
                    conference.Status = status;
                    conference.Type = type;
                    conference.Venue = ven;
                    conference.ConferenceDates = conDate;
                    conference.Deadline = dedLine;
                    conference.Category = conCate;
                    conference.Topics = conTopic;
                    conference.Organizer = Org;
                    conference.Website = web;
                    conference.WebsiteCraw_ID = 1;
                  //  conference.Email = email;
                    items.Add(conference);
                    k++;
                    driver2.Quit();
                    if (k == 1)
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
