using System;
using System.Collections.Generic;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using TestSergeyGoncharov.Core;

namespace TestSergeyGoncharov
{
    public class DraftPage : PageObject
    {
        public DraftPage(IWebDriver driver) : base(driver) { }
        public By Draft { get; set; }
        public int DraftNumber { get; set; }
        public By MessageBodyInNewMessageWindowLocator => By.XPath("//div[@role='dialog']//div[@class='Am Al editable LW-avf tS-tW']");
        public By SaveAndCloseButtonLocator => By.XPath("//div[@role='dialog']//img[@class='Ha']");
        public By GetDraftLocatorByMessageBody(string messageBody) => By.XPath($"//span[@class='y2']/../span[contains(text(), '{messageBody}')]");
        public By DraftWessagesLocator => By.XPath("//table/tbody/tr//span[@class='y2']");
        public By DraftLocaror(string row) => By.XPath($"//table/tbody/tr[@role='row']{row}");
        public By DeleteButtonOnDraftLocator => By.XPath($"//table/tbody/tr[@role='row'][{DraftNumber}]//li[@data-tooltip='Delete']");

        public DraftPage TypeMessageBodyToDraft(string dtaftText)
        {
            MessageBodyInNewMessageWindowLocator.ClearAndSendKey(dtaftText, _driver);
            return this;
        }
        public DraftPage ClickOnSaveAndCloseButton()
        {
            _driver.FindElement(SaveAndCloseButtonLocator).Click();
            return this;
        }
        public DraftPage ClickOnCreatedDraft(string messageBody)
        {
            FindDraft(messageBody);
            _driver.FindElement(Draft).Click();
            return this;
        }

        public bool FindCreatedDraft(string dtaftTextBeforUpdate)
        {
            try
            {
                Wait.Until(ExpectedConditions.ElementIsVisible(GetDraftLocatorByMessageBody(dtaftTextBeforUpdate)));
                return true;
            }
            catch
            {
                return false;
            }
        }
        public void FindDraft(string messageBody)
        {
            IList<IWebElement> listOfDraftWessages = _driver.FindElements(DraftLocaror(""));
            for (int draft = 0; draft < listOfDraftWessages.Count; draft++)
            {
                    var rov = Convert.ToString("[" + (draft + 1) + "]");
                    By draftLocaror = DraftLocaror(rov);
                    IList<IWebElement> cellsInRow = _driver.FindElements(draftLocaror);
                    foreach (var cell in cellsInRow)
                    {
                        if (cell.Text.Contains(messageBody))
                        {
                            Draft = draftLocaror;
                            DraftNumber = (draft + 1);
                            break;
                        }
                    }
                    if (Draft!=null)
                {
                    break;
                }
            }
        }

        public void DeleteCreatedDraft()
        {
            var draft = _driver.FindElement(DeleteButtonOnDraftLocator);
            IJavaScriptExecutor js = (IJavaScriptExecutor)_driver;
            js.ExecuteScript("arguments[0].click()", draft);
            Wait.Until(ExpectedConditions.InvisibilityOfElementLocated(DeleteButtonOnDraftLocator));
        }
        public bool WaituntilDraftIsUpdated(string messageBody)
        {
            try
            {
                var UpdatedDraft = _driver.FindElement(Draft);
                Wait.Until(ExpectedConditions.TextToBePresentInElement(UpdatedDraft, messageBody));
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}