using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using MySql.Data;
using MySql.Data.MySqlClient;
using OpenQA.Selenium.Internal;
using System.Runtime.InteropServices;

namespace Autotrader_tracker
{

    public partial class Autotrader : Form
    {
        bool Elementthere;
        bool Elementthere1;
        
        

        public Autotrader()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Do you want to close?", "Confirm", MessageBoxButtons.YesNo);
            if (dr == DialogResult.Yes)
            {
                this.Close();
            }
            else if (dr == DialogResult.No)
            {

            }

        }
        private string SQLupdate(string Price, string Address, string Features)

        {
            string connStr = "server=localhost;user=root;database=zoopla data;port=3306;password=Laptop96";
            MySqlConnection conn = new MySqlConnection(connStr);
            conn.Open();
            DateTime myDateTime = DateTime.Now;
            string sqlFormattedDate = myDateTime.ToString("yyyy-MM-dd HH:mm:ss.fff");
            string sql = "INSERT INTO `zoopla data`.`table` (`Time`, `Price`, `Address`) VALUES ('" + sqlFormattedDate + "','" + Price + "', '" + Address + "'  )";
            //sql += "+Price+";
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            //MySqlDataReader rdr = cmd.ExecuteReader();
            int value = cmd.ExecuteNonQuery();
            conn.Close();
            return null;
            //create a function to check url?
        }

        public string Cardetailsfunc (string HTMLCLASSName,string Type,IWebDriver driver)

        {                
            string Car_Type="";
            if (Type == "Class")
            //string Car_Type;
            {
                for (int i = 0; i < 11; i++)
                {
                    try
                    {

                        // driver = new FirefoxDriver();
                        // string Car_Type = driver.FindElement(By.XPath("/html/body/div[3]/div[1]/main/article/div[2]/ul/li[1]/section/div/div/div/section/section/a")).Text;
                        Car_Type = driver.FindElement(By.ClassName(HTMLCLASSName)).Text;
                        //String Temp = driver.FindElement(By.XPath("/html/body/div[3]/div[1]/main/article/div[2]/ul/li[1]/section/div/div/div/section/section/a")).Text;

                        if (Car_Type != null)
                        {
                            return Car_Type;
                        }

                    }
                    catch (OpenQA.Selenium.NoSuchElementException)
                    {
                        return Car_Type;
                    }
                }
            }
            else if (Type =="Xpath")
            {
                {
                    for (int i = 0; i < 11; i++)
                    {
                        try
                        {

                            // driver = new FirefoxDriver();
                            // string Car_Type = driver.FindElement(By.XPath("/html/body/div[3]/div[1]/main/article/div[2]/ul/li[1]/section/div/div/div/section/section/a")).Text;
                            Car_Type = driver.FindElement(By.XPath(HTMLCLASSName)).Text;
                            //String Temp = driver.FindElement(By.XPath("/html/body/div[3]/div[1]/main/article/div[2]/ul/li[1]/section/div/div/div/section/section/a")).Text;

                            if (Car_Type != null)
                            {
                                return Car_Type;
                            }

                        }
                        catch (OpenQA.Selenium.NoSuchElementException)
                        {
                            return Car_Type;
                        }
                    }
                }


            }    
            return Car_Type;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            IWebDriver driver = new FirefoxDriver();
            driver.Url = "https://www.autotrader.co.uk/car-search?postcode=ha80be&year-to=2023&make=Kia&include-delivery-option=on&advertising-location=at_cars&page=1";
            System.Threading.Thread.Sleep(1500);
            try
            {
                driver.SwitchTo().Frame("sp_message_iframe_687971");

            }
            catch (OpenQA.Selenium.NoSuchFrameException)
            {

            }


            try
            {
                driver.SwitchTo().Frame("sp_message_iframe_687972");

            }
            catch (OpenQA.Selenium.NoSuchFrameException)
            {

            }

            IWebElement parentElement = driver.FindElement(By.Id("notice"));
            IWebElement childElement = parentElement.FindElement(By.XPath("/html/body/div/div[2]/div[3]/div[2]/button[2]"));
            childElement.Submit();

            System.Threading.Thread.Sleep(1500);

            driver.SwitchTo().ParentFrame();
            System.Threading.Thread.Sleep(1500);

            //IWebElement element = driver.(By.Id("UserName"));
            //string Cardetails = driver.FindElement(By.Id("202307129557840")).Text;
            // IWebElement parentElement1 = driver.FindElement(By.ClassName("sc-dSbvwS"));
            // IWebElement childElement1 = parentElement1.FindElement(By.ClassName("sc-kPTPQs"));

            string Cardetails = driver.FindElement(By.ClassName("sc-dSbvwS")).Text;

            try
            {
                //Using Xpath sometime works, sometimes it doesnt, using classnames seems to work always
               Elementthere1 = driver.FindElement(By.XPath("/html/body/div[3]/div[1]/main/article/div[2]/ul/li[1]/section/div/div/div/section/section/a")).Displayed;
                
                Elementthere = driver.FindElement(By.ClassName("bhYWPt")).Displayed;
                //Elementthere2 = driver.FindElement(By.CssSelector("#\\32 02304096113221 > div:nth-child(2) > div:nth-child(1) > div:nth-child(2) > section:nth-child(2) > section:nth-child(1) > a:nth-child(2)")).Displayed;

            }
            catch (OpenQA.Selenium.NoSuchElementException)
            {

            }
            System.Threading.Thread.Sleep(1500);

            for (int i = 0; i < 11; i++)
            {
                try
                {
                    if (Elementthere == true)
                    {
                        // string Car_Type = driver.FindElement(By.XPath("/html/body/div[3]/div[1]/main/article/div[2]/ul/li[1]/section/div/div/div/section/section/a")).Text;
                        string Car_Type = driver.FindElement(By.ClassName("bhYWPt")).Text;
                        //String Temp = driver.FindElement(By.XPath("/html/body/div[3]/div[1]/main/article/div[2]/ul/li[1]/section/div/div/div/section/section/a")).Text;
                        
                        if (Car_Type != null)
                        {
                            break;
                        }
                    }
                }
                catch (OpenQA.Selenium.NoSuchElementException)
                {

                }
            }
            string[,] carclasstable = new string[14, 2]
                                                {
                                                { "bhYWPt","Class"},
                                                { "VTOnK","Class"},
                                                { "/html/body/div[3]/div[1]/main/article/div[2]/ul/li[1]/section/div/div/div/section/section/p[2]","Xpath"},
                                                { "bCYfzz","Class"},
                                                { "jVGMCM","Class"},
                                                {"izRRDj","Class"},
                                                { "eRdvHw","Class"},
                                                { "/html/body/div[3]/div[1]/main/article/div[2]/ul/li[2]/section/div/div/div/section/section/a","Xpath"},
                                                { "/html/body/div[3]/div[1]/main/article/div[2]/ul/li[2]/section/div/div/div/section/section/p[1]","Xpath"},
                                                { "/html/body/div[3]/div[1]/main/article/div[2]/ul/li[2]/section/div/div/div/section/section/p[2]","Xpath"},
                                                { "/html/body/div[3]/div[1]/main/article/div[2]/ul/li[2]/section/div/div/div/section/section/ul","Xpath"},
                                                { "vnzOb","Class"},
                                                { "VTOnK","Class"},
                                                { "VTOnK","Class"},
                                                
                                                };
                string[] CarDarray=new string [14];
            for( int i = 0;i<carclasstable.GetLength(0);i++)
            {
                
                
                    string table= carclasstable[i,0];
                
                    CarDarray[i]=Cardetailsfunc(carclasstable[i,0], carclasstable[i,1], driver);
                
            }

            string cartype = "VTOnK";
            string htmltype = "Class";
            string CarD=Cardetailsfunc(cartype,htmltype,driver);
            string cartype1 = "/html/body/div[3]/div[1]/main/article/div[2]/ul/li[1]/section/div/div/div/section/section/p[2]";
            string htmltype1 = "Xpath";
            string CarDextra = Cardetailsfunc(cartype1, htmltype1,driver);
            string car_specificsclass = "bCYfzz";
            string car_specific = Cardetailsfunc(car_specificsclass, htmltype,driver);




            driver.Quit();
            //SQLupdate(Price, Address, Features);
        }
    }
}
