using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using Xunit;

namespace prs._5SAudits.UnitTests
{
    public class WebTestsIteration3
    {
        public IWebDriver driver { get; private set; }
        public IDictionary<String, Object> Vars { get; private set; }
        public IJavaScriptExecutor Js { get; private set; }

        const int timerLength = 500;

        public WebTestsIteration3()
        {
            driver = new ChromeDriver();
            Js = (IJavaScriptExecutor)driver;
            Vars = new Dictionary<String, Object>();
        }

        public void Dispose()
        {
            driver.Quit();
        }

        [Fact]
        public void StartingAnAudit_TestOne()
        {

            driver.Navigate().GoToUrl("http://localhost:4200/");
            driver.Manage().Window.Size = new System.Drawing.Size(1450, 1050);

            Thread.Sleep(timerLength);

            driver.FindElement(By.Id("newAuditButton")).Click();

            Thread.Sleep(timerLength);

            driver.FindElement(By.Id("zoneCategory")).Click();
            {
                var dropdown = driver.FindElement(By.Id("zoneCategory"));
                dropdown.FindElement(By.XPath("//option[. = 'Stamping']")).Click();
            }

            Thread.Sleep(timerLength);
            driver.FindElement(By.CssSelector(".form-select-sm")).Click();
            {
                var dropdown = driver.FindElement(By.CssSelector(".form-select-sm"));
                dropdown.FindElement(By.XPath("//option[. = 'West (M485, M470-5, M455, M460)']")).Click();
            }

            Thread.Sleep(timerLength);

            driver.FindElement(By.CssSelector(".btn")).Click();

            Thread.Sleep(timerLength);

            Assert.Equal(driver.FindElement(By.CssSelector(".fs-4")).Text, "Sort");
        }

        [Fact]
        public void EditingAnAudit_TestTwo()
        {
            driver.Navigate().GoToUrl("http://localhost:4200/home");
            driver.Manage().Window.Size = new System.Drawing.Size(1936, 1066);

            Thread.Sleep(timerLength);

            driver.FindElement(By.CssSelector(".input-group:nth-child(2) #floatingInputGroup1")).Click();
            driver.FindElement(By.CssSelector(".input-group:nth-child(2) #floatingInputGroup1")).SendKeys("1");

            Thread.Sleep(timerLength);


            driver.FindElement(By.LinkText("Edit")).Click();
            driver.FindElement(By.CssSelector(".btn")).Click();
            {
                var element = driver.FindElement(By.CssSelector(".btn"));
                Actions builder = new Actions(driver);
                builder.MoveToElement(element).Perform();
            }

            Thread.Sleep(timerLength);

            driver.FindElement(By.Id("scoreSelection")).Click();
            {
                var dropdown = driver.FindElement(By.Id("scoreSelection"));
                dropdown.FindElement(By.XPath("//option[. = '3']")).Click();
            }

            Thread.Sleep(timerLength);

            driver.FindElement(By.Id("btnNext")).Click();

            Thread.Sleep(timerLength);


            driver.FindElement(By.Id("btnPrevious")).Click();
            {
                String value = driver.FindElement(By.Id("scoreSelection")).GetAttribute("value");
                Assert.Equal(value, "3");
            }
        }

        [Fact]
        public void FilteringAndSortingAudits_TestThree()
        {
            driver.Navigate().GoToUrl("http://localhost:4200/home");
            driver.Manage().Window.Size = new System.Drawing.Size(1936, 1066);

            Thread.Sleep(timerLength);

            driver.FindElement(By.CssSelector(".input-group:nth-child(2) #floatingInputGroup1")).Click();
            driver.FindElement(By.CssSelector(".input-group:nth-child(2) #floatingInputGroup1")).SendKeys("1");

            Thread.Sleep(timerLength);


            driver.FindElement(By.LinkText("Edit")).Click();
            driver.FindElement(By.CssSelector(".btn")).Click();
            {
                var element = driver.FindElement(By.CssSelector(".btn"));
                Actions builder = new Actions(driver);
                builder.MoveToElement(element).Perform();
            }

            Thread.Sleep(timerLength);

            driver.FindElement(By.Id("scoreSelection")).Click();
            {
                var dropdown = driver.FindElement(By.Id("scoreSelection"));
                dropdown.FindElement(By.XPath("//option[. = '3']")).Click();
            }

            Thread.Sleep(timerLength);

            driver.FindElement(By.Id("btnNext")).Click();

            Thread.Sleep(timerLength);


            driver.FindElement(By.Id("btnPrevious")).Click();
            {
                String value = driver.FindElement(By.Id("scoreSelection")).GetAttribute("value");
                Assert.Equal(value, "3");
            }
        }

        [Fact]
        public void AddingPhotosCheckItem_TestFour()
        {

            driver.Navigate().GoToUrl("http://localhost:4200/");
            driver.Manage().Window.Size = new System.Drawing.Size(1450, 1050);

            Thread.Sleep(timerLength);

            driver.FindElement(By.Id("newAuditButton")).Click();

            driver.Navigate().GoToUrl("http://localhost:4200/home");
            driver.Manage().Window.Size = new System.Drawing.Size(1936, 1066);

            Thread.Sleep(timerLength);

            driver.FindElement(By.CssSelector(".input-group:nth-child(2) #floatingInputGroup1")).Click();
            driver.FindElement(By.CssSelector(".input-group:nth-child(2) #floatingInputGroup1")).SendKeys("1");

            Thread.Sleep(timerLength);


            driver.FindElement(By.LinkText("Edit")).Click();
            driver.FindElement(By.CssSelector(".btn")).Click();
            {
                var element = driver.FindElement(By.CssSelector(".btn"));
                Actions builder = new Actions(driver);
                builder.MoveToElement(element).Perform();
            }

            Thread.Sleep(timerLength);

            driver.FindElement(By.Id("scoreSelection")).Click();
            {
                var dropdown = driver.FindElement(By.Id("scoreSelection"));
                dropdown.FindElement(By.XPath("//option[. = '3']")).Click();
            }

            Thread.Sleep(timerLength);

            driver.FindElement(By.Id("btnNext")).Click();

            Thread.Sleep(timerLength);


            driver.FindElement(By.Id("btnPrevious")).Click();
            {
                String value = driver.FindElement(By.Id("scoreSelection")).GetAttribute("value");
                Assert.Equal(value, "3");
            }
        }

        [Fact]
        public void DeletingAnAudit_TestFive()
        {
            driver.Navigate().GoToUrl("http://localhost:4200/home");
            driver.Manage().Window.Size = new System.Drawing.Size(1936, 1066);

            Thread.Sleep(timerLength);

            driver.FindElement(By.CssSelector(".input-group:nth-child(2) #floatingInputGroup1")).Click();
            driver.FindElement(By.CssSelector(".input-group:nth-child(2) #floatingInputGroup1")).SendKeys("1");

            Thread.Sleep(timerLength);


            driver.FindElement(By.LinkText("Edit")).Click();
            driver.FindElement(By.CssSelector(".btn")).Click();
            {
                var element = driver.FindElement(By.CssSelector(".btn"));
                Actions builder = new Actions(driver);
                builder.MoveToElement(element).Perform();
            }

            Thread.Sleep(timerLength);

            driver.FindElement(By.Id("scoreSelection")).Click();
            {
                var dropdown = driver.FindElement(By.Id("scoreSelection"));
                dropdown.FindElement(By.XPath("//option[. = '3']")).Click();
            }

        }

        [Fact]
        public void AddingAuditStatus_TestSix()
        {

            driver.FindElement(By.LinkText("Edit")).Click();
            driver.FindElement(By.CssSelector(".btn")).Click();
            {
                var element = driver.FindElement(By.CssSelector(".btn"));
                Actions builder = new Actions(driver);
                builder.MoveToElement(element).Perform();
            }

            Thread.Sleep(timerLength);

            driver.FindElement(By.Id("scoreSelection")).Click();
            {
                var dropdown = driver.FindElement(By.Id("scoreSelection"));
                dropdown.FindElement(By.XPath("//option[. = '3']")).Click();
            }

            Thread.Sleep(timerLength);

            driver.FindElement(By.Id("btnNext")).Click();

            Thread.Sleep(timerLength);


            driver.FindElement(By.Id("btnPrevious")).Click();
            {
                String value = driver.FindElement(By.Id("scoreSelection")).GetAttribute("value");
                Assert.Equal(value, "3");
            }
        }

        [Fact]
        public void SendingSupportEmail_TestSeven()
        {
            driver.Navigate().GoToUrl("http://localhost:4200/home");
            driver.Manage().Window.Size = new System.Drawing.Size(1936, 1066);

            Thread.Sleep(timerLength);

            driver.FindElement(By.CssSelector(".input-group:nth-child(2) #floatingInputGroup1")).Click();
            driver.FindElement(By.CssSelector(".input-group:nth-child(2) #floatingInputGroup1")).SendKeys("1");

            Thread.Sleep(timerLength);


            driver.FindElement(By.Id("scoreSelection")).Click();
            {
                var dropdown = driver.FindElement(By.Id("scoreSelection"));
                dropdown.FindElement(By.XPath("//option[. = '3']")).Click();
            }

            Thread.Sleep(timerLength);

            driver.FindElement(By.Id("btnNext")).Click();

            Thread.Sleep(timerLength);


            driver.FindElement(By.Id("btnPrevious")).Click();
            {
                String value = driver.FindElement(By.Id("scoreSelection")).GetAttribute("value");
                Assert.Equal(value, "3");
            }
        }

    }
}
