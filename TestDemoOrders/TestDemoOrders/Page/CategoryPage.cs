using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestDemoOrders.Page
{
    public class CategoryPage
    {
        private IWebDriver driver;
        private string baseUri;

        public CategoryPage(IWebDriver driver)
        {
            this.driver = driver;
            baseUri = "http://localhost:24548/";
        }

        public void NavigateToCategoryPage()
        {
            driver.Navigate().GoToUrl(baseUri + "/");
            IWebElement linkCategory = driver.FindElement(By.LinkText("Category"));
            linkCategory.Click();

        }

        public int CreateNewCategoryDB(string desc)
        {
            using (OrdersEntities db = new OrdersEntities())
            {
                Categories newCategory = new Categories();
                newCategory.Description = desc;
                db.Categories.Add(newCategory);
                return db.SaveChanges();
            }
        }
    }
}
