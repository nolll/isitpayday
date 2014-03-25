﻿using Core.UseCases.SaveSettings;
using NUnit.Framework;
using Tests.Common;
using Web.Commands;
using Web.Models;

namespace Web.Tests.Commands
{
    public class CommandProviderTests : MockContainer
    {
        [Test]
        public void Method_Scenario_Expected()
        {
            var model = new IndexPagePostModel();

            var sut = GetSut();
            var result = sut.GetSaveSettingsCommand(model);

            Assert.NotNull(result);
        }

        private CommandProvider GetSut()
        {
            return new CommandProvider(
                GetMock<ISaveSettingsInteractor>().Object);
        }
    }
}