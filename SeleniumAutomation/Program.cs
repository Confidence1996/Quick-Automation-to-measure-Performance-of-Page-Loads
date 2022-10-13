using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System.IO;
using System.Collections.Generic;
using System.Timers;
using System.Text;

namespace SeleniumAutomation
{
    class Program
    {
        private static void DoAction(object source = null, ElapsedEventArgs e = null)
        {
            FileStream fstream = File.OpenWrite("output.csv");
            string outstring = "Begin\n";
            fstream.Write(Encoding.UTF8.GetBytes(outstring), 0, Encoding.UTF8.GetBytes(outstring).Length);
            outstring = "Transaction name\t"
                + ",Transaction time\t"
                + ",Time Stamp\t"
                + "\n";
            fstream.Write(Encoding.UTF8.GetBytes(outstring), 0, Encoding.UTF8.GetBytes(outstring).Length);
            Console.WriteLine("Automation test started");
            IWebDriver driver;
            string homeURL;
            List<string> ls = new List<string>();
            ls.Add("enable-logging");
            ChromeOptions options = new ChromeOptions();
            options.AddExcludedArguments(ls);
            driver = new ChromeDriver(options);

            homeURL = "https://jb.jobboxsoft.com/servicebox/Account/LogOn?ReturnUrl=%2fservicebox";
            driver.Navigate().GoToUrl(homeURL);
            WebDriverWait wait = new WebDriverWait(driver, System.TimeSpan.FromSeconds(30));
            wait.Until(driver => driver.FindElement(By.Name("UserID")));
            IWebElement UserId = driver.FindElement(By.Name("UserID"));
            IWebElement Password = driver.FindElement(By.Name("Password"));
            IWebElement LoginBtn = driver.FindElement(By.Name("strAction"));
            UserId.SendKeys("zane");                
            Password.SendKeys("Sept2022");
            LoginBtn.Click();

            wait.Until(driver => driver.FindElement(By.XPath("//a[@href='/servicebox/Customer']")));

            IWebElement Customers = driver.FindElement(By.XPath("//a[@href='/servicebox/Customer']"));
            while (true)
            {
                try
                {
                    Customers.Click();
                    break;
                }
                catch
                {
                   
                }
            }

            var time1 = DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond;
            var time2 = DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond;
            //sw.WriteLine("Customers:{");
            for (int i = 0; i < 5; i++)
            {
                while (true)
                {
                    try
                    {
                        wait.Until(driver => driver.FindElement(By.ClassName("name")));
                        break;
                    }
                    catch
                    {
                        driver.Navigate().Back();
                    }
                }
                var EachElements = driver.FindElements(By.ClassName("name"));
                if (EachElements.Count <= i) continue;
                while (true)
                {
                    try
                    {
                        EachElements[i].Click();
                        break;
                    }
                    catch
                    {

                    }
                }

                wait.Until(driver => driver.FindElement(By.ClassName("nl-fl")));
                time2 = DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond;
                Console.WriteLine("Customer -- " + i.ToString() + " :: " + (time2 - time1).ToString());

                string out_line_string = "Customer" + i.ToString() + "\t";
                out_line_string += "," + (time2 - time1).ToString() + "\t";
                out_line_string += "," + DateTime.Now.ToString() + "\t";
                out_line_string += "\n";
                fstream.Write(Encoding.UTF8.GetBytes(out_line_string), 0, Encoding.UTF8.GetBytes(out_line_string).Length);
                fstream.Flush();

                //sw.WriteLine((time2 - time1).ToString());
                time1 = time2;
                driver.Navigate().Back();
            }
            //sw.WriteLine("}");
            //sw.Flush();
            IWebElement JobSites = driver.FindElement(By.XPath("//a[@href='/servicebox/JobSite']"));

            while (true)
            {
                try
                {
                    JobSites.Click();
                    break;
                }
                catch
                {

                }

            }

            //sw.WriteLine("JobSites:{");
            for (int i = 0; i < 5; i++)
            {
                while (true)
                {
                    try
                    {
                        wait.Until(driver => driver.FindElement(By.ClassName("name")));
                        break;
                    }
                    catch
                    {
                        driver.Navigate().Back();
                    }
                }
                var EachElements = driver.FindElements(By.ClassName("name"));
                if (EachElements.Count <= i) continue;
                while (true)
                {
                    try
                    {
                        EachElements[i].Click();
                        break;
                    }
                    catch
                    {

                    }
                }

                wait.Until(driver => driver.FindElement(By.ClassName("nl-fl")));
                time2 = DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond;
                Console.WriteLine("JobSite -- " + i.ToString() + " :: " + (time2 - time1).ToString());
                string out_line_string = "JobSite" + i.ToString() + "\t";
                out_line_string += "," + (time2 - time1).ToString() + "\t";
                out_line_string += "," + DateTime.Now.ToString() + "\t";
                out_line_string += "\n";
                fstream.Write(Encoding.UTF8.GetBytes(out_line_string), 0, Encoding.UTF8.GetBytes(out_line_string).Length);
                fstream.Flush();
                //sw.WriteLine((time2 - time1).ToString());
                time1 = time2;

                driver.Navigate().Back();
            }
            //sw.WriteLine("}");
            IWebElement Quotes = driver.FindElement(By.XPath("//a[@href='/servicebox/Quote']"));
            while (true)
            {
                try
                {
                    Quotes.Click();
                    break;
                }
                catch 
                {

                }

            }
            //sw.WriteLine("Quotes:{");
            for (int i = 0; i < 5; i++)
            {
                while (true)
                {
                    try
                    {
                        wait.Until(driver => driver.FindElement(By.ClassName("name")));
                        break;
                    }
                    catch
                    {
                        driver.Navigate().Back();
                    }
                }
                var EachElements = driver.FindElements(By.ClassName("name"));
                if (EachElements.Count <= i) continue;
                while (true)
                {
                    try
                    {
                        EachElements[i].Click();
                        break;
                    }
                    catch
                    {

                    }
                }

                wait.Until(driver => driver.FindElement(By.ClassName("nl-fl")));
                time2 = DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond;
                Console.WriteLine("Quote -- " + i.ToString() + " :: " + (time2 - time1).ToString());
                string out_line_string = "Quote" + i.ToString() + "\t";
                out_line_string += "," + (time2 - time1).ToString() + "\t";
                out_line_string += "," + DateTime.Now.ToString() + "\t";
                out_line_string += "\n";
                fstream.Write(Encoding.UTF8.GetBytes(out_line_string), 0, Encoding.UTF8.GetBytes(out_line_string).Length);
                fstream.Flush();
                //sw.WriteLine((time2 - time1).ToString());
                time1 = time2;

                driver.Navigate().Back();
            }

            //sw.WriteLine("}");

            IWebElement Workorders = driver.FindElement(By.XPath("//a[@href='/servicebox/Workorder']"));
            while (true)
            {
                try
                {
                    Workorders.Click();
                    break;
                }
                catch 
                {

                }

            }
            //sw.WriteLine("Workorders:{");

            for (int i = 0; i < 5; i++)
            {
                while (true)
                {
                    try
                    {
                        wait.Until(driver => driver.FindElement(By.ClassName("name")));
                        break;
                    }
                    catch
                    {
                        driver.Navigate().Back();
                    }
                }
                var EachElements = driver.FindElements(By.ClassName("name"));
                if (EachElements.Count <= i) continue;
                while (true)
                {
                    try
                    {
                        EachElements[i].Click();
                        break;
                    }
                    catch
                    {

                    }
                }

                wait.Until(driver => driver.FindElement(By.ClassName("nl-fl")));
                time2 = DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond;
                Console.WriteLine("Workorder -- " + i.ToString() + " :: " + (time2 - time1).ToString());
                string out_line_string = "Workorder" + i.ToString() + "\t";
                out_line_string += "," + (time2 - time1).ToString() + "\t";
                out_line_string += "," + DateTime.Now.ToString() + "\t";
                out_line_string += "\n";
                fstream.Write(Encoding.UTF8.GetBytes(out_line_string), 0, Encoding.UTF8.GetBytes(out_line_string).Length);
                fstream.Flush();
                //sw.WriteLine((time2 - time1).ToString());
                time1 = time2;

                driver.Navigate().Back();
            }
            //sw.WriteLine("}");
            IWebElement Invoices = driver.FindElement(By.XPath("//a[@href='/servicebox/Invoice']"));
            while (true)
            {
                try
                {
                    Invoices.Click();
                    break;
                }
                catch 
                {

                }

            }

            //sw.WriteLine("Invoices:{");

            for (int i = 0; i < 5; i++)
            {
                while (true)
                {
                    try
                    {
                        wait.Until(driver => driver.FindElement(By.ClassName("name")));
                        break;
                    }
                    catch
                    {
                        driver.Navigate().Back();
                    }
                }
                var EachElements = driver.FindElements(By.ClassName("name"));
                if (EachElements.Count <= i) continue;
                while (true)
                {
                    try
                    {
                        EachElements[i].Click();
                        break;
                    }
                    catch
                    {

                    }
                }

                wait.Until(driver => driver.FindElement(By.ClassName("nl-fl")));
                time2 = DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond;
                Console.WriteLine("Invoice -- " + i.ToString() + " :: " + (time2 - time1).ToString());
                string out_line_string = "Invoice" + i.ToString() + "\t";
                out_line_string += "," + (time2 - time1).ToString() + "\t";
                out_line_string += "," + DateTime.Now.ToString() + "\t";
                out_line_string += "\n";
                fstream.Write(Encoding.UTF8.GetBytes(out_line_string), 0, Encoding.UTF8.GetBytes(out_line_string).Length);
                fstream.Flush();
                //sw.WriteLine((time2 - time1).ToString());
                time1 = time2;

                driver.Navigate().Back();
            }
            //sw.WriteLine("}");            
            //sw.WriteLine(DateTime.Now.ToString("en-US"));
            //sw.Flush();
            driver.Close();
            driver.Quit();
            outstring = "End";
            fstream.Write(Encoding.UTF8.GetBytes(outstring), 0, Encoding.UTF8.GetBytes(outstring).Length);
            fstream.Close();
        }
        static void Main(string[] args)
        {
            //sw = new StreamWriter("D://TimeEstimated.log");
            
            var timer1 = new System.Threading.Timer(_ => DoAction(), null, 0, 60 * 60 * 1000);
            string userName = Console.ReadLine();
            return;
            
        }
    }
}
