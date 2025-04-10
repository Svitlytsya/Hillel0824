﻿using SeleniumDemoQA.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumDemoQA.Tests
{
    public class CheckBoxTests: BaseClass
    {
        [Test]
        public void VerifyCheckBoxesCheckedAfterCheckAndExpandTheHome()
        {
            var checkBoxPage = new CheckBoxPage(_driver);
            checkBoxPage.Open();

            checkBoxPage.ExpandHomeFolder();

            checkBoxPage.CheckHomeCheckBox();

            Assert.That(checkBoxPage.IsHomeCheckBoxChecked(), Is.True);

        }

    }
}
