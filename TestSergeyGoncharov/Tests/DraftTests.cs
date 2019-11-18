using NUnit.Framework;
using System;
using System.Threading;
using TestSergeyGoncharov.Core;
using TestSergeyGoncharov.Core.Pages;

namespace TestSergeyGoncharov
{
    public class DraftTests : BaseTest
    {
        [SetUp]
        public void Login()
        {
            var credentials = new Credentials();
            var loginPage = new LoginPage(Driver);
            var myAccountPage = new MyAccountPage(Driver);

            loginPage
                .SuccessLogIn(credentials.Email, credentials.Password);

            myAccountPage
                .WaitUntilPageIsLoaded();
        }
        [Test]
        public void DraftCreateAndUpdate1()
        {
            var dtaftTextBeforUpdate = $"Draft text befor update {DateTime.Now.ToString()}";
            var dtaftTextAfterUpdate = $"Draft text AFTER UPDATE {DateTime.Now.ToString()}";
        }
        [Test]
        public void DraftCreateAndUpdate()
        {
            var dtaftTextBeforUpdate = $"Draft text befor update {DateTime.Now.ToString()}";
            var dtaftTextAfterUpdate = $"Draft text AFTER UPDATE {DateTime.Now.ToString()}";
            var gmailPage = new GmailPage(Driver);
            var draftPage = new DraftPage(Driver);
            gmailPage
                .GoToGmailPage()
                .ClickOnDraftsItem()
                .ClickComposeButton();
            draftPage
                .TypeMessageBodyToDraft(dtaftTextBeforUpdate)
                .ClickOnSaveAndCloseButton();

            Assert.IsTrue(draftPage.FindCreatedDraft(dtaftTextBeforUpdate), "The draft wasn't created!");

            draftPage
                .ClickOnCreatedDraft(dtaftTextBeforUpdate)
                .TypeMessageBodyToDraft(dtaftTextAfterUpdate)
                .ClickOnSaveAndCloseButton();

            Assert.IsTrue(draftPage.WaituntilDraftIsUpdated(dtaftTextAfterUpdate), "The draft wasn't updated!");

            draftPage
                .DeleteCreatedDraft();
        }
        [TearDown]
        public void LogOut()
        {
            var header = new Header(Driver);
            header.SignOut();
        }
    }
}